using BasicNavigation;
using System;
using System.Collections.ObjectModel;
using FlashCards;
using FlashCards.Model;

public class Group : BindableModelBase
{
    public ObservableCollection<FlashCard> Cards { get; set; }

    public void Setup()
    {
        Cards = new ObservableCollection<FlashCard>()
            {
                new FlashCard("Earth", "1","soft262"),
                new FlashCard("Mercury", "2","soft262"),
                new FlashCard("Venus", "3","prco204"),
                new FlashCard("Jupiter", "3","net206"),
                new FlashCard("Mars", "4","prco204"),
                new FlashCard("Saturn", "5","exam net206"),
                new FlashCard("Pluto", "6","test")
            };
    }

    public Group()
	{
        
    }

}
