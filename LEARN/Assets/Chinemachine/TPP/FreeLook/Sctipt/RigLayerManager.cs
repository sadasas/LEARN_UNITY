using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

[RequireComponent(typeof(Animator))]
public class RigLayerManager : MonoBehaviour
{
    public static RigLayerManager instance;
    Animator animator;



   [SerializeField] Rig hand, weapon,bodyAim;
    bool idleWeapon;
    bool firstLook;

    int IDIsAimingToHash;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        IDIsAimingToHash = Animator.StringToHash("IsAiming");
    }
    private void Update()
    {
        if (InventoryPlayer.weaponEquip)
        {   
            if (!TPP_PlayerControl.aimPressed && !TPP_PlayerControl.shootPressed && !firstLook)
            {
                animator.Play("WeaponIdle_" + InventoryPlayer.weaponEquip.GetComponent<WeaponManager>().weaponDetail.nameWeapon);
            }

            else
            {

            }

            if (TPP_PlayerControl.aimPressed && InventoryPlayer.weaponEquip != null && !firstLook || TPP_PlayerControl.shootPressed && InventoryPlayer.weaponEquip != null && !firstLook)
            {
                animator.SetBool(IDIsAimingToHash, true);
            }
            else
            {

                animator.SetBool(IDIsAimingToHash, false);
                NotReadyShoot();
            }
        }
    }

    public bool StartLookWeapon()
    {
        animator.SetTrigger("IsLook");
        return firstLook = true;
    }

    public bool EndLookWeapon()
    {
        return firstLook = false;
    }

    public bool ReadyShoot()
    {
        return InventoryPlayer.weaponEquip.GetComponent<WeaponManager>().readyShoot = true;
    }

    bool NotReadyShoot()
    {
        return InventoryPlayer.weaponEquip.GetComponent<WeaponManager>().readyShoot = false;
    }
}
