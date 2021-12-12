
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

public class AddressablesManager 
{
  public AsyncOperationHandle<IList<IResourceLocation>> handle;

    #region Load Asset using ienumerator
    public IEnumerator LoadAssetsAsync<T>(string label, List<T> list, System.Type type)
    {
        yield return null;
        handle = Addressables.LoadResourceLocationsAsync(label, type);
        yield return handle;
       

    }

    public IEnumerator LoadAssetsAsync<T>(IResourceLocation resourceLocation, List<T> list)
    {
        var handle = Addressables.LoadAssetAsync<T>(resourceLocation);
        yield return handle;
        list.Add(handle.Result);
    }

    #endregion

    public void LoadAsset()
    {
        Addressables.LoadAssetAsync<GameObject>("dd").Completed += OnLoadDone;
    }

    public void OnLoadDone(AsyncOperationHandle<GameObject> obj)
    {

    }
    public void ReleaseOperation()
    {
        Addressables.Release(handle);
    }
}
