using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Data;
using System.Diagnostics;
using Microsoft.Azure.Documents.Linq;
using Xamarin.Forms;

namespace FlashCards
{
    public class CosmosDBService
    {
        // code devlopled from https://docs.microsoft.com/en-us/azure/cosmos-db/create-sql-api-xamarin-dotnet#prerequisites
        static DocumentClient docClient = null;

        static readonly string databaseName = "FlashCardsDB";
        static readonly string collectionName = "Items";

        static async Task<bool> Initialize()
        {
            if (docClient != null)
                return true;

            try
            {
                docClient = new DocumentClient(new Uri(APIKeys.CosmosEndpointUrl), APIKeys.CosmosAuthKey);

                // Create the database - this can also be done through the portal
                await docClient.CreateDatabaseIfNotExistsAsync(new Database { Id = databaseName });

                // Create the collection - make sure to specify the RUs - has pricing implications
                // This can also be done through the portal

                await docClient.CreateDocumentCollectionIfNotExistsAsync(
                    UriFactory.CreateDatabaseUri(databaseName),
                    new DocumentCollection { Id = collectionName },
                    new RequestOptions { OfferThroughput = 400 }
                );

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                docClient = null;

                return false;
            }

            return true;
        }

        // <GetToDoItems>        
        /// <summary> 
        /// </summary>
        /// <returns></returns>
        public async static Task<List<Group>> GetGroups(string ID)
        {
            var groups = new List<Group>();

            if (!await Initialize())
                return groups;

            var groupQuery = docClient.CreateDocumentQuery<Group>(
                UriFactory.CreateDocumentCollectionUri(databaseName, collectionName),
                new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                .Where(todo => todo.ID == ID)
                .AsDocumentQuery();

            while (groupQuery.HasMoreResults)
            {
                var queryResults = await groupQuery.ExecuteNextAsync<Group>();

                groups.AddRange(queryResults);
            }
            Console.WriteLine(groups);
            return groups;
        }
        // </GetToDoItems>


      
        public async static Task UpdateItem(Group item)
        {
            if (!await Initialize())
                return;

            var docUri = UriFactory.CreateDocumentUri(databaseName, collectionName, item.ID);
            await docClient.ReplaceDocumentAsync(docUri, item);
        }
        // </UpdateToDoItem>  
    }
}
