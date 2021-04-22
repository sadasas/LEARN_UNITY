using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingList : MonoBehaviour
{
    private List<string> strings = new List<string>() { "1", "2", "3" };

    private void Start()
    {
        strings.Add("3");
        strings.AddRange(new List<string>() { "4", "5" });
        foreach (var str in strings)
        {
            Debug.Log(str);
        }

        strings.Remove("3");
    }
}