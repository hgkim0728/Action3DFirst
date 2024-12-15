using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePig : Monster
{
    /// <summary>
    /// ���� ������ �Ϲ� ����
    /// </summary>
    protected override void MonsterCommonAttack()
    {
        // ���Ͱ� �ٸ� ������ �������̶��
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
