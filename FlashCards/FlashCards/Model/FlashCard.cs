using System;
using System.Collections.Generic;
using System.Text;

namespace FlashCards.Model
{
    public class FlashCard
    {
        
        
            public string Question { get; set; }
            public string Answer { get; set; }
            public FlashCard(string name, string dist) => (Question, Answer) = (name, dist);
        
    }
}
