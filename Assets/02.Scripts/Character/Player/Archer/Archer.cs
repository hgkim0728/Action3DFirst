﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Player
{
    public GameObject arrow;
    public Transform shotPosition;

    protected override void CharacterCommonAttack()
    {
        // 플레이어 캐릭터가 다른 행동을 실행하는 상태가 아니면서
        // 왼쪽 컨트롤 키를 눌렀을 때
        if (inActive == false && Input.GetKeyDown(KeyCode.LeftControl))
        {
            inActive = true;    // 이 동작을 실행하는 중에 다른 동작을 실행하지 못하도록

            // 플레이어 캐릭터 주변의 몬스터를 가져오기
            attackTarget = Physics.OverlapSphere(transform.position, commonAttackRange, monsterLayer);

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

            GameObject.Instantiate(arrow, shotPosition.position, transform.rotation);

            // 일반 공격이 실행되는 시간 동안 inActive가 true가 되지 않도록
            StartCoroutine(WaitTime(commonAttackTime));
        }
    }
}
