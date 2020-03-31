using System;
using System.Collections.Generic;
using System.Text;

namespace FlashCards.Model
{
    public class ListOfUniqueGroups
    {
        public string Name { get; set; }

        public ListOfUniqueGroups(string Name)
        {
            this.Name = Name;
        }

        public ListOfUniqueGroups()
        {
        }
    }
}
