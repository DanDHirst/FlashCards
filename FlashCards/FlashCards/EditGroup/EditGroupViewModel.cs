using BasicNavigation;
using FlashCards.Page0;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FlashCards.EditGroup
{
    public class EditGroupViewModel : ViewModelBase
    {
        private FirstPageViewModel firstPageViewModel;
        private string oldGroup;
        private string name;

        public ICommand SaveCommand { get; set; }

        public EditGroupViewModel()
        {
        }


        public EditGroupViewModel(FirstPageViewModel firstPageViewModel, string name)
        {
            this.firstPageViewModel = firstPageViewModel;
            oldGroup = name;
            Name = name;
            SaveCommand = new Command(execute: () =>
            {
                firstPageViewModel.EditGroupName(oldGroup, Name);
                Navigation.PopAsync();
            });

        }

        public string Name
        {
            get => name;
            set
            {
                if (name == value) return;

                name = value;

                OnPropertyChanged();
            }
        }

    }
}
