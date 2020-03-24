using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace FlashCards
{
    public partial class App : Application
    {
        public App()
        {
            FlashCard card = new FlashCard("food?","yes");
            StudyGroup studygroup = new StudyGroup();
            studygroup.addFlashCard(card);

            Group group = new Group();
            group.addStudyGroup(studygroup);


            InitializeComponent();

            MainPage = new MainPage();
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
