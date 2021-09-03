using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


    public class WeaponManager : MonoBehaviour
{

    public Weapon weaponDetail;
    [SerializeField] Transform shootStart;
    [SerializeField] LayerMask objectShoot;
    [SerializeField] float distanceMissShot;
    public float _fireRate;
    public int ammoAvailable;
    [SerializeField] Canvas HUDinfo;
    GameObject HUDBullet;
    bool colapse = false;


    public bool equiped { get; set; }
    public bool readyShoot { get; set; }
   
    

    private void Update()
    {
        Shoot();
       // DisplayHUD();
    }
   
    void Shoot()
    {
        if (_fireRate > 0.0f) _fireRate -= Time.deltaTime * 1;

        if(equiped)
        {
            if(TPP_PlayerControl.reloadPressed)
            {
               // InventoryPlayer.instance.FillAmmo(weaponDetail.maxAmmo,weaponDetail.typeAmmo);
            }
            if (TPP_PlayerControl.shootPressed && _fireRate <= 0f && readyShoot && ammoAvailable > 0)
            {
                ammoAvailable--;

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

    }

    void DisplayHUD()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;

        if (equiped && !colapse)
        {
            colapse = true;
           
             HUDBullet = Instantiate(HUDinfo.gameObject, player.position +player.up*2 + transform.right *1, Quaternion.LookRotation(Camera.main.transform.forward), player);
          
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

       


            

    }

   

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 100);
    }
}
