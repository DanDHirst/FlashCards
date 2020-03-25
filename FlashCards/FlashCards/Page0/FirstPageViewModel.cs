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

        public void getListOfGroups(ObservableCollection<Model.FlashCard> flashCards)
        {


            listOfGroups =  new ObservableCollection<string>(flashCards.Select(f => f.Group).Distinct());

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






    public FirstPageViewModel() 
         {


            FlashCards = new ObservableCollection<Model.FlashCard>()
            {
                new Model.FlashCard("Earth", "1","soft262"),
                new Model.FlashCard("Mercury", "2","soft262"),
                new Model.FlashCard("Venus", "3","prco204"),
                new Model.FlashCard("Jupiter", "3","net206"),
                new Model.FlashCard("Mars", "4","prco204"),
                new Model.FlashCard("Saturn", "5","exam net206"),
                new Model.FlashCard("Pluto", "6","test")
            };
            getListOfGroups(FlashCards);
            ButtonCommand = new Command(execute: NavigateToYearEditPage);
        }

        void NavigateToYearEditPage()
        {
            //This has a concrete reference to a view inside a VM - is this good/bad/indifferent?

            // Create viewmodel and pass datamodel as a parameter
            // NOTE that Model is a reference type
            FlashCardsViewModel vm = new FlashCardsViewModel(); //VM knows about its model (reference)

            // Instantiate the view, and provide the viewmodel
            FlashCardsPage nextPage = new FlashCardsPage(vm); //View knows about it's VM
            Navigation.PushAsync(nextPage);
        }



    }
    
}
