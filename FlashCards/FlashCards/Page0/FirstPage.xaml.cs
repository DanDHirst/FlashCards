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
            DataTemplate dataTemplate = new DataTemplate(() =>
            {
                //Return a subclass of Cell
                TextCell cell = new TextCell();
                return cell;
            });

            //Binding proxy: When the DataTemplate instantiates a cell, it will also set up the binding as specified below
            //The source will be a data elelement
            dataTemplate.SetBinding(TextCell.TextProperty, "Question");
            dataTemplate.SetBinding(TextCell.DetailProperty, "Answer");

            //Finally, set the ItemTemplate property (type DataTemplate)
            PlanetListView.ItemTemplate = dataTemplate;

            

            
        }

    }
}