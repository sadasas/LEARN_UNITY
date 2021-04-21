using System;
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
        //call and set
        int[] intArray = CreateArray(1, 2);
        Debug.Log(intArray.Length + " " + intArray[0] + " " + intArray[1]);

        string[] stringArray = CreateArray("aa", "bb");
        Debug.Log(stringArray.Length + " " + stringArray[0] + " " + stringArray[1]);

        MultipleGeneric<string, int>("wdwd", 2);

        myClass<int> myc = new myClass<int>();
        myc.value = 100;
        Debug.Log(myc.value);
        myClass<string> mcy = new myClass<string>();
        mcy.value = "wahyu";
        Debug.Log(mcy.value);

        myclass<EnemyMinion> EM = new myclass<EnemyMinion>(new EnemyMinion());
    }

    //single generic
    private T[] CreateArray<T>(T firstArgument, T secondArgument)
    {
        return new T[] { firstArgument, secondArgument };
    }

    //multiple generic
    private void MultipleGeneric<T1, T2>(T1 first, T2 Second)
    {
        Debug.Log(first);
        Debug.Log(Second);
    }

    //class generic
    public class myClass<T>
    {
        public T value;
    }

    //class generic

    public class myclass<T> where T : Enemy<int>
    {
        public T value;

        public myclass(T value)
        {
            value.Damage(100);
        }
    }

    public interface Enemy<T>
    {
        void Damage(T t);
    }

    public class EnemyMinion : Enemy<int>
    {
        public void Damage(int i)
        {
            Debug.Log("EnemyMinion.Damage" + i);
        }
    }

    public class EnemyArcher : Enemy<int>
    {
        public void Damage(int i)
        {
            Debug.Log("EnemyArcher.Damage" + i);
        }
    }

    #endregion using Generic
}