
using System;
using System.Collections.ObjectModel;
using BasicNavigation;
using FlashCards;
using FlashCards.Model;
using Newtonsoft.Json;

public class Group : BindableModelBase
{
    [JsonProperty(PropertyName = "id")]
    public string ID { get; set; } = "Test";
    public string User { get; set; } = "User";
    public ObservableCollection<FlashCard> Cards { get; set; }
    

    public void Setup()
    {
        Cards = new ObservableCollection<FlashCard>() // just mock data for first time run
            {
                new FlashCard("Example Question", "Example Answer","soft262"),
                new FlashCard("Example Question", "Example Answer","soft262"),
                new FlashCard("Example Question", "Example Answer","prco204"),
                new FlashCard("Example Question", "Example Answer","net206"),
                new FlashCard("Example Question", "Example Answer","prco204"),
                new FlashCard("Example Question", "Example Answer","exam net206"),
                new FlashCard("Example Question", "Example Answer","Test")
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
