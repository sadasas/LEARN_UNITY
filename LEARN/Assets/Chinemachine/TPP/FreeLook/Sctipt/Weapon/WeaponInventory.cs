using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponInventory : MonoBehaviour,IBeginDragHandler, IDragHandler,IEndDragHandler
{
    RectTransform rectTransform;
    CanvasGroup canvasGroup;

    public int ID;
    public  Transform originalPos;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        originalPos = transform.parent;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(transform.parent.parent.parent.parent);
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(originalPos);
        transform.localPosition = Vector3.zero;
        canvasGroup.blocksRaycasts = true;
    }
}
