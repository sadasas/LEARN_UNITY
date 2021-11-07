using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu (fileName = "Resource" , menuName ="Resource")]
public class ResourceHandler : ScriptableObject
{

    [Header("HUD")]
    [SerializeField] internal GameObject loadingScreenHUDPrefab;
    [SerializeField] internal GameObject typeEnemyHUDPrefab;
    [SerializeField] internal GameObject limitEnemyHUDPrefab;
    [Space(5)]
    [SerializeField] internal GameObject[] allcustomGameHUDPrefab;




    [Header("UNIT")]
    [Space(10)]
    [SerializeField] internal GameObject[] unitPlayerPrefab;
    [SerializeField] internal GameObject[] unitDisplayPrefab;
    [SerializeField] internal GameObject[] unitAIPrefab;

    [Header("SCENE")]
    [Space(10)]
    [SerializeField] internal string[] allScene;


    [Header("TYPE BRAIN")]
    [Space(10)]
    [SerializeField] internal TypeBrain[] typeBrain;

    [Header("TYPE SHOOT")]
    [Space(10)]
    [SerializeField] internal Shoot[] typeShoot;

    [Header("TYPE SKILL")]
    [Space(10)]
    [SerializeField] internal SkillBrain[] typeSkill;


    [Header("MAP")]
    [Space(10)]
    [SerializeField] internal VideoClip[] mapPriviewVidio;

}
