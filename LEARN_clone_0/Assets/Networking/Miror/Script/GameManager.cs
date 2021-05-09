using Mirror;
using Network.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : NetworkBehaviour
{
    public static GameManager instance;
    public string nextScene;

    private void Awake()
    {
        instance = this;
    }

    public void NextScene()
    {
        Debug.Log("client change scene");
        SceneMessage msg = new SceneMessage
        {
            sceneName = nextScene,
            sceneOperation = SceneOperation.LoadAdditive
        };

        connectionToClient.Send(msg);
    }
}