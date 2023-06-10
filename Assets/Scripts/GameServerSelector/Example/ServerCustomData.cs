using System;
using Newtonsoft.Json;

namespace GameServerSelector.Example
{
    public struct ServerCustomData
    {
        [JsonProperty("map")]
        public string Map { get; set; }
        [JsonProperty("game_mod")]
        public string GameMod { get; set; }
    }
}