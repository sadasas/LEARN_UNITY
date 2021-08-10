using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineControl : MonoBehaviour
{
  public PlayableDirector pd;

    public void Play()
    {
        pd.Play();
    }
}
