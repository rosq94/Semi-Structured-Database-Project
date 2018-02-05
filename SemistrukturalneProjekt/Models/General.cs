using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace SemistrukturalneProjekt.Models
{
    public class General
    {

        [JsonProperty(PropertyName = "adresURLZdjęcia")]
        public string AdresURLZdjęcia { get; set; }

        [JsonProperty(PropertyName = "producent")]
        public string Producent { get; set; }

        [JsonProperty(PropertyName = "cena")]
        public float Cena { get; set; }

        [JsonProperty(PropertyName = "kolor")]
        public string Kolor { get; set; }

        [JsonProperty(PropertyName = "opis")]
        public string Opis { get; set; }

        public static string[] KolorTAB = new string[] { "Biały", "Czarny", "Szary", "Czerwony", "Zielony", "Fioletowy", "Inny" };
    }
}