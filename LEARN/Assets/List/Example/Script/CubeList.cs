using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CubeList : MonoBehaviour
{
    [SerializeField]
    private CubeWithText prefab;

    [SerializeField]
    private List<CubeWithText> Cubes = new List<CubeWithText>();

    private int CurrentNumber;

    public void Add()
    {
        var cube = Instantiate(prefab);
        cube.setNumber(CurrentNumber);
        cube.transform.position = transform.position + Vector3.right * CurrentNumber * 6f;
        Cubes.Add(cube);
        CurrentNumber++;
        cube.transform.SetParent(transform);
    }

    public void Remove()
    {
        int index = Random.Range(0, Cubes.Count);
        var randomCube = Cubes[index];
        Cubes.Remove(randomCube);
        randomCube.PlayRemoval();
    }

    public void RemoveRandpmEntry()
    {
        List<CubeWithText> cubegreaterthantree = Cubes.Where(t => t.Number > 3).ToList();
        foreach (var cb in cubegreaterthantree)
        {
            cb.PlayRemoval();
        }
        Cubes.RemoveAll(t => t.Number > 3);
    }
}