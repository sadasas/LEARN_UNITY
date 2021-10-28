
using UnityEngine;



public class ItemManager : MonoBehaviour
{
    [SerializeField] Item item;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.GetComponent<Inventory>()!=null)
        {
            Inventory unit = other.transform.GetComponent<Inventory>();

            unit.AddItem(item);

            Destroy(gameObject);
        }
    }
}
