using System;

using UnityEngine;

[Serializable]
public struct TargetSetting
{
    [Range(10, 50)]
    [Tooltip("Sniper betwen 20 and 50 \n Normal max 20")]
    public float rangeSearchPatrol;
    public string targetSearch;
}


[CreateAssetMenu(fileName = "Type Brain", menuName = "Brain/Type Brain")]
public class TypeBrain : ScriptableObject
{
    public TargetSetting target;
    // public TargetSetting target { get => _target; }
    public SkillBrain skill;
    public Shoot shoot;
}
