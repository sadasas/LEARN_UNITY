using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


/// <summary>
/// Manage and calculate grid by length and width , store tile
/// </summary>
public class GridManager : MonoBehaviour
{
    [SerializeField] GameObject tilePrefab;
    [SerializeField]  int sideLength;
    [Tooltip("nothing")] [SerializeField] int offset;

    public Transform[] allTile { get; private set; }

    public void  SetGrid()
    {
        //store  all tile in array
        allTile = new Transform[sideLength * sideLength];

        //row
        for (int j = 0; j < sideLength; j++)
        {
            //collom
            for (int i = 0; i < sideLength; i++)
            {
                Vector3 pos = new Vector3((i + sideLength) * offset, transform.position.y,(j + sideLength) *offset);
                GameObject newTile = Instantiate(tilePrefab, pos, transform.rotation);
                allTile[j * 1 * 5 + i] = newTile.transform;
               // Debug.Log(j * 1 * 5 + i);
            }
        }
      
    }
}
