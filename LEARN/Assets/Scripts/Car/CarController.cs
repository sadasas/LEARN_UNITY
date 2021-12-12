using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NrawangStudio.Car
{
    /// <summary>
    /// all movement represent by rigidbody and wheel collider
    /// </summary>
    [RequireComponent(typeof(Rigidbody),typeof(Car))]
    public class CarController : MonoBehaviour
    {

        Rigidbody rb;
        Car car;
        float motor, steering;


        [SerializeField] List<AxleInfo> axleInfos;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            car = GetComponent<Car>();


        }


        private void FixedUpdate()
        {
            GetInput();
            if (motor != 0) SteerAndAccelerate();
            else if (motor == 0) Deccelerate();

        }

        void GetInput()
        {
            motor = car.carEngine.moveSpeed * car.carEngine.accelaration * Input.GetAxis("Vertical");
            steering = car.carEngine.turnAngle * Input.GetAxis("Horizontal");
        }

        void SteerAndAccelerate()
        {
            foreach (var axleInfo in axleInfos)
            {
                if (axleInfo.steering)
                {
                    axleInfo.leftWheel.steerAngle = steering;
                    axleInfo.righttWheel.steerAngle = steering;
                    axleInfo.leftWheel.brakeTorque = 0f;
                    axleInfo.righttWheel.brakeTorque = 0f;

                }
                if (axleInfo.motor)
                {
                    axleInfo.leftWheel.motorTorque = motor;
                    axleInfo.righttWheel.motorTorque = motor;
                }
                ApplyLocalPositonToVisual(axleInfo.leftWheel);
                ApplyLocalPositonToVisual(axleInfo.righttWheel);
            }
        }

        void Deccelerate()
        {
            foreach (var axleInfo in axleInfos)
            {

                if (axleInfo.motor)
                {
                    axleInfo.leftWheel.brakeTorque = car.carEngine.decelaration;
                    axleInfo.righttWheel.brakeTorque = car.carEngine.decelaration;

                }
                ApplyLocalPositonToVisual(axleInfo.leftWheel);
                ApplyLocalPositonToVisual(axleInfo.righttWheel);
            }
        }
        public void ApplyLocalPositonToVisual(WheelCollider collider)
        {
            if (collider.transform.childCount == 0) return;

            Transform visualWheel = collider.transform.GetChild(0);

            Vector3 position;
            Quaternion rotation;
            collider.GetWorldPose(out position, out rotation);

            visualWheel.transform.position = position;
            visualWheel.transform.rotation = rotation;
        }

    }

    [System.Serializable]
    public class AxleInfo
    {
        public WheelCollider leftWheel;
        public WheelCollider righttWheel;

        public bool motor;
        public bool steering;
    }
}