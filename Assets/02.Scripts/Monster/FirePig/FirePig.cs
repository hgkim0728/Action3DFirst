using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePig : Monster
{
    protected override void MonsterCommonAttack()
    {
        if (inActive == true) return;

        

        if(Vector3.Distance(transform.position, playerTrs.position) > attackDistance)
        {
            monsterState = MonsterState.Trace;
            return;
        }
    }
}
