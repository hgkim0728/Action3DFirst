using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public partial class Monster : Character
{
    /// <summary>
    /// 돼지 몬스터 일반 공격 코드
    /// 다른 유형의 공격을 하는 몬스터는 상속을 통해 virtual로 구현
    /// </summary>
    protected override void CharacterCommonAttack()
    {
        // 몬스터가 다른 동작을 실행중이라면
        if (inActive == true)
        {
            return;
        }

        if (Vector3.Distance(transform.position, playerTrs.position) > commonAttackRange)
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
                playerTrs.GetComponent<Player>().CharacterGetDamage(characterAP);
                inActive = true;
            }

            StartCoroutine(WaitTime(commonAttackTime));
        }
    }

    protected virtual void CharacterGetDamage(int _damage)
    {
        if (damaged == true || isDie == true) return;
        inActive = true;
        damaged = true;
        characterCurrentHP -= _damage;
        Debug.Log("피격");
        animator.SetTrigger("Damage");

        if (characterCurrentHP <= 0)
        {
            isDie = true;
            characterCurrentHP = 0;
            monsterState = MonsterState.Die;
            CharacterDie();
        }
        else
        {
            monsterState = MonsterState.Damage;
            StartCoroutine(WaitTime(characterDamageDelayTime));
        }
    }

    protected virtual void CharacterDie()
    {
        base.CharacterDie();
    }

    protected virtual IEnumerator WaitTime(float _time)
    {
        yield return StartCoroutine(base.WaitTime(_time));
        damaged = false;
        monsterState = MonsterState.Trace;
    }
}
