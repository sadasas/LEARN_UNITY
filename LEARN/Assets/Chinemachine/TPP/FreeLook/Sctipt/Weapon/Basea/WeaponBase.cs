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
        public string _weaponName { get; set; }
        public bool readyShoot { get; set; }

        protected int _ammoAvailable;
        protected int _ammoMax;
        protected int _ammoNedded;
        protected WeaponType weaponType;
        protected AmmoType ammoType;


        public virtual void OnEnable()
        {

            Setup();
            readyShoot = false;
        }

        public virtual void Shoot()
        {
            _ammoAvailable--;
            Setup();
        }
        public virtual IAmmo FillAmmo(IAmmo ammo )
        {

            if(ammo as AmmoManager)
            {
                AmmoManager a = ammo as AmmoManager;
                
                if (a.ammoType != ammoType) return a;

                _ammoNedded = _ammoMax - _ammoAvailable;

                if (a.ammo > _ammoNedded)
                {
                    _ammoAvailable += _ammoNedded;
                }

                else
                {
                    _ammoAvailable += a.ammo;
                    _ammoNedded = a.ammo;
                }

            }

            ammo.AmmoAvailable(_ammoNedded);
            Setup();

            return ammo;
        }
        public abstract void Setup();
       
    }
 }


