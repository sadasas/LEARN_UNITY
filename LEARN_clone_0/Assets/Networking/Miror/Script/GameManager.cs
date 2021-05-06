using Mirror;
using Network.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : NetworkBehaviour
{
    private bool colapse = false;
    public string subScene;

    private void Update()
    {
        if (FMAddictive.instance.numPlayers >= 1)
        {
            Debug.Log("add subscene");
            if (!colapse)
            {
                colapse = true;
                ClientLoadSubscene();
            }
        }
    }

    private void MovePlayer(SceneManager sn)
    {
    }

    [Server]
    private void ClientLoadSubscene()
    {
        NetworkIdentity networkIdentity = this.gameObject.GetComponent<NetworkIdentity>();
        SceneMessage message = new SceneMessage { sceneName = subScene, sceneOperation = SceneOperation.LoadAdditive };
        networkIdentity.connectionToClient.Send(message);
    }
}