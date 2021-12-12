using UnityEngine;

namespace NrawangStudio.Car
{
    [CreateAssetMenu(fileName = "Car Engine", menuName = "Car/Car Engine")]
    public class TypeCar : ScriptableObject
    {
        [Tooltip("Max move speed ")]
        public float moveSpeed;
        [Tooltip("Max turn angle ")]
        [Range(0, 50)]
        public float turnAngle;
        [Tooltip("used to force speed and input value")]


        public float breakForce;
        [Tooltip("used to reduce speed and input value")]
        public float decelaration;
        [Tooltip("used to multiply speed and input value")]
        [Range(0, 5)]
        public float accelaration;


        private void OnValidate()
        {
            //calculate by movespeed and accelaration
            decelaration = Mathf.Clamp(decelaration, moveSpeed * accelaration / 2, moveSpeed * accelaration / 2 + moveSpeed);
        }
    }
}