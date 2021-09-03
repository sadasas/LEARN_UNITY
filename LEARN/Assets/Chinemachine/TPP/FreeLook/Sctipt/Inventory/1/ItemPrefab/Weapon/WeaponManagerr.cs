using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;





public class WeaponManagerr : WeaponBase
    {
       
      
        [SerializeField] Weapon weaponDetail;

        int ammoAvailable;
        float _fireRate;
        [SerializeField] LayerMask objectShoot;
        [SerializeField] Transform shootStart;
        [SerializeField] float distanceMissShot;
    
        //ammo
        int itemSlotID =-1;
        AmmoManager currentAmmoUsed;




        public override void OnEnable()
        {
            base.OnEnable();
        }

        public override void Shoot()
        {
        if (_fireRate > 0.0f) _fireRate -= Time.deltaTime * 1;

        if(_ammoAvailable>0 && _fireRate<=0f)
        {
            base.Shoot();
            Debug.Log("shot");
            _fireRate = weaponDetail.fireRate;
            GameObject bullet = Instantiate(weaponDetail.bulletPrefab, shootStart.position, Quaternion.identity);
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, objectShoot))
            {
                bullet.GetComponent<BulletController>().target = hit.point;
                bullet.GetComponent<BulletController>().hit = true;
                bullet.GetComponent<BulletController>().speed = weaponDetail.speed;
                bullet.GetComponent<BulletController>().bulletDecal = weaponDetail.bulletDecal;
            }

            else
            {
                bullet.GetComponent<BulletController>().target = shootStart.position + shootStart.forward * distanceMissShot;
                bullet.GetComponent<BulletController>().hit = false;
                bullet.GetComponent<BulletController>().speed = weaponDetail.speed;
                bullet.GetComponent<BulletController>().bulletDecal = weaponDetail.bulletDecal;
            }


        }

    }

        public override AmmoManager FillAmmo(AmmoManager ammo)
        {
            if(ammo.ammoType == ammoType) base.FillAmmo(ammo);
            return ammo;
        }

        public override void UpdateAmmo()
        {
            _ammoMax = weaponDetail.maxAmmo;
            ammoType = weaponDetail.typeAmmo;
            ammoAvailable = _ammoAvailable;
           
        }

    bool SearchAmmo()
    {
       
        if(currentAmmoUsed!=null)
        {
            if (currentAmmoUsed.ammo > 0)
            {
                FillAmmo(currentAmmoUsed);
               
                currentAmmoUsed.UpdateAmmo(itemSlotID);
                Debug.Log(" use last  Ammo");
                return true;
            }
        }
      
            foreach (itemSlot item in Inventory.instance.itemContainer._itemSlot)
            {
                if (item.quantity > 0)
                {

                    if (item.itemType == ItemType.AMMO)
                    {

                        if (item.item.itemSprite.GetComponent<AmmoManager>().ammoType == weaponDetail.typeAmmo)
                        {
                            Debug.Log(" Have Ammo");

                            currentAmmoUsed = item.item.itemSprite.GetComponent<AmmoManager>();
                            FillAmmo(currentAmmoUsed);
                            itemSlotID = item.ID;
                            currentAmmoUsed.UpdateAmmo(itemSlotID);
                            return true;
                        }
                    }
                }

            }
        
        Debug.Log("Not Have Ammo");
        return false;
    }

    private void Update()
    {
        if (TPP_PlayerControl.reloadPressed) SearchAmmo();
        if (TPP_PlayerControl.shootPressed) Shoot();
        Debug.Log("Weapon"+ammoAvailable);
      
    }

}


