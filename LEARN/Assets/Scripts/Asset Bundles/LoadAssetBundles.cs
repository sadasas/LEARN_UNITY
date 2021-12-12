using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadAssetBundles 
{

    public AssetBundle carBundle;


    public bool LoadAssetBundle(string path)
    {
        carBundle = AssetBundle.LoadFromFile(path);
        return AssetBundleLoadResult.Success != null ? true : false;
    }

    public GameObject LoadObjectFromBundle(string name)
    {
        return carBundle.LoadAsset(name) as GameObject;
    }
}
