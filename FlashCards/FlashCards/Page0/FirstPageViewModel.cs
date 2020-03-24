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
        public List<string> Planets = new List<string>
    {
        "Mercury",
        "Venus",
        "Jupiter",
        "Earth",
        "Mars",
        "Saturn",
        "Pluto"
    };

        public FirstPageViewModel(Group model = null) 
        {
            Model = model ?? new Group();
        }

        protected override void OnModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
