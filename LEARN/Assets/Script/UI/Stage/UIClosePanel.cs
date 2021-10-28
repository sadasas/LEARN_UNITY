
using UnityEngine;
using UnityEngine.EventSystems;



public class UIClosePanel : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Transform HUD;
    public void OnPointerClick(PointerEventData eventData)
    {
       if(eventData.button==0)
        {   if (HUD.childCount < 2) return;
          HUD.GetChild(1).gameObject.SetActive(false);
        }
    }
}
