using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SemistrukturalneProjekt.Models
{
    public class Lodówki_Zamrażarki
    {
        public General Generals { get; set; }

        [JsonProperty(PropertyName = "wysokość")]
        public float Wysokość { get; set; }

        [JsonProperty(PropertyName = "szerokość")]
        public float Szerokość { get; set; }

        [JsonProperty(PropertyName = "moc")]
        public int Moc { get; set; }
    }

    public class Lodówki
    {
        public Lodówki_Zamrażarki Lodówki_Zamrażarki { get; set; }

        [JsonProperty(PropertyName = "pojemnośćChłodziarki")]
        public int PojemnośćChłodziarki { get; set; }

        [JsonProperty(PropertyName = "pojemnośćZamrażarki")]
        public int PojemnośćZamrażarki { get; set; }

        [JsonProperty(PropertyName = "rodzaj")]
        public string Rodzaj = "Lodówka";

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
    }
    public class Zamrażarki
    {
        public Lodówki_Zamrażarki Lodówki_Zamrażarki { get; set; }

        [JsonProperty(PropertyName = "pojemnośćZamrażarki")]
        public int PojemnośćZamrażarki { get; set; }

        [JsonProperty(PropertyName = "zasilanie")]
        public string Zasilanie { get; set; }

        [JsonProperty(PropertyName = "rodzaj")]
        public string Rodzaj = "Zamrażarka";

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        public static string[] ZasilanieTAB = new string[] { "230V", "12V", "24V", "12V-24V", "12V-230V", "24V-230V", "12V-24V-230V"};
    }
}