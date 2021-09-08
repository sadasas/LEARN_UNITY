
using UnityEngine;
using Weapons;

public class StandarWeaponManager : WeaponBase
{
    [SerializeField] Weapon weaponDetail;

    //desc
    int ammoAvailable;
    float _fireRate;
   
    //shoot
    [SerializeField] LayerMask objectShoot;
    [SerializeField] Transform shootStart;
    [SerializeField] float distanceMissShot;

    //current ammo used
    int itemSlotID = -1;
    AmmoManager currentAmmoUsed;

    public override void OnEnable()
    {
        base.OnEnable();
        //subscribe
        GameEvents.instance.reloadPressed += SearchAmmo;
        GameEvents.instance.shootPressed += Shoot;
    }
    private void OnDestroy()
    {   //unsube
        GameEvents.instance.reloadPressed -= SearchAmmo;
        GameEvents.instance.shootPressed -= Shoot;
    }

    public override void Shoot()
    {
        if (_fireRate > 0.0f) _fireRate -= Time.deltaTime * 1;

        if (_ammoAvailable > 0 && _fireRate <= 0f )
        {
            if (!readyShoot) return;
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

    public override void Setup()
    {
        _ammoMax = weaponDetail.maxAmmo;
        ammoType = weaponDetail.typeAmmo;
        ammoAvailable = _ammoAvailable;
        _weaponName = weaponDetail.nameWeapon;

    }

    void SearchAmmo()
    {
        Debug.Log("search ammo");

        if (currentAmmoUsed != null)
        {
            if (currentAmmoUsed.ammo > 0)
            {
                FillAmmo(currentAmmoUsed);

                currentAmmoUsed.UpdateAmmo(itemSlotID);
                return;
            }
        }

        foreach (ItemSlot item in Inventory.instance.itemContainer._itemSlot)
        {
            if (item.quantity > 0)
            {

                if (item.itemType == ItemType.AMMO)
                {

                    if (item.item.itemSprite.GetComponent<AmmoManager>().ammoType == weaponDetail.typeAmmo)
                    {

                        currentAmmoUsed = item.item.itemSprite.GetComponent<AmmoManager>();
                        FillAmmo(currentAmmoUsed);
                        itemSlotID = item.ID;
                        currentAmmoUsed.UpdateAmmo(itemSlotID);
                        return;

                    }
                }
            }

        }

    }

    private void Update()
    {
        Debug.Log("Weapon" + ammoAvailable);  

    }
}
    /*void DisplayHUD()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;

        if (equiped && !colapse)
        {
            colapse = true;

            HUDBullet = Instantiate(HUDinfo.gameObject, player.position + player.up * 2 + transform.right * 1, Quaternion.LookRotation(Camera.main.transform.forward), player);

        }

        if (HUDBullet != null)
        {
            HUDBullet.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
            HUDBullet.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = ammoAvailable.ToString();
            HUDBullet.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = weaponDetail.nameWeapon;
            HUDBullet.transform.GetChild(0).GetChild(4).GetComponent<TextMeshProUGUI>().text = weaponDetail.typeAmmo.ToString();
            if (TPP_PlayerControl.movePlayer)
            {
                HUDBullet.SetActive(false);
            }
            else
            {
                HUDBullet.SetActive(true);
            }
        }


    }*/


