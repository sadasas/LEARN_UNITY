
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] ItemSlot _itemSlot;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {

            Inventory.instance.itemContainer.AddItemSlot(_itemSlot);
            Destroy(gameObject);
        }
    }

}
