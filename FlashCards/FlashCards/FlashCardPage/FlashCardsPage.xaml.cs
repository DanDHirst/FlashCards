using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCards.FlashCardPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlashCardsPage : ContentPage
    {
        public FlashCardsPage(FlashCardsViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm ?? new FlashCardsViewModel();


        }
    }
}