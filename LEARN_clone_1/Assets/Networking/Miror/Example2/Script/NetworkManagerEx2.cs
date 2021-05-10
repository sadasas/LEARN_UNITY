using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace peplayon
{
    public class NetworkManagerEx2 : NetworkManager
    {
        public static NetworkManagerEx2 instance;

        public GameObject localPlayerPrefab, localPlayer;

        #region Network Manager

        public override void OnStartServer()
        {
            base.OnStartServer();

            Debug.Log("SERVER ACTIVE");
        }

        public override void OnServerConnect(NetworkConnection conn)
        {
            base.OnServerConnect(conn);
        }

        public override void OnStartClient()
        {
            Debug.Log("CLIENT ACTIVE");
        }

        public override void OnServerReady(NetworkConnection conn)
        {
            base.OnServerReady(conn);
            localPlayer = Instantiate(localPlayerPrefab, localPlayerPrefab.transform.position, Quaternion.identity);
            localPlayer.name = $"{localPlayerPrefab.gameObject.name} [connId={conn.connectionId}]";
            NetworkServer.AddPlayerForConnection(conn, localPlayer);
        }

        #endregion Network Manager

        private void Awake()
        {
            instance = this;
            if (!isNetworkActive)
            {
                Debug.Log("ADD SERVER");
                StartServer();
                networkAddress = "localhost";
            }
        }
    }
}