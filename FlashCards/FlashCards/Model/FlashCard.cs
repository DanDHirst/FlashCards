using System;
using System.Collections.Generic;
using System.Text;

namespace FlashCards.Model
{
    public class FlashCard
    {
        private FlashCard card;

        public string Question { get; set; }
            public string Answer { get; set; }

            public string Group { get; set; }
            public FlashCard(string name, string dist, String group) => (Question, Answer, Group) = (name, dist, group);

        public FlashCard()
        {
        }

        public FlashCard(FlashCard card)
        {
            this.card = card;
        }
    }
}
