using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using peplayon;

public class GameManagerEx2 : MonoBehaviour
{
    private void Awake()
    {
    }

    private void Update()
    {
    }

    public void Play()
    {
        NetworkManagerEx2.instance.StartClient();
        NetworkManagerEx2.instance.networkAddress = "localhost";
    }
}