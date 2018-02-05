using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SemistrukturalneProjekt.Models
{
    public class Wyszukiwanie
    {
        [JsonProperty(PropertyName = "cena")]
        public float Cena { get; set; }

        [JsonProperty(PropertyName = "kolor")]
        public string Kolor { get; set; }

        [JsonProperty(PropertyName = "wybór")]
        public string Wybór { get; set; }

        public static string[] WybórTAB = new[] { "Kuchnie", "Lodówki", "Miksery","Pralko_Suszarki","Wirówki","Zamrażarki" };
        public static string[] KolorTAB = new string[] { "Biały", "Czarny", "Szary", "Czerwony", "Zielony", "Fioletowy", "Inny" };
    }
}