using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Transform pivot;

    [SerializeField]
    private Transform camera;

    public float rotateSpeed, cameradistA, cameraDistB, cameraDist;
    private float xAngle, yAngle;

    private void Update()
    {
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        FollowPlayer();
        HandleRotation(h, v);
    }

    private void FollowPlayer()
    {
        float speed = Time.deltaTime * 1;
        Vector3 targetPos = Vector3.Lerp(transform.position, target.position, speed);
        transform.position = targetPos;
    }

    private void HandleRotation(float h, float v)
    {
        xAngle -= v * rotateSpeed;
        xAngle = Mathf.Clamp(xAngle, -35, 35);
        pivot.localRotation = Quaternion.Euler(xAngle, 0, 0);

        yAngle += h * rotateSpeed;
        transform.rotation = Quaternion.Euler(0, yAngle, 0);
    }

    private void LateUpdate()
    {
        camera.localPosition = new Vector3(cameradistA, cameraDistB, cameraDist);
    }
}