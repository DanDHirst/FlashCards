

using FlashCards.Model;
using FlashCards.Page0;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelUnitTest.MockModel;

namespace ModelUnitTest
{
    [TestClass]
    public class ViewModelUnitTest
    {
        [TestMethod]
        public void ViewModelTestAddACard()
        {
            MockGroup m = new MockGroup();
            m.Setup();
            FirstPageViewModel vm = new FirstPageViewModel(m);
            vm.NewGroup="Test";
            FlashCard card = new FlashCard("Example question", "Example answer", "Test");
            vm.AddGroupToList();
            bool found = false;
            foreach(FlashCard f in vm.FlashCards)
            {
                if (f == card)
                {
                    found = true;
                }
            }
            Assert.IsTrue(found);
        }

        [TestMethod]
        public void ViewModelTestEditAGroup()
        {
            MockGroup m = new MockGroup();
            m.Setup();
            FirstPageViewModel vm = new FirstPageViewModel(m);
            vm.NewGroup = "Test";
            FlashCard card = new FlashCard("Example question", "Example answer", "Test");
            vm.AddGroupToList();
            ListOfUniqueGroups L = new ListOfUniqueGroups();
            vm.EditGroupName("Test", "Edit");
            bool found = false;
            foreach(FlashCard f in vm.FlashCards)
            {
                if (f == card)
                {
                    found = true;
                }    
            }
            Assert.IsTrue(found);
        }

        [TestMethod]
        public void ViewModelTestDeleteAGroup()
        {
            MockGroup m = new MockGroup();
            m.Setup();
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
                if (f == card)
                {
                    found = true;
                }
            }
            Assert.IsFalse(found);

        }
    }
}
