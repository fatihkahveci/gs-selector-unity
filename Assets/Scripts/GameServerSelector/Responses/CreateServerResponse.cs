using Models.GameServerSelector.Models;
using Newtonsoft.Json;

namespace GameServerSelector.Responses
{
    public struct CreateServerResponse
    {
        [JsonProperty("server")]
        public Server Server { get; set; }
        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}