using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    Transform mainCamera;

    [SerializeField] LayerMask objectHit;
    [SerializeField] GameObject bulletPrefab;
   // [SerializeField] Transform pointShoot;
    [SerializeField] Transform bulletParent;
    [SerializeField] float bulletMissDisntance;



    private void Start()
    {
        mainCamera = Camera.main.transform;   
    }
    private void Update()
    {

        bool shootPressed = Input.GetKeyDown(KeyCode.Mouse0);

        if (shootPressed)
        {
            ChangeDirPlayer();
            StartShoot();
        }
        
    }

    void ChangeDirPlayer()
    {
        transform.rotation = Quaternion.Euler(0, mainCamera.eulerAngles.y, 0);
    }
  void  StartShoot()
    {
        if (InventoryPlayer.instance.weaponEquip == null) return;
        Transform direction = InventoryPlayer.instance.weaponEquip.transform;

        GameObject bullet = Instantiate(bulletPrefab, direction.position, Quaternion.identity,bulletParent);
        BulletController bl = bullet.GetComponent<BulletController>();
        RaycastHit hit;
        if(Physics.Raycast(direction.position,direction.position + direction.forward,out hit, Mathf.Infinity,objectHit))
        {

            bl.hit = true;
            bl.target = hit.point;
        }

        else
        {
            bl.hit = false;
            bl.target = direction.position + direction.forward * bulletMissDisntance;
        }

        #region using Camera Forward
        /*  GameObject bullet = Instantiate(bulletPrefab, pointShoot.position, bulletPrefab.transform.rotation, bulletParent);
          BulletController bl = bullet.GetComponent<BulletController>();
          RaycastHit hit;
          if(Physics.Raycast(mainCamera.position,mainCamera.transform.forward,out hit,Mathf.Infinity,objectHit))
          {

              bl.hit = true;
              bl.target = hit.point;
          }

          else
          {
              bl.hit = false;
              bl.target =mainCamera.transform.position+ mainCamera.transform.forward * bulletMissDisntance;
          }*/
        #endregion
    }

    private void OnDrawGizmos()
    {
        Transform direction = InventoryPlayer.instance.weaponEquip.transform;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(direction.position, direction.position + direction.forward * 10);
    }

}



