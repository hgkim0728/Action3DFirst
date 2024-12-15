using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Player
{
    /// <summary>
    /// 근접 공격을 하는 플레이어 캐릭터의 일반 공격을 실행하는 함수
    /// </summary>
    protected override void PlayerCommonAttack()
    {
        // 플레이어 캐릭터가 다른 행동을 실행하는 상태가 아니면서
        // 왼쪽 컨트롤 키를 눌렀을 때
        if (inActive == false && Input.GetKeyDown(KeyCode.LeftControl))
        {
            inActive = true;    // 이 동작을 실행하는 중에 다른 동작을 실행하지 못하도록

            // 플레이어 캐릭터 주변의 몬스터를 가져오기
            attackTarget = Physics.OverlapSphere(transform.position, playerAttackRage, monsterLayer);

            // 주변에 몬스터가 하나 이상 있다면
            if (attackTarget.Length >= 1)
            {
                // 그중 하나를 바라보도록
                transform.LookAt(attackTarget[0].transform.position);
            }

            Debug.Log("공격");
            // 플레이어 캐릭터 애니메이션 상태를 공격으로
            animState = PlayerAnimationState.Attack;
            // 이동중이었을 때 공격 애니메이션을 실행하면서 움직이는 상황 방지
            rigid.velocity = new Vector3(0, rigid.velocity.y, 0);

            RaycastHit hit;

            if(Physics.Raycast(transform.position, transform.forward, out hit, playerAttackRage,
                monsterLayer))
            {
                hit.transform.GetComponent<Monster>().MonsterGetDamage(playerAP);
            }

            // 일반 공격이 실행되는 시간 동안 inActive가 true가 되지 않도록
            StartCoroutine(WaitTime(commonAttackCoolTime));
        }
    }
}
