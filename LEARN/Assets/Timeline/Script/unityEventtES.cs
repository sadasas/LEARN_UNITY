using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class unityEventtES : MonoBehaviour
{
   public UnityEvent onSpaceBar;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape ))
        {
            if(onSpaceBar!=null)
            {
                onSpaceBar.Invoke();
            }
        }
    }
}
