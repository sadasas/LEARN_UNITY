using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Database object building 
/// </summary>
[CreateAssetMenu(fileName = "object",menuName ="Unit")]
public class ObjectBuilding : ScriptableObject
{
   public Sprite image;
   public string nameObject; 
}
