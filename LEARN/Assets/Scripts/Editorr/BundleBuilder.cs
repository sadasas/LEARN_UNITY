
using UnityEngine;
using UnityEditor;
using System.IO;

public class BundleBuilder : MonoBehaviour
{
    [SerializeField] static string assetBundlesDir = "Assets/AssetBundles";
 
    [MenuItem("Assets/ Build AssetBundles")]
    static void BuildAllAssetBundle()
    {
        if(!Directory.Exists(assetBundlesDir))
        {
            Directory.CreateDirectory(assetBundlesDir);
        }

        BuildPipeline.BuildAssetBundles(assetBundlesDir, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
    }
}
