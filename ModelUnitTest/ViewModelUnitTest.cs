

using FlashCards.FlashCardPage;
using FlashCards.Model;
using FlashCards.Page0;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTest
{
    [TestClass]
    public class ViewModelUnitTest
    {
        [TestMethod]
        public void ViewModelTestAddAGroup()
        {
            Group m = new Group();
            m.Setup();
            m.testMode = true;
            FirstPageViewModel vm = new FirstPageViewModel(m);
            vm.NewGroup="Test";
            FlashCard card = new FlashCard("Example question", "Example answer", "Test");
            vm.AddGroupToList();
            bool found = false;
            foreach(FlashCard f in vm.FlashCards)
            {
                if (f.ToString()==card.ToString())
                {
                    found = true;
                }
            }
            Assert.IsTrue(found); // this should be true
        }

        [TestMethod]
        public void ViewModelTestEditAGroup()
        {
            Group m = new Group();
            m.Setup();
            m.testMode = true;
            FirstPageViewModel vm = new FirstPageViewModel(m);
            vm.NewGroup = "Test";
            FlashCard card = new FlashCard("Example question", "Example answer", "Test");
            vm.AddGroupToList();
            ListOfUniqueGroups L = new ListOfUniqueGroups();
            vm.EditGroupName("Test", "Edit");
            bool found = false;
            foreach(FlashCard f in vm.FlashCards)
            {
                if (f.Group == card.Group)
                {
                    found = true;
                }    
            }
            Assert.IsFalse(found); // this should be false
        }

        [TestMethod]
        public void ViewModelTestDeleteAGroup()
        {
            Group m = new Group();
            m.Setup();
            m.testMode = true;
            FirstPageViewModel vm = new FirstPageViewModel(m);
            vm.NewGroup = "Test";
            FlashCard card = new FlashCard("Example question", "Example answer", "Test");
            vm.AddGroupToList();
            ListOfUniqueGroups L = new ListOfUniqueGroups();
            L.Name = "Test";
            vm.DeleteItem(L);
            bool found = false;
            foreach (FlashCard f in vm.FlashCards)
            {
                if (f.ToString() == card.ToString())
                {
                    found = true;
                }
            }
            Assert.IsFalse(found); // this should be false

        }

        [TestMethod]
        public void ViewModelTestDeleteACard()
        {
            Group m = new Group();
            m.Setup();
            
            m.testMode = true;
            FlashCard card= new FlashCard("Question", "Answer", "Test");
            m.Cards.Add(card);
            FlashCardsViewModel vm = new FlashCardsViewModel("Test",m.Cards,m);
            vm.DeleteItem(card);
            bool found = false;
            foreach (FlashCard f in vm.AllCards)
            {
                if (f.ToString() == card.ToString())
                {
                    found = true;
                }
            }
            Assert.IsFalse(found); // this should be false


        }

        [TestMethod]
        public void ViewModelTestAddACard()
        {
            Group m = new Group();
            m.Setup();
            m.testMode = true;
            FlashCardsViewModel vm = new FlashCardsViewModel("Test", m.Cards, m);

            FlashCard card = new FlashCard("Example question", "Example answer", "Test");
            vm.AddFlashCard(card);
            bool found = false;
            foreach (FlashCard f in vm.AllCards)
            {
                if (f.ToString() == card.ToString())
                {
                    found = true;
                }
            }
            Assert.IsTrue(found); // this should be true
        }

        [TestMethod]
        public void ViewModelTestEditACard()
        {
            Group m = new Group();
            m.Setup();

            m.testMode = true;
            FlashCard card = new FlashCard("Question", "Answer", "Test");
            FlashCard newCard = new FlashCard("que", "ans", "Test");
            m.Cards.Add(card);
            FlashCardsViewModel vm = new FlashCardsViewModel("Test", m.Cards, m);
            vm.EditFlashCard(card, newCard);
            bool found = false;
            foreach (FlashCard f in vm.AllCards)
            {
                if (f.ToString() == card.ToString())
                {
                    found = true;
                }
            }
            Assert.IsFalse(found); // this should be false



        }
    }
}
