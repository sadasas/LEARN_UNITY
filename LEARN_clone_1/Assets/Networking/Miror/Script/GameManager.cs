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
    public string nextScene;

    private void Awake()
    {
        instance = this;
    }
}