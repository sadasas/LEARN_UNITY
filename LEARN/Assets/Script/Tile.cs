using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

/// <summary>
/// validate tile are full or not
/// </summary>
public class Tile : MonoBehaviour
{
    [SerializeField] LayerMask layer;
    [SerializeField] float maxDistane;
    [SerializeField] Color colorHover,colorBasic;



    Renderer tileRenderer;

    private void Start()
    {
        tileRenderer = GetComponent<Renderer>();
    }

    public bool Full()
    {
        
        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.up,out hit,maxDistane, layer))
        {
            if(hit.collider.CompareTag("Building"))
            {
                //Debug.Log("full");
                return true;
            }
        }
       // Debug.Log("empty");
        return false;
    }

    public void Hover(bool mm)
    {
        
        if(mm)
        {
            //Debug.Log("change color");
            tileRenderer.material.SetColor("_Color", colorHover);
        }

        else
        {
            //Debug.Log("change color");
            tileRenderer.material.SetColor("_Color", colorBasic);
        }
           
        
    }


}
