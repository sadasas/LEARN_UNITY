
using UnityEngine;
using UnityEngine.Animations.Rigging;
using System;
using Weapons;
[RequireComponent(typeof(Animator))]
public class RigLayerManager : MonoBehaviour
{
    //get
    public static RigLayerManager instance;
    Animator animator;
    WeaponBase weaponEquiped;

    //animation rigging component
    [SerializeField] Rig hand, weapon, bodyAim;

    //animation
    int IDIsAimingToHash;



    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        IDIsAimingToHash = Animator.StringToHash("IsAiming");

        //subscribe events
        GameEvents.instance.reloadPressed += ReloadState;
        GameEvents.instance.aimPressed += AimState;
        GameEvents.instance.shootPressed += AimState;
        GameEvents.instance.idle += IdleState;
        GameEvents.instance.resetAnim += ResetState;

    }

    #region ANIMATION RIGGING STATE
    void AimState() => animator.SetBool(IDIsAimingToHash, true);
    void ReloadState()
    {
      
    }
    void ResetState() => animator.Rebind();
    void IdleState()
    {
        NotReadyShoot();
        animator.SetBool(IDIsAimingToHash, false);

        animator.Play("WeaponIdle_" + weaponEquiped._weaponName);

    }
    public void FirstLookState()
    {
        animator.Rebind();
        animator.SetTrigger("IsLook");
    }
    public void ReadyShoot() => weaponEquiped.readyShoot = true;
    void NotReadyShoot() => weaponEquiped.readyShoot = false;
    #endregion
    private void Update()
    {
        if (Inventory.weaponEquiped) weaponEquiped = Inventory.weaponEquiped.GetComponent<WeaponBase>();
    }
}
