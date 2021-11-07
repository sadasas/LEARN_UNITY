using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum TypeUnit
{
    HACKER,
    SNIPER
}
public enum SubSetting
{
    ENEMY,
    PLAYER
}
public struct Player
{
    public int unitPlayer;
    public TypeShoot typeShoot;
    public TypeUnit typeUnit;
}

public struct AI
{
    public int unitEnemy;
    public List<TypeShoot> typeShoot;
}
public struct CustomGame
{
    public Player player;
    public AI ai;
    public int map;
    public List<GameObject> unitGameobject;

}


public class ChooseMap
{

}

public class ChooseEnemy
{
    ResourceHandler resource;
}