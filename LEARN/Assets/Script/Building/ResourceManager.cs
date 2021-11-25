
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manage Building registered  and spawn it;
/// </summary>
public class ResourceManager : MonoBehaviour
{
    [SerializeField] List<ObjectBuilding> objectRegistered;
    [SerializeField] GameObject HUDUnitPrefab;
    [SerializeField] Transform unitParent;

    private void Start()
    {
        for (int i = 0; i <= objectRegistered.Count-1; i++)
        {
            GameObject item = Instantiate(HUDUnitPrefab, unitParent);
            item.GetComponent<Image>().sprite = objectRegistered[i].image;
        }
    }
}
