using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemySetup : CustomGameManager
{
    [Header("Custom Game")]
    [SerializeField] InputField numberEnemy;
    [SerializeField] Transform typeEnemySpawn;
    [SerializeField] GameObject typeEnemyParent;
    [SerializeField] GameObject HUDParent;



    int TypeEnemySpawned, enemy;
    List<GameObject> AllTypeEnemy;
   // bool colapse = false;


    private void Start()
    {
        //check last setting
        if (gameSetup.ai.typeShoot == null) gameSetup.ai.typeShoot = new List<TypeShoot>();
        else
        {
            //Debug.Log(gameSetup.ai.typeShoot.Count);
           //if have last setting spawn and give back last setting
            for (int i = 0; i <= gameSetup.ai.typeShoot.Count-1; i++)
            {
                TypeEnemySpawned++;
                SpawnEnemyType(i+1);
            }
            
            UpdateLastEnemyType();
            ExtendTypeEnemy(true);
            numberEnemy.text = gameSetup.ai.typeShoot.Count.ToString();
        }
    }

    private void FixedUpdate()
    {
        
        DetecEnemy();
      
    }

    private void Update()
    {
       
    }

    public override void InvokeSwitchMenu(int number)
    {
        base.InvokeSwitchMenu(number);
        AllTypeEnemy.Clear();
    }

    public override void SaveSetting()
    {
        if (enemy <= gameSetup.ai.typeShoot.Count) gameSetup.ai.typeShoot.Clear();
     
        int newEnemy = enemy - gameSetup.ai.typeShoot.Count;
        for (int i = 0; i < newEnemy; i++)
        {
            Dropdown unit = AllTypeEnemy[i].transform.GetChild(1).GetComponent<Dropdown>();

            if (unit.value == 0)
            {
               // Debug.Log("add0");
                gameSetup.ai.typeShoot.Add(TypeShoot.NORMAL);
            }
            else if (unit.value == 1)
            {
               // Debug.Log("add1");
                gameSetup.ai.typeShoot.Add(TypeShoot.SNIPER);
            }
        }

        gameSetup.ai.unitEnemy = newEnemy;


         base.SaveSetting();
    }




    void DetecEnemy()
    { 

        enemy = Int32.Parse(numberEnemy.text);

        if (numberEnemy.text == string.Empty || enemy <= 0)
        {
           // colapse = false;
            ExtendTypeEnemy(false);
            if(AllTypeEnemy!=null)
            {
                foreach (var item in AllTypeEnemy)
                {
                    Destroy(item.gameObject);
                }

                AllTypeEnemy.Clear();
            }
         
            TypeEnemySpawned = 0;
            return;
        }

        if(enemy>4)
        {
            StartCoroutine(LimitEnemy());
            return;
        }
        if ( TypeEnemySpawned == enemy)
        {
            
            return;
        }

          ExtendTypeEnemy(true);

        if (AllTypeEnemy!=null)
        { 
            if(AllTypeEnemy.Count > enemy)
            {
                
                foreach (var item in AllTypeEnemy)
                {
                    Destroy(item.gameObject);
                }
                AllTypeEnemy.Clear();
                TypeEnemySpawned = 0;
            }    
            
        }



        //spawn enemy 
        for (int i = 0; i < enemy - TypeEnemySpawned; i++)
        {
            SpawnEnemyType(TypeEnemySpawned + 1);
            TypeEnemySpawned++;
           
        }

       
        
    }


    public void ExtendTypeEnemy(bool indcator)
    {

      
        if (indcator == false)
        {
            typeEnemyParent.SetActive(false);
            this.GetComponent<RectTransform>().sizeDelta = new Vector2(800, 400);
            
            
           
        }
        else if(indcator ==true)
        {
            this.GetComponent<RectTransform>().sizeDelta = new Vector2(800, 800);
            typeEnemyParent.SetActive(true);


        }
     
    }


    GameObject SpawnEnemyType(int number)
    {
        GameObject aa = Instantiate(rh.typeEnemyHUDPrefab, typeEnemySpawn);
        aa.transform.GetChild(0).GetComponent<Text>().text = "Enemy " + number;

        if (AllTypeEnemy == null) AllTypeEnemy = new List<GameObject>();

        AllTypeEnemy.Add(aa);

        return aa;
    }
    void UpdateLastEnemyType()
    {
        if (AllTypeEnemy == null || gameSetup.ai.typeShoot.Count < 1) return;

        for (int i = 0; i <= AllTypeEnemy.Count - 1; i++)
        {

            if (gameSetup.ai.typeShoot[i] == TypeShoot.NORMAL) AllTypeEnemy[i].transform.GetChild(1).GetComponent<Dropdown>().value = 0;
            else if(gameSetup.ai.typeShoot[i] == TypeShoot.SNIPER) AllTypeEnemy[i].transform.GetChild(1).GetComponent<Dropdown>().value = 1;


        }
    }

    IEnumerator LimitEnemy()
    {
      GameObject  aa =  Instantiate(rh.limitEnemyHUDPrefab, this.transform);
        numberEnemy.text = "4";
        yield return new WaitForSeconds(1);
    
      Destroy(aa);
    }
    
}
