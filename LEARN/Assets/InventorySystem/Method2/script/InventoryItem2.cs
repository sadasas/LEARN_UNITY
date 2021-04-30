using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryItem2 : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public int itemID;
    private RectTransform rectTransform;
    public CanvasGroup canvasGroup;
    public Transform originSlot;

    private void Awake()
    {
        //get rect transform and canvasgroup
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //block all collision if start drag
        canvasGroup.blocksRaycasts = false;

        //make start postion before drag
        originSlot = transform.parent.transform;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //update tranform position to pointer position
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        //set transform to start position
        transform.position = originSlot.position;
    }
}