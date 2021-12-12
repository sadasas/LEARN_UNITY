
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AddressableAssets;


public class GameManager : MonoBehaviour
{
    LoadAssetBundles loadAsset = new LoadAssetBundles();
    AddressablesManager addressables =  new AddressablesManager();

    
    float a;

    [SerializeField] AssetReference objectToLoad;
   
    [SerializeField] string pathAssetBundles = "E:/clone/LEARN_UNITY/LEARN/Assets/AssetBundles/car";
    [SerializeField] string objectName = "Ferari";
    [SerializeField] string label = "Car";
    [SerializeField] List<GameObject> carAssets;
    private void Start()
    {
       
        StartCoroutine(addressables.LoadAssetsAsync<GameObject>(label, carAssets, typeof(GameObject)));
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
           
            for (int i = 0; i < addressables.handle.Result.Count; i++)
            {
                StartCoroutine(addressables.LoadAssetsAsync<GameObject>(addressables.handle.Result[i], carAssets));
            }
           // addressables.ReleaseOperation();
        }

       
    }

    
}
