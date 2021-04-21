using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float time;
    private Action TimerCallback;

    #region not using delegate

    /*  public void setTimer(float t)
      {
          time = t;
      }

      private void Update()
      {
          time -= Time.deltaTime;
      }

      public bool isTimerComplite()
      {
          return time <= 0;
      }*/

    #endregion not using delegate

    #region using delegate

    public void setTimer(float t, Action tc)
    {
        this.time = t;
        this.TimerCallback = tc;
    }

    private void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            if (isTimeComplite())
            {
                TimerCallback();
            }
        }
    }

    public bool isTimeComplite()
    {
        return time <= 0;
    }

    #endregion using delegate
}