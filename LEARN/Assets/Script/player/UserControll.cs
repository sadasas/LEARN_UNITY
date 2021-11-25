using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// change position object selected , mouse input track, placed object selected in current mouse position
/// </summary>
/// 
/// Note : Refaktor

public class UserControll : MonoBehaviour
{

    public static UserControll instance;


    Vector3 mousePos;
    public static bool gamePause;
    Tile currentTile;
    Cubic currentObject;


    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if (currentObject != null && GameManager.instance.gamePlay && currentTile != null)
        {
            Destroy(currentObject.gameObject);
            currentObject = null;
            currentTile.Hover(false);
            currentTile = null;
        }
        DetectMouse();
        RotateObject();
    }

    Vector3 DetectMouse()
    {
        
        
        //get current object selected
        currentObject = GameManager.instance.currentCubic;
        if (currentObject == null) return Vector3.zero;
        //calculate ray
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        { 
            //get current cubic selected
           
            // store mouse position 
            mousePos = new Vector3 ( hit.point.x,hit.point.y + 2,hit.point.z);
            DropCubic();
            //set hover to default color
            if (currentTile != null) currentTile.Hover(false);

            if (hit.collider.CompareTag("Ground"))
            {
               //change transparency current object to default 
                currentObject.Changetransparency(1f);

                //get tile component
                currentTile = hit.transform.gameObject.GetComponent<Tile>();
                //set hover
                currentTile.Hover(true);
                // Debug.Log(hit.transform.tag);

                //if player placed building check is valid or not
                if (!currentTile.Full())
                {
                    //Debug.Log("drop");

                    //currentObject.Changetransparency(1f);

                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        Vector3 pos = new Vector3(hit.transform.gameObject.transform.position.x, hit.transform.gameObject.transform.position.y+0.5f, hit.transform.gameObject.transform.position.z);
                        currentObject.SetPos(pos);
                        //enable collider 
                        currentObject.gameObject.GetComponent<Collider>().enabled = true;

                        //destroy selected object
                        GameManager.instance.currentCubic=null;
                    }

                }
               

            }
            else if (hit.collider.CompareTag("Building"))
            {
                //change transparency current object to more transparency 
                currentObject.Changetransparency(0.3f);
  
            }


        }
       // Debug.Log(mousePos);
        return mousePos;
    }

    public void DragMouse(Cubic selected)
    {
        if (currentObject != null) return;
        if (currentTile != null) currentTile.Hover(false);
       
        currentObject = selected;
        currentObject.gameObject.GetComponent<Collider>().enabled = false;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit))
        {
            if(hit.collider.CompareTag("Ground"))
            {
                Vector3 fixPos = new Vector3(hit.transform.gameObject.transform.position.x, selected.transform.position.y, hit.transform.gameObject.transform.position.z);
                mousePos = fixPos;
                DropCubic();
            }
        }
    }

   public void EndDrag(Cubic selected)
    {
        selected.gameObject.GetComponent<Collider>().enabled = true;
    }
    Cubic DropCubic()
    {
        
        //check if not have selected cubic 
        if (currentObject == null) return currentObject;
        //disable collider when object being selected
        currentObject.gameObject.GetComponent<Collider>().enabled = false;
        //transfom cubic to mouse position
        currentObject.SetPos(mousePos);

        return currentObject;
    }


    void RotateObject()
    {
        if (currentObject == null) return;
      
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //Debug.Log("rotate");
            currentObject.gameObject.transform.Rotate(Vector3.left, 90f);
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentObject.gameObject.transform.Rotate(Vector3.right, 90f);
        }

    }
}
