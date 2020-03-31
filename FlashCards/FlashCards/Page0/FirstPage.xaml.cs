﻿using FlashCards.Model;
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

            DataTemplate dataTemplate = new DataTemplate(() =>
            {
                //Return a subclass of Cell
                TextCell cell = new TextCell();
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