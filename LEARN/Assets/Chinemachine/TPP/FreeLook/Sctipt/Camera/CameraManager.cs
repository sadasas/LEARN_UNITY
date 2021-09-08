using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;      

public class CameraManager : MonoBehaviour
{
    [SerializeField]  CinemachineVirtualCamera thirdPersonCamera, aimCamera;
    [SerializeField] Transform aimLook;

   
    private void Start()
    {
        GameEvents.instance.aimPressed += AimCameraSelect;
        GameEvents.instance.idle += ThirdCameraSelect;
    }
    private void Update()
    {
       
    }

    void ThirdCameraSelect()
    {
        thirdPersonCamera.Priority = 10;
        aimCamera.Priority = 9;
       
    }

    void AimCameraSelect()
    {
        thirdPersonCamera.Priority = 9;
        aimCamera.Priority = 10;
    }
}
