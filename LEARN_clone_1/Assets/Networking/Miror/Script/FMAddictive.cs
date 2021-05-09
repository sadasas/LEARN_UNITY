using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;

namespace Network.Manager
{
    public class FMAddictive : NetworkManager
    {
        public static FMAddictive instance;

        private bool colapse = false;

        public GameObject localPlayer, serverOrClient;

        [SerializeField]
        private NetworkIdentity localPlayerPrefab;

        [SerializeField]
        private Transform startPoint;

        public string nextScene;

        #region Network Manager

        public override void OnStartServer()
        {
            base.OnStartServer();
            serverOrClient.name = ("SERVER");
        }

        public override void OnServerAddPlayer(NetworkConnection conn)
        {
        }

        public override void OnClientConnect(NetworkConnection conn)
        {
            Debug.Log("Player Connected");
            base.OnClientConnect(conn);
        }

        public override void OnStopServer()
        {
            base.OnStopServer();
        }

        public override void ServerChangeScene(string newSceneName)
        {
            base.ServerChangeScene(newSceneName);
            OnServerSceneChanged(newSceneName);
        }

        public override void OnServerSceneChanged(string sceneName)
        {
            base.OnServerSceneChanged(sceneName);
            Debug.Log("after scene changed");
        }

        public override void OnServerReady(NetworkConnection conn)
        {
            localPlayer = Instantiate(localPlayerPrefab.gameObject, transform.position, Quaternion.identity);

            localPlayer.name = $"{playerPrefab.name} [connId={conn.connectionId}]";
            NetworkServer.AddPlayerForConnection(conn, localPlayer);
            base.OnServerReady(conn);
        }

        public override void OnClientSceneChanged(NetworkConnection conn)
        {
            base.OnClientSceneChanged(conn);
        }

        #endregion Network Manager

        #region MonoBehaviour

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
        }

        private void Update()
        {
            if (numPlayers >= 1)
            {
                if (!colapse)
                {
                    colapse = true;
                    ServerChangeScene(nextScene);
                }
            }
        }

        #endregion MonoBehaviour

        private void NextScene()
        {
            SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Additive);
            SceneManager.MoveGameObjectToScene(localPlayer, SceneManager.GetSceneByName(nextScene));
        }
    }
}