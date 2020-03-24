using BasicNavigation;
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




        public ObservableCollection<StudyGroup> StudyGroups = new ObservableCollection<StudyGroup>()
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

        };

        protected override void OnModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

    public FirstPageViewModel(Group model = null) 
        {
            Model = model ?? new Group();
        }

    }
}
