using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SemistrukturalneProjekt.Models
{
    public class Miksery
    {
        public General Generals { get; set; }

        [JsonProperty(PropertyName = "ilośćPrędkości")]
        public int IlośćPrędkości { get; set; }

        [JsonProperty(PropertyName = "moc")]
        public int Moc { get; set; }

        [JsonProperty(PropertyName = "rodzaj")]
        public string Rodzaj = "Mikser";

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        public static string[] IlośćPrędkościTAB = new string[] { "1","2","3","4","5","6","7","8","9","10" };
    }
}