using System;
using Newtonsoft.Json;

namespace GameServerSelector.Requests
{
    public class CreateServerRequest
    {
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

        public CreateServerRequest(string name, string ip, uint port, uint capacity, uint currentPlayerCount ,Object customData)
        {
            Name = name;
            IP = ip;
            Port = port;
            Capacity = capacity;
            CurrentPlayerCount = currentPlayerCount;
            CustomData = customData;
        }

        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    
}