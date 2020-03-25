using BasicNavigation;
using FlashCards.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace FlashCards.Page0
{
    public class FirstPageViewModel : ViewModelBase<Group>
    {

        public ObservableCollection<StudyGroup> group => Model.getGroup();
        public String Name = "Dan";
        private ObservableCollection<Model.FlashCard> _flashCards;
        private ObservableCollection<Model.FlashCard> _planets;




        /*public ObservableCollection<StudyGroup> StudyGroups = new ObservableCollection<StudyGroup>()
        {
                new StudyGroup("Explored", "E")
        {
            new FlashCard("Earth", "a"),
                    new FlashCard("Mars", "b")
                },
                new StudyGroup("Unexplored","U")
        {
            new FlashCard("Mercury", "c"),
                    new FlashCard("Venus", "d"),
                    new FlashCard("Jupiter", "a"),
                    new FlashCard("Saturn", "a"),
                    new FlashCard("Pluto", "a")
                }

        };*/
        public ObservableCollection<Model.FlashCard> Planets
        {
            get => _planets;
            set
            {
                if (_planets == value) return;
                _planets = value;
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

        public String _Name
        {
            get => Name;
            set
            {
                if (Name == value) return;
                Name = value;
                OnPropertyChanged();
            }
        }



        protected override void OnModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

    public FirstPageViewModel(Group model = null) 
        {
            Model = model ?? new Group();

            /*FlashCards = new ObservableCollection<FlashCard>()
            {
                new FlashCard("Mercury", "c"),
                    new FlashCard("Venus", "d"),
                    new FlashCard("Jupiter", "a"),
                    new FlashCard("Saturn", "a"),
                    new FlashCard("Pluto", "a")
            };*/
            FlashCards = new ObservableCollection<Model.FlashCard>()
            {
                new Model.FlashCard("Earth", "1"),
                new Model.FlashCard("Mercury", "2"),
                new Model.FlashCard("Venus", "3"),
                new Model.FlashCard("Jupiter", "3"),
                new Model.FlashCard("Mars", "4"),
                new Model.FlashCard("Saturn", "5"),
                new Model.FlashCard("Pluto", "6")
            };
        }

    }
}
