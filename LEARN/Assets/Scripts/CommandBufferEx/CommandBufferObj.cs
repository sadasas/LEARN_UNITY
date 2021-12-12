
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NrawangStudio.CommandBufferEx
{

    [ExecuteInEditMode] 
    public class CommandBufferObj : MonoBehaviour
    {
        public Material glowMaterial;

        public void OnEnable()
        {
            Debug.Log("tes");
            CustomGlowSystem.instance.Add(this);
        }

        public void Start()
        {
            CustomGlowSystem.instance.Add(this);
        }
        public void OnDisable()
        {
            CustomGlowSystem.instance.Remove(this);
        }
      
    }
}
