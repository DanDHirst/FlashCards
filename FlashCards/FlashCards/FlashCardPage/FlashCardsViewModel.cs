using BasicNavigation;
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

namespace FlashCards.FlashCardPage
{
    public class FlashCardsViewModel : ViewModelBase
    {
        private ObservableCollection<Model.FlashCard> cards;
        private ObservableCollection<string> answers;
        private ObservableCollection<string> questions;
        private string selectedGroup;

        public FlashCardsViewModel()
        {

        }

        public FlashCardsViewModel(string cardGroup, ObservableCollection<FlashCard> FlashCards)
        {
            //_groupCards = FlashCards.Where(i => i.Group == cardGroup);
            getGroupCards(cardGroup, FlashCards);

        }

        public void getGroupCards(string group, ObservableCollection<FlashCard> AllCards)
        {
            selectedGroup = group;
            cards = new ObservableCollection<FlashCard>(AllCards.Where(i => i.Group == group));
            questions = new ObservableCollection<string>(cards.Select(c => c.Question));
            answers = new ObservableCollection<string>(cards.Select(c => c.Answer));
        }

        public ObservableCollection<string> ListOfQuestions
        {
            get => questions;
            set
            {
                if (questions == value) return;
                questions = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> ListOfAnswers
        {
            get => answers;
            set 
            {
                if (answers == value) return;
                answers = value;
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
        
        public string DisplayFlashCardAnswer(int questionIndex)
        {
            return ListOfAnswers[questionIndex];
        }
    }
}
