
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (fileName ="Hacker",menuName = "Brain/Skill Brain/Hacker")]
public class Hacker : SkillBrain
{
    [SerializeField] GameObject inventoryUIPrefab, slotInventoryUIPrefab;

    public RectTransform InventoryUI { get; set; }


    //private
    Transform unit;
    RectTransform canvasRectTransform;
    UnitInventory currentInventory;
    GameObject HUD;


    public override void Starting()
    {
        HUD = GameObject.FindGameObjectWithTag("HUDStage");
        canvasRectTransform = HUD.GetComponent<RectTransform>();
    }
    public override void SkillOne()
    {
        MouseRay();

        if (InventoryUI == null) return;

        UIPost();

    }









    #region Skill one

    void UIPost()
    {
       // Debug.Log("UpdatePos");
        Vector2 viewPortPosition = Camera.main.WorldToViewportPoint(unit.position);
        viewPortPosition.x *= canvasRectTransform.sizeDelta.x;
        viewPortPosition.y *= canvasRectTransform.sizeDelta.y;

        InventoryUI.anchoredPosition = viewPortPosition;

    }

    void MouseRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Player"))
            {

                UnitInventory IPlayer = hit.collider.gameObject.GetComponent<UnitInventory>();
                DisplayInventory(IPlayer, hit.transform);


            }
        }
    }

    void DisplayInventory(UnitInventory UI, Transform hit)
    {
        if (UI.itemInventory == null) return;

        if (currentInventory != null)
        {
            InventoryUI.gameObject.SetActive(true);
            if (currentInventory.gameObject == UI.gameObject) return;
            else Destroy(InventoryUI.gameObject);
        }

        unit = hit.transform;
        currentInventory = UI;
        GameObject tt = Instantiate(inventoryUIPrefab, HUD.transform);
        InventoryUI = tt.GetComponent<RectTransform>();


        for (int i = 0; i < UI.itemInventory.Count; i++)
        {
            GameObject slotInventoryUI = Instantiate(slotInventoryUIPrefab, InventoryUI.transform);
            slotInventoryUI.GetComponent<Image>().sprite = UI.itemInventory[i].item.imageSprite;
        }

    }

    #endregion


}
