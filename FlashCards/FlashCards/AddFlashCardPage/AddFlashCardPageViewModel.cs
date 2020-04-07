using System;
using System.Collections.Generic;
using System.Text;
using FlashCards.Model;
using Xamarin.Forms;
using System.Windows.Input;
using System.Linq;
using System.Collections.ObjectModel;
using BasicNavigation;
using FlashCards.FlashCardPage;

namespace FlashCards.AddFlashCardPage
{
    public class AddFlashCardPageViewModel : ViewModelBase
    {
        public ICommand AddCommand { get; set; }
        private string group;
        private string newQuestion;
        private string newAnswer;
        private FlashCardsViewModel flashCardsViewModel;

        public AddFlashCardPageViewModel()
        {
        }

        public AddFlashCardPageViewModel(string cardGroup, FlashCardsViewModel flashCardsViewModel)
        {
            this.group = cardGroup;
            this.flashCardsViewModel = flashCardsViewModel;

            AddCommand = new Command(execute: AddNewCard);
        }


        public string NewQuestion
        {
            get => newQuestion;
            set
            {
                if (newQuestion == value) return;
                newQuestion = value;
                OnPropertyChanged();
            }
        }

        public string NewAnswer
        {
            get => newAnswer;
            set
            {
                if (newAnswer == value) return;
                newAnswer = value;
                OnPropertyChanged();
            }
        }

        public void AddNewCard()
        {
            FlashCard card = new FlashCard(NewQuestion, NewAnswer,  group);
            flashCardsViewModel.AddFlashCard(card);
            Navigation.PopAsync();

        }

    }
}
