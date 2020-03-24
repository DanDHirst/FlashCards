using FlashCards.Page0;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace FlashCards
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            FlashCard card = new FlashCard("food?","yes");
            StudyGroup studygroup = new StudyGroup();
            studygroup.addFlashCard(card);

            Group group = new Group();
            group.addStudyGroup(studygroup);


            

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
