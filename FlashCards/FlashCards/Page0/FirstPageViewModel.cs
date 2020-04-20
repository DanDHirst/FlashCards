using BasicNavigation;
using FlashCards.EditGroup;
using FlashCards.FlashCardPage;
using FlashCards.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
namespace FlashCards.Page0
{
    public class FirstPageViewModel : ViewModelBase, IEditGroup, INavigateToCards
    {
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand RefreshCommand { get; }

        private ObservableCollection<Model.FlashCard> _flashCards; // all of the flash cards
        private ObservableCollection<string> listOfGroups; // not shown to screen temp storage
        private ObservableCollection<ListOfUniqueGroups> groupList; // live grouplist that is shown to the screen

        private Group groups;
        private string selectedItem; // not used yet
        private string newGroup; // used to store the add new group
        private bool isBusy = false;

        public void getListOfGroups(ObservableCollection<Model.FlashCard> flashCards) // used to display the group names in to the listview
        {

            ListOfGroups = new ObservableCollection<string>(flashCards.Select(f => f.Group).Distinct()); // locate all the unique group names 

            if (GroupList != null) // if the listview is full already clear it
            {
                GroupList.Clear();
            }
            foreach (string groupName in ListOfGroups) // loop through all the unique groupname to forge them into objects and add to a new list that will be shown on screen
            {
                ListOfUniqueGroups tempGroup = new ListOfUniqueGroups(groupName);
                if (GroupList == null)
                {
                    GroupList = new ObservableCollection<ListOfUniqueGroups>(){
                        new ListOfUniqueGroups(groupName)
                    };
                }

                GroupList.Add(tempGroup);
            }
            _ = UpdateCloudStorage();
        }



        public ObservableCollection<string> ListOfGroups //accessors for temp storage
        {
            get => listOfGroups;
            set
            {
                if (listOfGroups == value) return;
                listOfGroups = value;

                OnPropertyChanged();
            }
        }
        public ObservableCollection<ListOfUniqueGroups> GroupList //accessors for live grouplist
        {
            get => groupList;
            set
            {
                if (groupList == value) return;
                groupList = value;

                OnPropertyChanged();
            }
        }

        public ObservableCollection<Model.FlashCard> FlashCards //accessors for all cards
        {
            get => _flashCards;
            set
            {
                if (_flashCards == value) return;

                _flashCards = value;

                OnPropertyChanged();
            }
        }



        public string NewGroup //accessors for adding a new group
        {
            get => newGroup;
            set
            {
                if (newGroup == value) return;

                newGroup = value;

                OnPropertyChanged();
            }
        }
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                if (isBusy == value) return;

                isBusy = value;

