using BasicNavigation;
using FlashCards.Page0;
using Xamarin.Essentials;
using Xamarin.Forms;


namespace FlashCards
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();



            //FlashCard flash = new FlashCard();

            string mainDir = FileSystem.AppDataDirectory;
            string path = System.IO.Path.Combine(mainDir, "FlashCard.xml");
            Group m = BindableModelBase.Load<Group>(path);
            if (m == null)
            {
                //No such file, then create a new model with defaults and save
                m = new Group();
                m.Setup();
                m.Save(path);
            }


            //Instantiate the viewmodel, and pass it a reference to the model
            FirstPageViewModel vm = new FirstPageViewModel(m);

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
