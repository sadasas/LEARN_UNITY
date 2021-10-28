using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShowItemNode : Node
{

    /* ;

       public ShowItemNode(UnitInventory unitInventory,Transform HUDParent,GameObject HUDItemShowPrefab, Item item)
       {
           this._item = item;
           this._unitInventory = unitInventory;
           this._HUDparent = HUDParent;
           this._HUDItemShowPrefab = HUDItemShowPrefab;
       }
       public override NodeStat Evaluate()
       {
           ShowPopupItem();
           return NodeStat.RUNNING;
       }*/
    public override NodeStat Evaluate()
    {
       // ShowPopupItem();
        return NodeStat.RUNNING;
    }


}
