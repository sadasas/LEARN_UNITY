using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CubeWithText : MonoBehaviour
{
    public int Number { get; private set; }

    public void setNumber(int number)
    {
        Number = number;
        GetComponentInChildren<TextMeshProUGUI>().SetText(number.ToString());
    }

    internal void PlayRemoval()
    {
        GetComponent<Renderer>().material.color = Color.green;
        StartCoroutine(FadeAway());
    }

    private IEnumerator FadeAway()
    {
        while (transform.localScale.x > 0)
        {
            transform.localScale = Vector3.one * (transform.localScale.x - Time.deltaTime);
            yield return null;
        }

        Destroy(gameObject);
    }
}