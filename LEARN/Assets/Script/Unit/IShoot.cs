using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShoot 
{
    void Subscribe();
    void Unsubscribe();
    void Shoot(int lvl);
}
