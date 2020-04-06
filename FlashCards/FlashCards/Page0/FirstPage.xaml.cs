using FlashCards.Model;
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

        private FirstPageViewModel vm;
        public FirstPage(FirstPageViewModel vm)
        {
            InitializeComponent();
            this.vm = vm;
            BindingContext = vm ?? new FirstPageViewModel();

            GroupListView.SelectionMode = ListViewSelectionMode.None;
            GroupListView.ItemTapped += GroupListView_ItemTapped;



            DataTemplate dataTemplate = new DataTemplate(() => // taken from https://github.com/UniversityOfPlymouthComputing/MobileDev-XamarinForms/blob/master/docs/Chapters/Chapter_4_MasterDetail/listview-delete.md
            {
                //Return a subclass of Cell
                TextCell cell = new TextCell();
                //We can set properties on cell
                MenuItem m1 = new MenuItem
                {
                    Text = "Delete",
                    IsDestructive = true
                };
                MenuItem m2 = new MenuItem
                {
                    Text = "Edit",
                    IsDestructive = true
                };

                m1.SetBinding(MenuItem.CommandProperty, new Binding("DeleteCommand", source: this.BindingContext));

                m1.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));

                m2.SetBinding(MenuItem.CommandProperty, new Binding("EditCommand", source: this.BindingContext));

                m2.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));



                //Add menu item to the cell
                cell.ContextActions.Add(m1);
                cell.ContextActions.Add(m2);

                return cell;
            });


            //Binding proxy: When the DataTemplate instantiates a cell, it will also set up the binding as specified below
            //The source will be a data elelement
            dataTemplate.SetBinding(TextCell.TextProperty, "Name");
            /*dataTemplate.SetBinding(TextCell.DetailProperty, "Question");*/

            //Finally, set the ItemTemplate property (type DataTemplate)
            GroupListView.ItemTemplate = dataTemplate;



        }

      



        private async void GroupListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ListOfUniqueGroups itemString = (ListOfUniqueGroups)e.Item;
            await DisplayAlert("Alert", "You have clicked " + itemString.Name, "OK");
            vm.NavigateToFlashCardPage(itemString.Name);
        }

    }
}