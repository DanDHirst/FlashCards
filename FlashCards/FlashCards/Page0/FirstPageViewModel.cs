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

        private ObservableCollection<Model.FlashCard> _flashCards;
        private ObservableCollection<string> listOfGroups;
        private ObservableCollection<ListOfUniqueGroups> groupList;
        private string newGroup;

        public void getListOfGroups(ObservableCollection<Model.FlashCard> flashCards)
        {

            ListOfGroups =  new ObservableCollection<string>(flashCards.Select(f => f.Group).Distinct());

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






        public FirstPageViewModel(Group group) 
             {
                FlashCards = group.Cards;

           
                getListOfGroups(FlashCards);
                ButtonCommand = new Command(execute: AddGroupToList);
            }

        public FirstPageViewModel()
        {
        }

        public void AddGroupToList()
        {

            FlashCard card = new FlashCard("","", NewGroup);
            FlashCards.Add(card);
            getListOfGroups(FlashCards);
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
