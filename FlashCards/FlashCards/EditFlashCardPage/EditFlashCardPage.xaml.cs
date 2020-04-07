using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCards.EditFlashCardPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditFlashCardPage : ContentPage
    {
        private EditFlashCardViewModel vm; 
        public EditFlashCardPage(EditFlashCardViewModel vm)
        {
            InitializeComponent();
            this.vm = vm;
            BindingContext = vm ?? new EditFlashCardViewModel();
        }
    }
}