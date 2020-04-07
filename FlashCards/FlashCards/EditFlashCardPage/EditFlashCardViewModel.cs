using BasicNavigation;
using FlashCards.FlashCardPage;
using FlashCards.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FlashCards.EditFlashCardPage
{
    public class EditFlashCardViewModel : ViewModelBase
    {
        private FlashCard oldFlashCard;
        private FlashCardsViewModel flashCardsViewModel;
        private ICommand SaveCommand { get; set; }
        private string question;
        private string answer;

        public EditFlashCardViewModel(FlashCard card, FlashCardsViewModel flashCardsViewModel)
        {
            this.oldFlashCard = card;
            this.flashCardsViewModel = flashCardsViewModel;
            Question = card.Question;
            Answer = card.Answer;

            SaveCommand = new Command(execute: SaveNewCard);
        }


        public string Question
        {
            get => question;
            set
            {
                if (question == value) return;

                question = value;

                OnPropertyChanged();
            }
        }
        public string Answer
        {
            get => answer;
            set
            {
                if (answer == value) return;

                answer = value;

                OnPropertyChanged();
            }
        }

        public EditFlashCardViewModel()
        {
           
        }
        public void SaveNewCard()
        {
            FlashCard newCard = new FlashCard(Question,Answer,oldFlashCard.Group);
            flashCardsViewModel.EditFlashCard(oldFlashCard, newCard);
            Navigation.PopAsync();
        }
    }
}
