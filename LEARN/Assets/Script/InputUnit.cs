using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// seleet building and check if same with last selected building
/// </summary>
public class InputUnit : MonoBehaviour
{
    [SerializeField] Cubic unit;
    public void Choose()
    {
        if(!CheckCurrentSelected())
        {
           Cubic cubic =  Instantiate(unit);
            GameManager.instance.currentCubic = cubic;
        }
    }

    bool CheckCurrentSelected()
    {
      if (GameManager.instance.currentCubic == null) return false;
        Debug.Log(GameManager.instance.currentCubic.name + "    " + unit.name);
      return  GameManager.instance.currentCubic.name == unit.name ? true : false;
    }
}
