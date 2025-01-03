﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Monster : Character
{
    // 몬스터 상태 enum
    protected enum MonsterState
    {
        Idle,
        Trace,
        Attack,
        Damage,
        Die
    }

    // 몬스터 현재 상태
    protected MonsterState monsterState = MonsterState.Idle;

    protected Transform playerTrs;  // 플레이어의 Transform

    public float traceRange = 5f;   // 플레이어 캐릭터를 추격하는 범위
    public float attackDistance = 2f;   // 몬스터의 공격이 닿는 범위

    protected bool damaged = false;

    private void OnDrawGizmos()
    {
        if(monsterState == MonsterState.Idle || monsterState == MonsterState.Trace)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, traceRange);
        }
        else if(monsterState == MonsterState.Attack)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position + Vector3.up, transform.forward * attackDistance);
        }
    }

    void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
        playerTrs = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        CharacterStateCheck();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            int damage = playerTrs.GetComponent<Player>().characterAP;
            CharacterGetDamage(damage);
        }
    }

    /// <summary>
    /// 몬스터의 상태를 체크하고 상태에 따라 실행할 동작을 선택
    /// </summary>
    protected override void CharacterStateCheck()
    {
        switch(monsterState)
        {
            case MonsterState.Idle:
                // 대기 상태일 때 플레이어 캐릭터가 몬스터의 추격 범위 안으로 들어온다면
                if(Vector3.Distance(transform.position, playerTrs.position) <= traceRange
                    && Vector3.Distance(transform.position, playerTrs.position) > commonAttackRange)
                {
                    monsterState = MonsterState.Trace;  // 몬스터의 현재 상태를 추격 상태로
                }
            break;

            case MonsterState.Trace:
                CharacterMove();
            break;

            case MonsterState.Attack:
                CharacterCommonAttack();
            break;

            case MonsterState.Damage:
            break;
        }

        animator.SetInteger("Move", (int)monsterState);
        animator.SetInteger("Attack", (int)monsterState);
    }

    /// <summary>
    /// 몬스터의 이동
    /// </summary>
    protected override void CharacterMove()
    {
        // 몬스터와 플레이어의 현재 거리
        float distance = Vector3.Distance(transform.position, playerTrs.position);

        // 플레이어가 몬스터의 추격 범위에서 벗어낫다면
        if(distance >= traceRange)
        {
            // 몬스터의 현재 상태를 대기 상태로 바꾸고 return
            monsterState = MonsterState.Idle;
            return;
        }
        
        // 플레이어가 몬스터의 추격 범위 안에 있고 공격 범위보다는 멀리 있다면
        if(distance > commonAttackRange)
        {
            // 플레이어를 향해서 이동
            transform.LookAt(playerTrs.position, Vector3.up);
            transform.position = Vector3.MoveTowards(transform.position, playerTrs.position, characterMoveSpeed * Time.deltaTime);
        }
        else if(distance <= commonAttackRange)
        {// 플레이어가 공격 범위 안에 있다면
            monsterState = MonsterState.Attack;     // 몬스터의 현재 상태를 공격으로 변경
        }
    }
}
