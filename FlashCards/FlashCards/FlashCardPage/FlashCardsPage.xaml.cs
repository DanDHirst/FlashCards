﻿using System;
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
            dataTemplate.SetBinding(TextCell.TextProperty, "Question");
            /*dataTemplate.SetBinding(TextCell.DetailProperty, "Question");*/

            //Finally, set the ItemTemplate property (type DataTemplate)
            FlashCardsListView.ItemTemplate = dataTemplate;

        }

        private async void QuestionListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            string answer = vm.DisplayFlashCardAnswer(e.ItemIndex);
            await DisplayAlert(e.Item.ToString(), answer, "OK");
        }

    }
}