                OnPropertyChanged();
            }
        }


        public string SelectedItem
        {
            get => selectedItem;
            set
            {
                if (selectedItem == value) return;

                selectedItem = value;

                OnPropertyChanged();
            }
        }
        public Group Groups
        {
            get => groups;
            set
            {
                if (groups == value) return;

                groups = value;

                OnPropertyChanged();
            }
        }

        

        public FirstPageViewModel(Group group)
        {

            Groups = group;
            FlashCards = group.Cards;
            getListOfGroups(FlashCards);
            AddCommand = new Command(execute: AddGroupToList);
            DeleteCommand = new Command<ListOfUniqueGroups>(execute: (item) =>
            {
                DeleteItem(item);
            });
            EditCommand = new Command<ListOfUniqueGroups>(execute:  (item) =>
            {
                 EditItem(item);
            });
            RefreshCommand = new Command(async () => await ExecuteRefreshCommand());
            getListOfGroups(FlashCards);


        }

        public FirstPageViewModel()
        {
        }

        public void AddGroupToList()
        {

            FlashCard card = new FlashCard("Example question", "Example answer", NewGroup);
            FlashCards.Add(card);
            Groups.Cards = FlashCards;
            Groups.Save();
            getListOfGroups(FlashCards);
            NewGroup = "";
        }


        

        public void DeleteItem(ListOfUniqueGroups groupName)
        {
            ObservableCollection<Model.FlashCard> tempFlashcards = null; // stores flash cards that the group doesnt match
            //loop through the flashcards and delete the flash cards with the matching groups
            foreach (FlashCard card in FlashCards)
            {
                if (card.Group != groupName.Name) // if the group name is not equal to the cards group add it to a temp collection
                {
                    if (tempFlashcards == null) // prevent null pointer exceptions
                    {
                        tempFlashcards = new ObservableCollection<FlashCard>(){
                        new FlashCard(card)
                        };
                        
                    }
                    else
                    {
                        tempFlashcards.Add(card);
                    }

                }
            }
            FlashCards = tempFlashcards; // set the collection to the all the flash cards that don't match the group name
            Groups.Cards = FlashCards;
            Groups.Save();
            getListOfGroups(FlashCards); // refresh the groups on the mainpage
        }
        public void EditGroupList(string oldStr, string newStr)
        {
            ObservableCollection<Model.FlashCard> tempFlashcards = null; // stores flash cards that the group doesnt match
            //loop through the flashcards and delete the flash cards with the matching groups
            foreach (FlashCard card in FlashCards)
            {
                if (card.Group == oldStr) // if the group name is  equal to the cards group add it to a temp collection
                {
                    card.Group = newStr;
                    if (tempFlashcards == null) // prevent null pointer exceptions
                    {
                        tempFlashcards = new ObservableCollection<FlashCard>(){
                        new FlashCard(card)
                        };

                    }
                    else
                    {
                        tempFlashcards.Add(card);
                    }

                }
                else
                {
                    if (tempFlashcards == null) // prevent null pointer exceptions
                    {
                        tempFlashcards = new ObservableCollection<FlashCard>(){
                        new FlashCard(card)
                        };

                    }
                    else
                    {
                        tempFlashcards.Add(card);
                    }
                }
            }
            FlashCards = tempFlashcards; // set the collection to the all the flash cards that don't match the group name
            Groups.Cards = FlashCards;
            Groups.Save();
            getListOfGroups(FlashCards); // refresh the groups on the mainpage
        }

        public void EditItem(ListOfUniqueGroups groupName)
        {
            EditGroupViewModel vm = new EditGroupViewModel(this, groupName.Name);
            EditGroupPage nextPage = new EditGroupPage(vm);
            Navigation.PushAsync(nextPage);
        }

        public void NavigateToFlashCardPage(string cardGroup)
        {
            
            FlashCardsViewModel vm = new FlashCardsViewModel(cardGroup, FlashCards, Groups); //VM knows about its model (reference)

            // Instantiate the view, and provide the viewmodel
            FlashCardsPage nextPage = new FlashCardsPage(vm); //View knows about it's VM
            Navigation.PushAsync(nextPage);
        }

        public void EditGroupName(string oldStr,string newStr)
        {
            EditGroupList(oldStr, newStr);
        }
        public void syncFilewithCloud(Group g)
        {
            // create a new path as using async it forgets the file name
            string mainDir = FileSystem.AppDataDirectory;
            string path = System.IO.Path.Combine(mainDir, "FlashCard.xml");
            Groups = g;
            Groups.Save(path);
            FlashCards = Groups.Cards;
            getListOfGroups(FlashCards);
        }
        async Task UpdateCloudStorage()
        {

            await CosmosDBService.UpdateItem(Groups);



        }
        async Task ExecuteRefreshCommand()
        {
           

            IsBusy = true;

            try
            {
                var list = await CosmosDBService.GetGroups("Test");
                if (list.Count == 1)
                {
                    foreach (Group g in list)
                    {
                        syncFilewithCloud(g);
                    }

                }
            }
            finally
            {
                IsBusy = false;
            }
            
            

        }

        
    }
 
}

