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
        private FlashCardsViewModel vm;
        public FlashCardsPage(FlashCardsViewModel vm)
        {
            InitializeComponent();
            this.vm = vm;
            BindingContext = vm ?? new FlashCardsViewModel();

            QuestionListView.SelectionMode = ListViewSelectionMode.None;
            QuestionListView.ItemTapped += QuestionListView_ItemTapped;
        }

        private async void QuestionListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            string answer = vm.DisplayFlashCardAnswer(e.ItemIndex);
            await DisplayAlert(e.Item.ToString(), answer, "OK");
        }
    }
}