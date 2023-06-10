using System.Collections;
using System.Collections.Generic;
using Models.GameServerSelector.Models;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

namespace GameServerSelector.Example
{
    public class ServerRow : MonoBehaviour
    {
        public Text nameText;
        public Text mapText;
        public Text modeText;
        public Text ipText;
        public Text capacityText;
        public Text latencyText;

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        
        public void SetServer(Server server)
        {
            nameText.text = server.Name;
            ServerCustomData customData = JsonConvert.DeserializeObject<ServerCustomData>(server.CustomData.ToString());
            mapText.text = customData.Map;
            modeText.text = customData.GameMod;
            ipText.text = server.IP + ":" + server.Port;
            latencyText.text = "0";
            capacityText.text = server.Capacity + "/" + server.CurrentPlayerCount;

        }

        private void ConvertToListServer()
        {
            
        }
    }
    
}
