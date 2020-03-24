using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCards.Page0
{
    public partial class FirstPage : ContentPage
    {


        public FirstPage(FirstPageViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm ?? new FirstPageViewModel();
            NavigationPage.SetBackButtonTitle(this, "Back");
        }

    }
}