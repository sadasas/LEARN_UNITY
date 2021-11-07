
using System;
using UnityEngine;


[Serializable]
public struct Description
{
 [TextArea()]
 public string name,ability,skill;
 public TypeShoot typeShoot;
 public TypeUnit typeUnit;

}

//[CreateAssetMenu (fileName ="Unit Description", menuName ="Unit/Description")]
public class UnitDesrciption : MonoBehaviour
{
   public Description unitDes = new Description();
}
