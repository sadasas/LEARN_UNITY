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

    bool firstLook=true;
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
        if (Inventory.weaponEquiped)
        {   
            if (!TPP_PlayerControl.aimPressed && !TPP_PlayerControl.shootPressed && !firstLook)
            {
                Debug.Log("Idle");
                animator.Play("WeaponIdle_" + Inventory.weaponEquiped.GetComponent<WeaponManager>().weaponDetail.nameWeapon);
            }
            if (TPP_PlayerControl.aimPressed && Inventory.weaponEquiped != null && !firstLook || TPP_PlayerControl.shootPressed && Inventory.weaponEquiped != null && !firstLook)
            {
                animator.SetBool(IDIsAimingToHash, true);
            }
            else
            {
                animator.SetBool(IDIsAimingToHash, false);
                NotReadyShoot();
            }
        }

        else
        {
         
            animator.SetBool(IDIsAimingToHash, false);
            animator.Rebind();
        }
    }

    public bool StartLookWeapon()
    {
        animator.Rebind();
        animator.SetTrigger("IsLook");
        return firstLook = true;
    }

    public bool EndLookWeapon()
    {
        return firstLook = false;
    }

    public void ReadyShoot()
    {
      //  Inventory.weaponEquiped.GetComponent<WeaponManagerr>().Shoot();
    }

    void NotReadyShoot()
    {
        //return Inventory.weaponEquiped.GetComponent<WeaponManager>().readyShoot = false;
    }
}
