using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigLayerManager : MonoBehaviour
{
    Animator rigLayerAnimControll;

    int IDAimingToHash;


    private void Awake()
    {
        rigLayerAnimControll = GetComponent<Animator>();
        IDAimingToHash = Animator.StringToHash("Aiming");
    }

    private void Update()
    {
        CheckEquipment();

        if (CheckEquipment() &&!CameraSwitch.aimPressed && !Shooting.shoot)
        {

            rigLayerAnimControll.Play("WeaponIdle_" + InventoryPlayer.instance.weaponEquip.GetComponent<WeaponManager>().weaponDetail.nameWeapon);
        }

        if (CheckEquipment() && Shooting.shoot || CameraSwitch.aimPressed)
        {
           
          
            rigLayerAnimControll.SetBool(IDAimingToHash, true);
           
        }
        else
        {
            rigLayerAnimControll.SetBool(IDAimingToHash, false);
        }
       
      



    }

    
     bool CheckEquipment()
    {
        if (InventoryPlayer.instance.weaponEquip != null)
        {

           
        }
        else
        {
            
        }

        return InventoryPlayer.instance.weaponEquip;
    }
}
