using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NrawangStudio.Car
{
    public abstract class Car : MonoBehaviour
    {
        public TypeCar carEngine;

        public abstract void Movement();
    }
}