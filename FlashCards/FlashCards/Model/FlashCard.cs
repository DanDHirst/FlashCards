using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace FlashCards.Model
{
    public class FlashCard
    {

        public string Question { get; set; }
            public string Answer { get; set; }

            public string Group { get; set; }
            public FlashCard(string question, string ans, string group) => (Question, Answer, Group) = (question, ans, group);

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public FlashCard()
        {
        }

        public FlashCard(FlashCard card)
        {
            this.Question = card.Question;
            this.Answer = card.Answer;
            this.Group = card.Group;
        }
    }
}
