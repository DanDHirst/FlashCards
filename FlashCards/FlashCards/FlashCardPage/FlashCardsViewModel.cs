
using FlashCards.Page0;
using FlashCards.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using FlashCards.AddFlashCardPage;
using FlashCards.EditFlashCardPage;
using BasicNavigation;
using Xamarin.Essentials;
using System.Threading.Tasks;

namespace FlashCards.FlashCardPage
{
    public class FlashCardsViewModel : ViewModelBase, IAddFlashCard , IEditFlashCard
    {
        public ICommand AddCardCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand RefreshCommand { get; }

        private ObservableCollection<FlashCard> cards;
/*        private ObservableCollection<string> answers;
        private ObservableCollection<string> questions;*/
        private ObservableCollection<FlashCard> allCards;
        private string selectedGroup;
        private Group groups;
        private bool isBusy = false;

        public FlashCardsViewModel()
        {

        }

        public FlashCardsViewModel(string cardGroup, ObservableCollection<FlashCard> FlashCards, Group groups)
        {
            //_groupCards = FlashCards.Where(i => i.Group == cardGroup);
            this.groups = groups;
            getGroupCards(cardGroup, FlashCards);
            AddCardCommand = new Command(execute: NavigateToAddFlashCardPage);
            DeleteCommand = new Command<FlashCard>(execute: (item) =>
            {
                DeleteItem(item);
            });
            EditCommand = new Command<FlashCard>(execute: (item) =>
            {
                EditItem(item);
            });
            RefreshCommand = new Command(async () => await ExecuteRefreshCommand());
        }

        public void DeleteItem(FlashCard card)
        {
            AllCards.Remove(card);
            getGroupCards(SelectedGroup, AllCards);

        }
        public void EditItem(FlashCard card)
        {
            NavigateToEditFlashCardPage(card);
        }

        public void getGroupCards(string group, ObservableCollection<FlashCard> AllCards)
        {
            this.AllCards = AllCards;
            selectedGroup = group;
            Cards = new ObservableCollection<FlashCard>(AllCards.Where(i => i.Group == group));
            groups.Cards = AllCards;
            groups.Save();
            _ = UpdateCloudStorage();
        }

      
        public Boolean IsBusy
        {
            get => isBusy;
            set
            {
                if (isBusy == value) return;

                isBusy = value;

                OnPropertyChanged();
            }
        }
        public string SelectedGroup
        {
            get => selectedGroup;
            set
            {
                if (selectedGroup == value) return;
                selectedGroup = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<FlashCard> Cards
        {
            get => cards;
            set
            {
                if (cards == value) return;
                cards = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<FlashCard> AllCards
        {
            get => allCards;
            set
            {
                if (allCards == value) return;
                allCards = value;
                OnPropertyChanged();
            }
        }

        /* public string DisplayFlashCardAnswer(int questionIndex)
         {
             return ListOfAnswers[questionIndex];
         }


 */
        public void NavigateToEditFlashCardPage(FlashCard card)
        {
            EditFlashCardViewModel vm = new EditFlashCardViewModel(card, this);

            EditFlashCardPage.EditFlashCardPage nextPage = new EditFlashCardPage.EditFlashCardPage(vm);
            Navigation.PushAsync(nextPage);
        }

        public void NavigateToAddFlashCardPage()
        {
            AddFlashCardPageViewModel vm = new AddFlashCardPageViewModel(selectedGroup,this);

            AddFlashCardPage.AddFlashCardPage nextPage = new AddFlashCardPage.AddFlashCardPage(vm);
            Navigation.PushAsync(nextPage);
        }

        public void AddFlashCard(FlashCard card)
        {
            AllCards.Add(card);
            getGroupCards(SelectedGroup,AllCards);

        }

        public void EditFlashCard(FlashCard oldCard, FlashCard newCard)
        {
            AllCards.Remove(oldCard);
            AllCards.Add(newCard);
            getGroupCards(SelectedGroup, AllCards);
        }

        
        async Task UpdateCloudStorage()
        {

            await CosmosDBService.UpdateItem(groups);



        }
        async Task ExecuteRefreshCommand()
        {

            IsBusy = true;

            try
            {
                var list = await CosmosDBService.GetToDoItems("Test");
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
        public void syncFilewithCloud(Group g)
        {
            // create a new path as using async it forgets the file name
            string mainDir = FileSystem.AppDataDirectory;
            string path = System.IO.Path.Combine(mainDir, "FlashCard.xml");
            groups = g;
            groups.Save(path);
            AllCards = groups.Cards;
            getGroupCards(SelectedGroup, AllCards);
        }
    }
}
