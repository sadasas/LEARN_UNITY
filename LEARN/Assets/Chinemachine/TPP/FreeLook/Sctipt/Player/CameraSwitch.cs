using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitch : MonoBehaviour
{
  [SerializeField]  CinemachineVirtualCamera aimCamera;
  [SerializeField] Transform player;
  Transform mainCamera;
  [SerializeField] Canvas thirdPersonCanvas, aimCanvas;

   public static bool aimPressed;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   
    }
    private void Update()
    {
        mainCamera = Camera.main.transform;
        SwitchCam();
    }

    void SwitchCam()
    {
         aimPressed = Input.GetKey(KeyCode.Mouse1);

        if(aimPressed)
        {
            StartAiming();
        }

        else
        {
            aimCanvas.enabled = false;
            thirdPersonCanvas.enabled = true;
            aimCamera.Priority = 20;
        }
    }
     
    void StartAiming()
    {
        aimCanvas.enabled = true;
        thirdPersonCanvas.enabled = false;
        aimCamera.Priority = 11;

        player.rotation = Quaternion.Euler(0, mainCamera.eulerAngles.y, 0);
        

    }

}
