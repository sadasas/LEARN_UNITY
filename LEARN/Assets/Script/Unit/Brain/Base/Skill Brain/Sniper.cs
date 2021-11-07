using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : SkillBrain
{
    public override void SkillOne()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {

        }
    }

    public override void Starting()
    {
        throw new System.NotImplementedException();
    }


   /* IEnumerator SlowMotion()
    {
        Time.
    }*/
}
