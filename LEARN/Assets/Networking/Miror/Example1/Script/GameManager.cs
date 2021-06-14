using Mirror;
using Network.Manager;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : NetworkBehaviour
{
    public static GameManager instance;
    public string nextScene1;
    private bool colapse1; private NetworkIdentity id;

    private void Awake()
    {
        id = GetComponent<NetworkIdentity>();

        instance = this;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!colapse1)
            {
                colapse1 = true;
                NextScene();
            }
        }

        if (Input.GetKey(KeyCode.F))
        {
            FMAddictive.instance.StopClient();
        }
    }

    [Client]
    private void CMDClientlose()
    {
        if (!hasAuthority) return;
        SetClientLose();
    }

    [Command]
    private void SetClientLose()
    {
    }

    [Command]
    private void NextScene()
    {
        SceneManager.LoadSceneAsync(nextScene1);
        NetworkServer.SetAllClientsNotReady();
        SceneMessage msg = new SceneMessage

        {
            sceneName = nextScene1,
            sceneOperation = SceneOperation.Normal
        };

        NetworkServer.SendToAll(msg);
    }
}