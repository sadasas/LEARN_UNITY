using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegatesTes : MonoBehaviour
{
    //delegate void
    public delegate void TesDelegate();

    //member
    private TesDelegate tesDelegateFunction;

    //delegate bool
    public delegate bool TesDelegateBool(int a);

    //member
    private TesDelegateBool tesDelegateBoolFunction;

    //other delegate void
    private Action<int, float> TesInAction;

    //other delegate return
    private Func<bool> TesBoolFunc;

    private Func<int, bool> TesBoolIntFunc;

    private void Start()
    {
        //basic
        tesDelegateFunction = MyDelegatesFunction;
        tesDelegateFunction += MyDelegatesFunction2;

        //basic bool
        tesDelegateBoolFunction = MyDelegatesBool;

        //lamda expression method
        tesDelegateFunction += () => { Debug.Log("Lamda expression"); };
        tesDelegateBoolFunction += (int c) => { return c < 1; };
        TesInAction = (int a, float ff) => { Debug.Log(a + ff); };
        TesBoolFunc = () => false;
        TesBoolIntFunc = (int a) => { return a < 4; };

        //othermethod
        tesDelegateFunction += delegate () { Debug.Log("tes"); };

        //call delegate
        tesDelegateFunction();
        TesBoolFunc();
        TesInAction(1, 1);
        Debug.Log(TesBoolIntFunc(1));
        Debug.Log(tesDelegateBoolFunction(1));
        Debug.Log(tesDelegateBoolFunction(6));
    }

    private void MyDelegatesFunction()
    {
        Debug.Log("delegate");
    }

    private void MyDelegatesFunction2()
    {
        Debug.Log("delegate2");
    }

    private bool MyDelegatesBool(int c)
    {
        return c < 5;
    }
}