using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



/*
 * 
NOTE : ANOYING SINGLETON

*/
/*
 * 
 TODO : - Refaktor
        - MAKE LOADING SCENE LOOK SMOOTH AND HAVE A PERSENTAGE WAITING TIME
 
 */
public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;


    CustomGame cg = new CustomGame();


    [SerializeField] ResourceHandler resource;
    [SerializeField]  Transform HUDParent;

    //setup stage
    List<Transform> spawnPoint;
    Transform unitParent;


    private void OnEnable()
    {

        if (instance == null) instance = this;
        else if (instance != null) Destroy(this.gameObject);
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {

        //custom game
        //GameEvent.instance.playCustomGame += PlayCustomGame;
       GameEvent.instance.SaveSettingCustomGame += PlayCustomGame;
    }
  


    #region Custom Game
    CustomGame PlayCustomGame(CustomGame customGame)
    {
      
        cg.player.unitPlayer =  1;
        cg.player.typeUnit = customGame.player.typeUnit;
        cg.player.typeShoot =  customGame.player.typeShoot;
        cg.map = customGame.map;
        cg.ai.unitEnemy = customGame.ai.unitEnemy;
        cg.ai.typeShoot = customGame.ai.typeShoot;
        StartCoroutine(LoadScene(cg.map));
        return cg;
    }

    CustomGame SaveSetting(int unitEnemy, int map)
    {
        cg.ai.unitEnemy = unitEnemy;
        cg.map = map;
        
        return cg;
    }
    #endregion

  

    #region Setup Stage
    void SetupStage()
    {
      

        GameObject[] gameobject = FindObjectsOfType<GameObject>();
         spawnPoint= new List<Transform>();
        unitParent = GameObject.FindGameObjectWithTag("UnitParent").transform;
        foreach (var allobject in gameobject)
        {
            if (allobject.transform.CompareTag("PointSpawn"))
            {
                spawnPoint.Add(allobject.transform);
                   
            }
        }
        SpawnUnit();

    }

    void SpawnUnit()
    {
        if (cg.unitGameobject == null)
        {
            cg.unitGameobject = new List<GameObject>();
            int spawnPointUsed = 0;
            
            //spawn enemy
            for (int i = 0; i < cg.ai.unitEnemy; i++)
            {
               int typeShoot = 0;
                switch ( cg.ai.typeShoot[i])
                {
                    case TypeShoot.NORMAL:
                        typeShoot = 0;
                        break;
                    case TypeShoot.SNIPER:
                        typeShoot = 1;
                        break;
                }
                GameObject unit = Instantiate(resource.unitAIPrefab[0], spawnPoint[spawnPointUsed].position, Quaternion.identity, unitParent);
                unit.gameObject.GetComponent<AIBrain>().brain = resource.typeBrain[typeShoot];
                spawnPointUsed++;

                cg.unitGameobject.Add(unit);
            }
            //spawn player
            for (int i = 0; i < cg.player.unitPlayer; i++)
            {
                GameObject unit;
                switch (cg.player.typeUnit)
                {
                    case TypeUnit.HACKER:
                         unit = Instantiate(resource.unitPlayerPrefab[0], spawnPoint[spawnPointUsed].position, Quaternion.identity, unitParent);
                        unit.gameObject.GetComponent<PlayerBrain>().brain = resource.typeBrain[0];
                        cg.unitGameobject.Add(unit);
                        break;
                    case TypeUnit.SNIPER:
                         unit = Instantiate(resource.unitPlayerPrefab[1], spawnPoint[spawnPointUsed].position, Quaternion.identity, unitParent);
                        unit.gameObject.GetComponent<PlayerBrain>().brain = resource.typeBrain[0];
                        cg.unitGameobject.Add(unit);
                        break;
                }
               
                
                spawnPointUsed++;

               
            }

        }
    }
    #endregion

    IEnumerator LoadScene(int number)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(resource.allScene[number]);
        GameObject loadingScreen = Instantiate(resource.loadingScreenHUDPrefab, HUDParent);
        loadingScreen.SetActive(false);

        while (!asyncLoad.isDone)
        {
            loadingScreen.SetActive(true);

            yield return null;
        }
        loadingScreen.SetActive(false);

        SetupStage();
        
        yield return null;
    }
}
