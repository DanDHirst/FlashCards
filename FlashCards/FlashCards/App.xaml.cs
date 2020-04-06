using FlashCards.Page0;
using Xamarin.Forms;


namespace FlashCards
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
           

            Group group = new Group();

            //FlashCard flash = new FlashCard();


            

            //Instantiate the viewmodel, and pass it a reference to the model
            FirstPageViewModel vm = new FirstPageViewModel(group);

            //Instantiatge the view, and pass it a reference to the viewmodel
          
            FirstPage firstPage = new FirstPage(vm);

            //Navigate in the first page
            MainPage = new NavigationPage(firstPage);

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }


    }
}
