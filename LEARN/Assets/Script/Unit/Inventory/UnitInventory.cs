using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
 
MAKE AI TO MANAGE ITEM IN INVENTORY
 
 */
public class UnitInventory : Inventory
{
    [Header("Popup Item")]
    [SerializeField] Transform HUDParent;
    [SerializeField] GameObject HUDItemShowPrefab;

    private void Update()
    {
       // Debug.Log(itemInventory+ "kk" + gameObject);
    }


    public override void ShowItem(Item item)
    {
        StartCoroutine(ShowPopupItem(item));
    }

    IEnumerator ShowPopupItem(Item item)
    {
        GameObject popup = GameObject.Instantiate(HUDItemShowPrefab, HUDParent);
        Image itemImage = popup.transform.GetChild(0).GetComponent<Image>();
        itemImage.sprite = item.item.imageSprite;
        yield return new WaitForSeconds(2f);
        GameObject.Destroy(popup);
    }
}
