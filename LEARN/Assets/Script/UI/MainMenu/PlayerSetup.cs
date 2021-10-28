
using UnityEngine;
using System;
using UnityEngine.UI;


public class PlayerSetup : MonoBehaviour
{
   
    GameObject currentUnit;

    [SerializeField] Transform pointSpawn;
    [SerializeField] GameObject[] unitPrefab;
    [SerializeField] Text numberPlayer,unitName;



    private void Update()
    {
        if (currentUnit != null)  currentUnit.transform.Rotate(Vector3.up);
    }

    public void InvokeSwitchMenu(int number)
    {
        GameEvent.instance.SwitchHUD?.Invoke(number);
        Destroy(currentUnit);
    }

    public void ChooseUnit(int unit)
    {
        switch (unit)
        {
                case 0:
                SpawnUnit(0);
                return;
        }
    }

    public void PlayCustom()
    {
        GameEvent.instance.playCustomGame?.Invoke(1);
    }



    GameObject SpawnUnit(int unit)
    {
        if (currentUnit != null) Destroy(currentUnit);
        currentUnit = Instantiate(unitPrefab[0], pointSpawn.position, pointSpawn.rotation);
        unitName.text = currentUnit.name;

        return currentUnit;
     }
}
