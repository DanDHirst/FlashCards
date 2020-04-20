using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.ObjectModel;

namespace FlashCards.Model
{
    [TestClass]
    public class ModelUnitTest
    {
        [TestMethod]
        public void GroupTestProperties()
        {
            Group g = new Group();
            ObservableCollection<FlashCard> Cards = new ObservableCollection<FlashCard>()
            {
                new FlashCard("Question", "Answer","Test")
            };
            g.Cards = Cards;
            Assert.AreEqual(g.Cards, Cards); // should be equal
            Assert.IsFalse(g.Cards != Cards); // should fail/ be false

            g.ID = "Test";
            Assert.AreEqual(g.ID, "Test"); // should be equal
            Assert.IsFalse(g.ID != "Test"); // should be false

            g.User = "User";
            Assert.AreEqual(g.User, "User"); // this should be equal
            Assert.IsFalse(g.User != "User"); // should be False


        }

        [TestMethod]
        public void TestFlashCard()
        {
            FlashCard f = new FlashCard("question", "answer", "group");

            Assert.AreEqual("question", f.Question); // should be equal
            Assert.IsFalse(f.Question != "question"); // should be false

            Assert.AreEqual("answer", f.Answer); // should be equal
            Assert.IsFalse(f.Answer != "answer");  // should be false

            Assert.AreEqual("group", f.Group); // should be equal
            Assert.IsFalse(f.Group != "group");  // should be false
        }

        [TestMethod]
        public void ListOfUniqueGroupsTestProperties()
        {
            ListOfUniqueGroups L = new ListOfUniqueGroups();
            L.Name = "Test";
            Assert.AreEqual(L.Name, "Test"); // should be equal
            Assert.IsFalse(L.Name != "Test"); // should be false


        }
    }

}
