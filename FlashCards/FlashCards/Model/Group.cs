
using System;
using System.Collections.ObjectModel;
using BasicNavigation;
using FlashCards;
using FlashCards.Model;
using ModelUnitTest.MockModel;
using Newtonsoft.Json;

public class Group : BindableModelBase
{
    [JsonProperty(PropertyName = "id")]
    public string ID { get; set; } = "Test";
    public string User { get; set; } = "User";
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
                new FlashCard("Pluto", "6","Test")
            };
    }
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }

    public Group()
	{
        
    }

}
