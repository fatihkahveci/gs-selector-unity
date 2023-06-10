using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Models.GameServerSelector.Models;
using Newtonsoft.Json;
using GameServerSelector.Requests;
using GameServerSelector.Responses;


namespace GameServerSelector
{
    public class ServerListManager
    {
        private readonly string _apiUrl;
        
        public ServerListManager(string apiUrl) {
            _apiUrl = apiUrl;
        }
        
        public async Task<Server> CreateServer(CancellationToken token, CreateServerRequest request)
        {
            TaskCompletionSource<Server> tcs = new();
            using (var client = new HttpClient())
            {
                var content = new StringContent(request.ToJsonString(), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(_apiUrl + "/server/create", content, token).ConfigureAwait(false);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(string.Format("The request returned with HTTP status code {0}",
                        response.StatusCode));
                }
                var jsonString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Server>(jsonString);
                var status = tcs.TrySetResult(result);
            }
            return tcs.Task.Result;
        }
        
        public async Task<Server> UpdateServer(CancellationToken token, UpdateServerRequest request)
        {
            TaskCompletionSource<Server> tcs = new();
            using (var client = new HttpClient())
            {
                var content = new StringContent(request.ToJsonString(), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(_apiUrl + "/server/update/"+ request.ID, content, token).ConfigureAwait(false);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(string.Format("The request returned with HTTP status code {0}",
                        response.StatusCode));
                }
                var jsonString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Server>(jsonString);
                var status = tcs.TrySetResult(result);
            }
            return tcs.Task.Result;
        }
    
        public async Task<ServerListResponse> ServerList(CancellationToken token)
        {
            TaskCompletionSource<ServerListResponse> tcs = new();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(_apiUrl + "/server/list", token).ConfigureAwait(false);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(string.Format("The request returned with HTTP status code {0}",
                        response.StatusCode));
                }

                var jsonString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ServerListResponse>(jsonString);
                var status = tcs.TrySetResult(result);
            }
            return tcs.Task.Result;
        }
        public async Task<ServerListResponse> SearchServer(CancellationToken token, SearchServerRequest request) {
            
            TaskCompletionSource<ServerListResponse> tcs = new();
            using (var client = new HttpClient())
            {
                var content = new StringContent(request.ToJsonString(), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(_apiUrl + "/server/search", content, token).ConfigureAwait(false);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(string.Format("The request returned with HTTP status code {0}",
                        response.StatusCode));
                }
                var jsonString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ServerListResponse>(jsonString);
                var status = tcs.TrySetResult(result);
            }
            return tcs.Task.Result;

        }
    }
    
}


