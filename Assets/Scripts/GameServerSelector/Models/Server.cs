using System;
using Newtonsoft.Json;

namespace Models
{
    namespace GameServerSelector.Models
    {
        public struct Server
        {
            [JsonProperty("id")]
            public string ID { get; set; }
            [JsonProperty("name")]
	        public string Name { get; set; }
	        [JsonProperty("ip")]
            public string IP { get; set; }
            [JsonProperty("port")]
            public uint Port { get; set; }
            [JsonProperty("capacity")]
            public uint Capacity { get; set; }
            [JsonProperty("current_player_count")]
            public uint CurrentPlayerCount { get; set; }
            [JsonProperty("custom_data")]
            public Object CustomData { get; set; }
            [JsonProperty("created_at")]
            public DateTime CreatedAt { get; set; }
            [JsonProperty("updated_at")]
            public DateTime UpdatedAt { get; set; }
        }
    }
}