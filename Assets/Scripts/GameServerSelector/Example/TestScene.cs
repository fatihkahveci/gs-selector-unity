using System.Collections.Generic;
using System.Threading;
using GameServerSelector.Requests;
using Models.GameServerSelector.Models;
using UnityEngine;


namespace GameServerSelector.Example
{
    
    public class TestScene : MonoBehaviour
    {
    
        ServerListManager _serverListManager;
        public ServerRow serverRowPrefab;
        public GameObject contentArea;

        private void Awake()
        {
            _serverListManager = new ServerListManager("http://localhost:3000/v1");
        }

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        
        }


        public List<Server> GetServerList()
        {
            return _serverListManager.ServerList(new CancellationToken()).Result.ServerList;
        }

        public void Refresh()
        {
            Debug.Log("Refreshing");
            for (int i = contentArea.transform.childCount - 1; i >= 0; i--) {
                GameObject.DestroyImmediate( contentArea.transform.GetChild( i ).gameObject );
            }
            var servers = GetServerList();
            foreach (var server in servers)
            {
                var go = Instantiate(serverRowPrefab, contentArea.transform);
                go.SetServer(server);
            }
        }

        public void SearchRanked()
        {
            Debug.Log("Searching Ranked");
            for (int i = contentArea.transform.childCount - 1; i >= 0; i--) {
                GameObject.DestroyImmediate( contentArea.transform.GetChild( i ).gameObject );
            }
            SearchServerRequest req = new SearchServerRequest().AddMatchQuery("game_mod", "ranked");
            var servers = _serverListManager.SearchServer(new CancellationToken(), req);
            foreach (var server in servers.Result.ServerList)
            {
                var go = Instantiate(serverRowPrefab, contentArea.transform);
                go.SetServer(server);
            }
        }

        public void SearchCasual()
        {
            Debug.Log("Searching Casual");
            for (int i = contentArea.transform.childCount - 1; i >= 0; i--) {
                GameObject.DestroyImmediate( contentArea.transform.GetChild( i ).gameObject );
            }
            SearchServerRequest req = new SearchServerRequest().AddMatchQuery("game_mod", "casual");
            var servers = _serverListManager.SearchServer(new CancellationToken(), req);
            foreach (var server in servers.Result.ServerList)
            {
                var go = Instantiate(serverRowPrefab, contentArea.transform);
                go.SetServer(server);
            }
        }
    }

}