using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePig : Monster
{
    /// <summary>
    /// 돼지 몬스터의 일반 공격
    /// </summary>
    protected override void MonsterCommonAttack()
    {
        // 몬스터가 다른 동작을 실행중이라면
        if (inActive == true)
        {
            return;
        }

        if(Vector3.Distance(transform.position, playerTrs.position) > attackRange)
        {
            monsterState = MonsterState.Trace;
            return;
        }
        else
        {
            //transform.LookAt(playerTrs.position);

            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, attackDistance)
                && hit.transform.tag == "Player")
            {
                playerTrs.GetComponent<Player>().PlayerGetDamage(monsterAP);
                inActive = true;
            }

            StartCoroutine(MonsterWaitTime(monsterCommonAttackCoolTime));
        }
    }

    
}
