
using UnityEngine;

public class AmmoManager :ScriptableObject,IAmmo
{

   [SerializeField] Ammo contentsAmmo;


    public int ammo { get => contentsAmmo.ammo; }
    public AmmoType ammoType { get => contentsAmmo.type; }

    
    public int ID { get; private set; }
   



    public void UpdateAmmo(int _ID)
    {
        ID = _ID;
       Inventory.instance.UpdateAmmo(ID,ammo);
   
    }
    public void AmmoAvailable(int ammoEquiped)
    {
       contentsAmmo.ammo -= ammoEquiped;
    }

    private void Update()
    {
        if (contentsAmmo.ammo <= 0)
        {
            Inventory.instance.DestroyItemInventory(ID);
           
        }


    }

}
