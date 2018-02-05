using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;


namespace SemistrukturalneProjekt.Models
{
    public class Counter
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "czyIstniejeLicznik")]
        public bool CzyIstniejeLicznik { get; set; }

        [JsonProperty(PropertyName = "kuchnieCount")]
        public int KuchnieCount { get; set; }

        [JsonProperty(PropertyName = "lodówkiCount")]
        public int LodówkiCount { get; set; }

        [JsonProperty(PropertyName = "mikseryCount")]
        public int MikseryCount { get; set; }

        [JsonProperty(PropertyName = "pralko_suszarkiCount")]
        public int Pralko_SuszarkiCount { get; set; }

        [JsonProperty(PropertyName = "wirówkiCount")]
        public int WirówkiCount { get; set; }

        [JsonProperty(PropertyName = "zamrażarkiCount")]
        public int ZamrażarkiCount { get; set; }


    }
}