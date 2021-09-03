using UnityEngine;



namespace Weapons
{
    public enum WeaponType
    {
        GUN,
        SUBMACHINEGUN,
        RIFFLE
    }
    public abstract class WeaponBase : MonoBehaviour
    {

        protected int _ammoAvailable;
        protected int _ammoMax;
        protected int _ammoNedded;
        protected WeaponType weaponType;
        protected AmmoType ammoType;


        public virtual void OnEnable()
        {
            UpdateAmmo();
        }

        public virtual void Shoot()
        {
            _ammoAvailable--;
            UpdateAmmo();

        }
        public virtual AmmoManager FillAmmo(AmmoManager ammo)
        {

            _ammoNedded = _ammoMax - _ammoAvailable;
            if (ammo.ammo > _ammoNedded)
            {
                _ammoAvailable += _ammoNedded;
            }

            else
            {
                _ammoAvailable += ammo.ammo;
                _ammoNedded = ammo.ammo;
            }

            ammo.AmmoAvailable(_ammoNedded);
            UpdateAmmo();

            return ammo;
        }


        public virtual void UpdateAmmo()
        {

        }



    }
    }


