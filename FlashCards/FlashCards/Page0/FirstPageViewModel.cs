﻿using BasicNavigation;
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
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; private set; }

        private ObservableCollection<Model.FlashCard> _flashCards; // all of the flash cards
        private ObservableCollection<string> listOfGroups; // not shown to screen temp storage
        private ObservableCollection<ListOfUniqueGroups> groupList; // live grouplist that is shown to the screen
        private string selectedItem; // not used yet
        private string newGroup; // used to store the add new group

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
            AddCommand = new Command(execute: AddGroupToList);
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
            getListOfGroups(FlashCards); // refresh the groups on the mainpage
        }
        

        public void NavigateToFlashCardPage(string cardGroup)
        {
            
            FlashCardsViewModel vm = new FlashCardsViewModel(cardGroup, FlashCards); //VM knows about its model (reference)

            // Instantiate the view, and provide the viewmodel
            FlashCardsPage nextPage = new FlashCardsPage(vm); //View knows about it's VM
            Navigation.PushAsync(nextPage);
        }


    }
 
}

