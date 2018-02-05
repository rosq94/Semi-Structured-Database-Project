using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SemistrukturalneProjekt.Models
{
    public class Pralki
    {
        public General Generals { get; set; }

        [JsonProperty(PropertyName = "maxPrędkośćObrotowa")]
        public int MaxPrędkośćObrotowa { get; set; }

        [JsonProperty(PropertyName = "wielkośćZaładunku")]
        public int WielkośćZaładunku { get; set; }

        [JsonProperty(PropertyName = "moc")]
        public int Moc { get; set; }

    }
    public class Pralko_Suszarki
    {
        public Pralki Pralki { get; set; }

        [JsonProperty(PropertyName = "wysokość")]
        public float Wysokość { get; set; }

        [JsonProperty(PropertyName = "szerokość")]
        public float Szerokość { get; set; }

        [JsonProperty(PropertyName = "rodzaj")]
        public string Rodzaj = "Pralko-Suszarka";

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
    }
    public class Wirówki
    {
        public Pralki Pralki { get; set; }

        [JsonProperty(PropertyName = "rodzaj")]
        public string Rodzaj = "Wirówka";

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
    }



}