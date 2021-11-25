using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  store object selected and object prefab , generate grid, inisiate object 
/// </summary>
public class GameManager : MonoBehaviour
{  
    //singleton
    public static GameManager instance;

    //trigger game pause or not
    public bool gamePlay;
    public  float time;


    GridManager gridManager;

    //all cubic prefab
    [SerializeField] Cubic cubic;
    //all resource player have
    [SerializeField] requirment resources;

    //current cubic selected
    public Cubic currentCubic = null;


    private void Awake()
    {
        if(instance !=null)
        {
            Destroy(gameObject);
        }

        instance = this;
    }

    private void Start()
    {
        gridManager = GetComponent<GridManager>();


        Cursor.lockState = CursorLockMode.None;
        //set grid
        gridManager.SetGrid();

       
    }

    private void Update()
    {
        // InstanceCubic();
        // Validate();
        time++;
    }


    
    public bool CheckAvailable(requirment req)
    {
        //check resource have requirment or not
        if (resources.electricity >= req.electricity) return true;
        return false;
    }



    Cubic InstanceCubic()
    {
        if (currentCubic == null)
        {
            Debug.Log("Spawn");
           
            currentCubic = Instantiate(cubic);
        }
        

        return currentCubic;
    }

  /*  private void Validate()
    {
        // get all tile
        foreach (Transform item in gridManager.allTile)
        {
            *//*Debug.DrawRay(item.transform.position - transform.up * 2, item.transform.up, Color.red);
            Debug.Log(gridManager.allTile.Length);*//*

            //check tile have object or not
            RaycastHit hit;
            if(!Physics.Raycast(item.transform.position - transform.up * 1,item.transform.up ,out hit,5f))
            {
                Debug.Log("not have object");
                Cubic newCubic = Instantiate(cubic);
                newCubic.SetPos(item);
                break;
       
            }

            
        }
        
    }*/
}
