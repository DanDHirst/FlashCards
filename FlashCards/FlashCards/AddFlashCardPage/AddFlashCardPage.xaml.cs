using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCards.AddFlashCardPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddFlashCardPage : ContentPage
    {
        private AddFlashCardPageViewModel vm;
        public AddFlashCardPage(AddFlashCardPageViewModel vm, string cardGroup)
        {
            InitializeComponent();
            this.vm = vm;
            BindingContext = vm ?? new AddFlashCardPageViewModel();
        }
    }
}