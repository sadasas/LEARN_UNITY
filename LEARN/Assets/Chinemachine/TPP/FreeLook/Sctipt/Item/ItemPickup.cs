
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] ItemSlotScriptableObject itemSlot;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {

            Inventory.instance.itemContainer.AddItemSlot(itemSlot.itemSlot);
            Destroy(gameObject);
        }
    }

}
