using FlashCards.Model;
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

            FlashCardsListView.SelectionMode = ListViewSelectionMode.None;
            FlashCardsListView.ItemTapped += QuestionListView_ItemTapped;


            DataTemplate dataTemplate = new DataTemplate(() => // taken from https://github.com/UniversityOfPlymouthComputing/MobileDev-XamarinForms/blob/master/docs/Chapters/Chapter_4_MasterDetail/listview-delete.md
            {
                //Return a subclass of Cell
                TextCell cell = new TextCell();
                //We can set properties on cell
                MenuItem delete = new MenuItem
                {
                    Text = "Delete",
                    IsDestructive = true
                };
                MenuItem edit = new MenuItem
                {
                    Text = "Edit",
                    IsDestructive = true
                };


                delete.SetBinding(MenuItem.CommandProperty, new Binding("DeleteCommand", source: this.BindingContext));

                delete.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));

                edit.SetBinding(MenuItem.CommandProperty, new Binding("EditCommand", source: this.BindingContext));

                edit.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
                



                //Add menu item to the cell
                cell.ContextActions.Add(delete);
                cell.ContextActions.Add(edit);

                return cell;
            });
            dataTemplate.SetBinding(TextCell.TextProperty, "Question");

            //Finally, set the ItemTemplate property (type DataTemplate)
            FlashCardsListView.ItemTemplate = dataTemplate;

        }

        private async void QuestionListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            FlashCard itemString = (FlashCard)e.Item;
            await DisplayAlert(itemString.Question, itemString.Answer, "OK");
        }

    }
}