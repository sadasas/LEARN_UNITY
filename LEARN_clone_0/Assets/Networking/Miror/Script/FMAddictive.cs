using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;

namespace Network.Manager
{
    public class FMAddictive : NetworkManager
    {
        public string subScene;
        public static FMAddictive instance;

        public GameObject localPlayer;
        public GameObject dd;

        [SerializeField]
        private NetworkIdentity localPlayerPrefab;

        [SerializeField]
        private Transform startPoint;

        [SerializeField]
        private GameObject serverOrClient;

        #region Network Manager

        public override void OnStartServer()
        {
            base.OnStartServer();
            serverOrClient.name = ("SERVER");
            StartCoroutine(LoadSubScene());
        }

        public override void OnServerAddPlayer(NetworkConnection conn)
        {
            localPlayer = Instantiate(localPlayerPrefab.gameObject, startPoint.position, startPoint.rotation);
            dd = localPlayer;
            localPlayer.name = $"{playerPrefab.name} [connId={conn.connectionId}]";
            NetworkServer.AddPlayerForConnection(conn, localPlayer);
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

        public override void OnClientSceneChanged(NetworkConnection conn)
        {
            SceneManager.MoveGameObjectToScene(dd, SceneManager.GetSceneByName(subScene));
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

        #endregion MonoBehaviour

        private IEnumerator LoadSubScene()
        {
            yield return SceneManager.LoadSceneAsync(subScene, LoadSceneMode.Additive);
        }

        private IEnumerator UnloadScene()
        {
            yield return SceneManager.LoadSceneAsync(subScene, LoadSceneMode.Additive);
        }
    }
}