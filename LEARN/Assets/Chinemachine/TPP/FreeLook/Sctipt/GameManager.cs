using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _DatabaseGM: Database
{
   public void AddItemDatabase(ItemDatabase item)
    {
        allItem.Add(item);
    }
}

public class GameManager : MonoBehaviour
{
    [SerializeField] List<ItemDatabase> itemInDatabase;
    
    _DatabaseGM database = new _DatabaseGM();

    private void Awake()
    {
        DontDestroyOnLoad(this);
        foreach(ItemDatabase weapon in itemInDatabase)
        {
            database.AddItemDatabase(weapon); 
        }
    }

    private void Start()
    {
     

    }






}
