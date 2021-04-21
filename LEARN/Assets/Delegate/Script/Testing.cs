using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField]
    private Timer timer;

    private bool timeElipse;

    #region not using delegate

    /* private void Start()
     {
         timer.setTimer(1f);
     }

     private void Update()
     {
         if (!timeElipse && timer.isTimerComplite())
         {
             Debug.Log("Time Is Complite");
             timeElipse = true;
         }
     }*/

    #endregion not using delegate

    #region using delegate

    private void Start()
    {
        timer.setTimer(1f, () => { Debug.Log("Time Is Complite"); });
    }

    #endregion using delegate
}