
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlotUI : DragHandler
{
    public int ID;
   public Transform originalPos { get => originalPost; set => originalPost = value; }
    public override void Start()
    {
        base.Start();
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);
    }

    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
    }
    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
    }

}
