using Newtonsoft.Json;
using System;
using System.Collections.Generic;
namespace Models
    {
    public class HolidayEvent
        {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("bunting")]
        public bool Bunting { get; set; }
        }

    public class Division
        {
        [JsonProperty("division")]
        public string Name { get; set; }

        [JsonProperty("events")]
        public List<HolidayEvent> Events { get; set; }
        }

    public class HolidayData
        {
        [JsonProperty("england-and-wales")]
        public Division EnglandAndWales { get; set; }

        [JsonProperty("scotland")]
        public Division Scotland { get; set; }

        [JsonProperty("northern-ireland")]
        public Division NorthernIreland { get; set; }
        }
    }