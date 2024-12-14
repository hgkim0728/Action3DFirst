using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePig : Monster
{
    protected override void MonsterCommonAttack()
    {
        if (inActive == true)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("CommonAttack") == true)
            {
                float time = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
                float end = animator.GetCurrentAnimatorStateInfo(0).length;

                if (time >= end)
                {
                    //animator.SetInteger("Attack", 0);
                    inActive = false;
                }
                else
                { return; }
            }
        }
        else
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
            transform.LookAt(playerTrs.position);

            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, attackDistance)
                && hit.transform.tag == "Player")
            {
                playerTrs.GetComponent<Player>().PlayerGetDamage(monsterAP);
                inActive = true;
            }
        }
    }
}
