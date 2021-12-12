using System;
using UnityEngine;

public class DecelarationAttribute : PropertyAttribute
{
    public float minValue;
    public float maxValue;
    readonly float speed;
    readonly float accelaration;
    public DecelarationAttribute(float speed, float accelaration)
    {
        this.speed = speed;
        this.accelaration = accelaration;
        calculate();
    }

    float calculate()
    {
        minValue = (accelaration * speed) / 4;
        return maxValue = minValue + 4;
    }
}
