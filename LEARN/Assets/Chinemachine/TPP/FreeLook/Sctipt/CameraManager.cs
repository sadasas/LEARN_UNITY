using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;      

public class CameraManager : MonoBehaviour
{
    [SerializeField]  CinemachineVirtualCamera thirdPersonCamera, aimCamera;
    [SerializeField] Transform aimLook;

   
    private void Awake()
    {
         
    }
    private void Update()
    {
        if(TPP_PlayerControl.aimPressed && Inventory.weaponEquiped!=null)
        {
            thirdPersonCamera.Priority = 9;
            aimCamera.Priority = 10;
          
        }   

        else
        {
            thirdPersonCamera.Priority = 10;
            aimCamera.Priority = 9;
         
        }
    }
}
