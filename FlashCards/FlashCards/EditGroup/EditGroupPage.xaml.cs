using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCards.EditGroup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditGroupPage : ContentPage
    {
        EditGroupViewModel vm;
        public EditGroupPage(EditGroupViewModel vm)
        {
            InitializeComponent();
            this.vm = vm;
            BindingContext = vm ?? new EditGroupViewModel();
        }
    }
}