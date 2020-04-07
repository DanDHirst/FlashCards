using FlashCards.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlashCards.EditFlashCardPage
{
    interface IEditFlashCard
    {
        void EditFlashCard(FlashCard oldCard , FlashCard newCard);
    }
}
