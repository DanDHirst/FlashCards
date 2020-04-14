/*using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using FlashCards.Model;
using Microsoft.Azure.Cosmos;

namespace Setup
{

    public class DBTools
    {
        private static readonly string EndpointUri = "https://danielhirst.documents.azure.com:443/";

        // The primary key for the Azure Cosmos account.
        private static readonly string PrimaryKey = "JWJ0tjhLyYjbDARKgip2TjzN2fqiXVsd2S2ledqewxrfcNB1Y7HYzvDsMfkffINQWcjgEmE4Y04M4fSlknbJcQ==";

        // The Cosmos client instance
        private CosmosClient cosmosClient;

        // The database we will create
        private Database database;

        // The container we will create.
        private Container container;

        // The name of the database and container we will create
        private string databaseId = "FlashCardsDB";
        private string containerId = "Items";


        public async Task Go()

        {
            this.cosmosClient = new CosmosClient(EndpointUri, PrimaryKey, new CosmosClientOptions()
            {
                ApplicationName = "FlashCards"
            });

            // Create a new database
            this.database = await this.cosmosClient.CreateDatabaseIfNotExistsAsync(databaseId);
            Console.WriteLine("Created Database: {0}\n", this.database.Id);

            //Create container
            this.container = await this.database.CreateContainerIfNotExistsAsync(containerId, "/User", 400);

            //Add initial records
            Group group = new Group();
            group.Setup();
            await AddFlashCardIfNotExist(group);
*//*            await AddFlashCardIfNotExist(new FlashCard("test1", "12", "soft262"));
            await AddFlashCardIfNotExist(new FlashCard("test2", "12", "soft262"));*//*



            //Read back all records        
            await QueryAllRecords("soft262");
            *//* await QueryAllRecords(false);*//*

            //Update record
            *//*var mars = new SolPlanet("Mars", 228, true);
            await ToggleExplored("Mars");*//*

            //Delete record
            *//* await DeleteItemAsync("Uranus");*//*
        }

        async Task AddFlashCardIfNotExist(Group p)
        {
            try
            {
                // Read the item to see if it exists.  The ID (unique) is Name property
                ItemResponse<Group> CardResponse = await this.container.ReadItemAsync<Group>(p.ID, new PartitionKey(p.User));
                Console.WriteLine("Item in database with id: {0} already exists\n", CardResponse.Resource.User);
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                ItemResponse<Group> CardResponse = await this.container.CreateItemAsync<Group>(p, new PartitionKey(p.User));

                // Note that after creating the item, we can access the body of the item with the Resource property off the ItemResponse. We can also access the RequestCharge property to see the amount of RUs consumed on this request.
                Console.WriteLine("Created item in database with id: {0} Operation consumed {1} RUs.\n", CardResponse.Resource.User, CardResponse.RequestCharge);
            }
        }

        async Task QueryAllRecords(string exp)
        {
            *//* Console.WriteLine($"Explored is {exp}");
             var sql = $"SELECT * FROM c where c.Group = {exp.ToString().ToLower()}";
             Console.WriteLine("Running query: {0}\n", sql);
             QueryDefinition queryDefinition = new QueryDefinition(sql);
             FeedIterator<FlashCard> queryResultSetIterator = this.container.GetItemQueryIterator<FlashCard>(queryDefinition);

             List<FlashCard> planets = new List<FlashCard>();

             while (queryResultSetIterator.HasMoreResults)
             {
                 FeedResponse<FlashCard> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                 foreach (FlashCard planet in currentResultSet)
                 {
                     planets.Add(planet);
                     Console.WriteLine("\tRead {0}\n", planet);
                 }
             }*//*
            var sqlQueryText = "SELECT * FROM c";

            Console.WriteLine("Running query: {0}\n", sqlQueryText);

            QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
            FeedIterator<Group> queryResultSetIterator = this.container.GetItemQueryIterator<Group>(queryDefinition);

            List<Group> families = new List<Group>();

            while (queryResultSetIterator.HasMoreResults)
            {
                FeedResponse<Group> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (Group family in currentResultSet)
                {
                    families.Add(family);
                    Console.WriteLine("\tRead {0}\n", family);
                }
            }

        }

        //Update
        *//*async Task ToggleExplored(string name)
        {
            ItemResponse<FlashCard> resp = await this.container.ReadItemAsync<FlashCard>(name, new PartitionKey("User"));
            FlashCard itemBody = resp.Resource;
            itemBody.IsExplored = !itemBody.IsExplored;
            resp = await container.ReplaceItemAsync<FlashCard>(itemBody, itemBody.Name, new PartitionKey("User"));
            Console.WriteLine($"Updated {name} - explored set up {itemBody.IsExplored} - response {resp}");
        }*//*

        //Delete
        private async Task DeleteItemAsync(string name)
        {
            // Delete an item. Note we must provide the partition key value and id of the item to delete
            ItemResponse<Group> resp = await this.container.DeleteItemAsync<Group>(name, new PartitionKey("User"));
            Console.WriteLine($"Deleted {name} - response {resp}");
        }

        //Delete Everything
        private async Task DeleteDatabaseAndCleanupAsync()
        {
            DatabaseResponse databaseResourceResponse = await this.database.DeleteAsync();
            // Also valid: await this.cosmosClient.Databases["FamilyDatabase"].DeleteAsync();

            Console.WriteLine("Deleted Database: {0}\n", this.databaseId);

            //Dispose of CosmosClient
            this.cosmosClient.Dispose();
        }

    }
}
*/