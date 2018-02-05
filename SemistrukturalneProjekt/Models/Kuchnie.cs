using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SemistrukturalneProjekt.Models
{
    public class Kuchnie
    {
        public General Generals { get; set; }

        [JsonProperty(PropertyName = "szerokość")]
        public float Szerokość { get; set; }

        [JsonProperty(PropertyName = "rodzajPiekarnika")]
        public string RodzajPiekarnika { get; set; }

        [JsonProperty(PropertyName = "rodzajPłytyGrzewczej")]
        public string RodzajPłytyGrzewczej { get; set; }

        [JsonProperty(PropertyName = "rodzaj")]
        public string Rodzaj = "Kuchnia";

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        public static string[] rodzajPiekarnikaTAB = new string[] { "Elektryczny", "Gazowy", "Gazowy z opiekaczem elektrycznym" };
        public static string[] rodzajPłytyGrzewczejTAB = new string[] { "Gazowa", "Elektryczna", "Ceramiczna", "Indukcyjna" };
    }
}