﻿using BasicNavigation;
using FlashCards.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ModelUnitTest.MockModel
{
    public class MockGroup : BindableModelBase
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
                new FlashCard("Pluto", "6","test")
            };
        }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public MockGroup()
        {

        }
        public override void Save()
        {

        }
    }
}
