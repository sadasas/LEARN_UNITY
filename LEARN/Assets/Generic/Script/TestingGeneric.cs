using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingGeneric : MonoBehaviour
{
    #region without Generic

    /*private void Start()
    {
        int[] intArray = CreateArray(1, 2);
        Debug.Log(intArray.Length + " " + intArray[0] + " " + intArray[1]);

        string[] stringArray = CreateArray("aa", "bb");
        Debug.Log(stringArray.Length + " " + stringArray[0] + " " + stringArray[1]);
    }

    private int[] CreateArray(int firstArgument, int secondArgument)
    {
        return new int[] { firstArgument, secondArgument };
    }

    private string[] CreateArray(string firstArgument, string secondArgument)
    {
        return new string[] { firstArgument, secondArgument };
    }
*/

    #endregion without Generic

    #region using Generic

    private void Start()
    {
        int[] intArray = CreateArray(1, 2);
        Debug.Log(intArray.Length + " " + intArray[0] + " " + intArray[1]);

        string[] stringArray = CreateArray("aa", "bb");
        Debug.Log(stringArray.Length + " " + stringArray[0] + " " + stringArray[1]);
    }

    private T[] CreateArray<T>(T firstArgument, T secondArgument)
    {
        return new T[] { firstArgument, secondArgument };
    }

    #endregion using Generic
}