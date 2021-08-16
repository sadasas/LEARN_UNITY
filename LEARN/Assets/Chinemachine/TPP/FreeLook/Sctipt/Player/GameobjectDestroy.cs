using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameobjectDestroy : MonoBehaviour
{
    [SerializeField] float timeDestroy = 3f;

    private void OnEnable()
    {
        Destroy(gameObject, timeDestroy);
    }


}
