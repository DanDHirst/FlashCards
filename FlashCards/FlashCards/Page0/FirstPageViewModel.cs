using BasicNavigation;
using FlashCards.FlashCardPage;
using FlashCards.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FlashCards.Page0
{
    public class FirstPageViewModel : ViewModelBase
    {
        public ICommand ButtonCommand { get; set; }
        public ICommand DeleteCommand { get; private set; }

        private ObservableCollection<Model.FlashCard> _flashCards;
        private ObservableCollection<string> listOfGroups;
        private ObservableCollection<ListOfUniqueGroups> groupList;
        private string selectedItem;
        private string newGroup;

        public void getListOfGroups(ObservableCollection<Model.FlashCard> flashCards)
        {

            ListOfGroups = new ObservableCollection<string>(flashCards.Select(f => f.Group).Distinct());

            if (GroupList != null)
            {
                GroupList.Clear();
            }
            foreach (string groupName in ListOfGroups)
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
        }



        public ObservableCollection<string> ListOfGroups
        {
            get => listOfGroups;
            set
            {
                if (listOfGroups == value) return;
                listOfGroups = value;

                OnPropertyChanged();
            }
        }
        public ObservableCollection<ListOfUniqueGroups> GroupList
        {
            get => groupList;
            set
            {
                if (groupList == value) return;
                groupList = value;

                OnPropertyChanged();
            }
        }

        public ObservableCollection<Model.FlashCard> FlashCards
        {
            get => _flashCards;
            set
            {
                if (_flashCards == value) return;

                _flashCards = value;

                OnPropertyChanged();
            }
        }



        public string NewGroup
        {
            get => newGroup;
            set
            {
                if (newGroup == value) return;

                newGroup = value;

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



        public FirstPageViewModel(Group group)
        {
            FlashCards = group.Cards;
            getListOfGroups(FlashCards);
            ButtonCommand = new Command(execute: AddGroupToList);
            DeleteCommand = new Command<ListOfUniqueGroups>(execute: (p) =>
            {
                DeleteItem(p);
            });
            getListOfGroups(FlashCards);
        }

        public FirstPageViewModel()
        {
        }

        public void AddGroupToList()
        {

            FlashCard card = new FlashCard("", "", NewGroup);
            FlashCards.Add(card);
            getListOfGroups(FlashCards);
        }




        public void DeleteItem(ListOfUniqueGroups groupName)
        {
            ObservableCollection<Model.FlashCard> tempFlashcards = null;
            //loop through the flashcards and delete the flash cards with the matching groups
            foreach (FlashCard card in FlashCards)
            {
                if (card.Group != groupName.Name)
                {
                    if (tempFlashcards == null)
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
            FlashCards = tempFlashcards;
            getListOfGroups(FlashCards); // refresh the groups on the mainpage
        }
        






    public void NavigateToFlashCardPage(string cardGroup)
        {
            //This has a concrete reference to a view inside a VM - is this good/bad/indifferent?

            // Create viewmodel and pass datamodel as a parameter
            // NOTE that Model is a reference type
            FlashCardsViewModel vm = new FlashCardsViewModel(cardGroup, FlashCards); //VM knows about its model (reference)

            // Instantiate the view, and provide the viewmodel
            FlashCardsPage nextPage = new FlashCardsPage(vm); //View knows about it's VM
            Navigation.PushAsync(nextPage);
        }












    }
 
}

