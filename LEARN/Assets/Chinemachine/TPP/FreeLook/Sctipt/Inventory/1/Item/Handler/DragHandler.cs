using UnityEngine.EventSystems;
using UnityEngine;

public abstract class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{   
    //get component
    CanvasGroup canvasGroup;
    RectTransform rectTransform;
    protected  Transform originalPost;
  public  virtual void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
        //store this parent transform
        originalPost = transform.parent;
        
    }
    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        ///set this place to null
        originalPost.GetComponent<InventorySlot>().isFull = false;
        //set parent item drag 
        transform.SetParent(transform.parent.parent.parent);
        canvasGroup.blocksRaycasts = false;


    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        
        transform.SetParent(originalPost);
        transform.localPosition = Vector3.zero;
        canvasGroup.blocksRaycasts = true;
    }
}
