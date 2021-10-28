using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public struct CustomGame
{
   public int unitEnemy;
   public int unitPlayer;
   public int map;
   public List<GameObject> unitGameobject;
  
}



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


    [Header("All Scene In Game")]
    [SerializeField] string[] allScene;


    [SerializeField]GameObject loadingScreenHUDPrefab;
    [SerializeField] GameObject[] unitPrefab;
    [SerializeField] Transform HUDParent;


    [SerializeField] Brain[] typeBrain;


    private void OnEnable()
    {

        if (instance == null) instance = this;
        else if (instance != null) Destroy(this.gameObject);
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        GameEvent.instance.playCustomGame += PlayCustomGame;
        GameEvent.instance.SaveSettingCustomGame += SaveSetting;
    }
    private void Update()
    {
       DetecScene();
    }



    CustomGame PlayCustomGame( int unitPlayer)
    {
      
        cg.unitPlayer = unitPlayer;
        StartCoroutine(LoadScene(cg.map));
        return cg;
    }

    CustomGame SaveSetting(int unitEnemy, int map)
    {
        cg.unitEnemy = unitEnemy;
        cg.map = map;
        
        return cg;
    }


    void DetecScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if(currentScene == allScene[1])
        {
            SetupStage();
        }
    }

    void SetupStage()
    {
        GameObject[] gameobject = FindObjectsOfType<GameObject>();
        List<Transform> spawnPoint= new List<Transform>();
        Transform unitParent = GameObject.FindGameObjectWithTag("UnitParent").transform;
        foreach (var allobject in gameobject)
        {
            if (allobject.transform.CompareTag("PointSpawn"))
            {
                spawnPoint.Add(allobject.transform);
                   
            }
        }

      
        if(cg.unitGameobject==null)
        {
            cg.unitGameobject = new List<GameObject>();
            int spawnPointUsed = 0;

            //spawn enemy
            for (int i = 0; i < cg.unitEnemy; i++)
            {
                GameObject unit =  Instantiate(unitPrefab[1], spawnPoint[spawnPointUsed].position, Quaternion.identity, unitParent);
              //  unit.GetComponent<UnitBrain>().typeBrain = typeBrain[1];
                spawnPointUsed++;
              
              cg.unitGameobject.Add(unit);
            }
            //spawn player
            for (int i = 0; i < cg.unitPlayer; i++)
            {
                GameObject unit = Instantiate(unitPrefab[0], spawnPoint[spawnPointUsed].position, Quaternion.identity, unitParent);
               // unit.GetComponent<UnitBrain>().typeBrain = typeBrain[0];
                spawnPointUsed++;

                cg.unitGameobject.Add(unit);
            }

        }
    }



    IEnumerator LoadScene(int number)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(allScene[number]);
        GameObject loadingScreen = Instantiate(loadingScreenHUDPrefab, HUDParent);
        loadingScreen.SetActive(false);

        while (!asyncLoad.isDone)
        {
            loadingScreen.SetActive(true);

            yield return null;
        }
        loadingScreen.SetActive(false);


        yield return null;
    }
}
