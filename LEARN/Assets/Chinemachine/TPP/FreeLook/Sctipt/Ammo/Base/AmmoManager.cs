
using UnityEngine;

[CreateAssetMenu(menuName = "Ammo/Ammo Manager")]
public class AmmoManager : ScriptableObject, IAmmo
{

    [SerializeField] Ammo contentsAmmo;


    public int ammo { get; set; }
    public AmmoType ammoType { get => contentsAmmo.type; }
    public int ID { get; private set; }






    public void UpdateAmmo(int _ID)
    {
        ID = _ID;
        Inventory.instance.UpdateAmmo(ID, ammo);

    }
    public void AmmoAvailable(int ammoEquiped) => ammo -= ammoEquiped;


    private void Update()
    {
        if (contentsAmmo.ammo <= 0)
        {
            Inventory.instance.DestroyItemInventory(ID);
        }

    }

    public void OnStart() => ammo = contentsAmmo.ammo;
}


