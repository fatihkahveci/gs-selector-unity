using System.Collections.Generic;
using Models.GameServerSelector.Models;
using Newtonsoft.Json;


namespace GameServerSelector.Responses
{
    public struct ServerListResponse
    {
        [JsonProperty("list")]
        public List<Server> ServerList { get; set; }
        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}