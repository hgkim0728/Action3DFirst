using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Monster : MonoBehaviour
{
    // 몬스터 상태 enum
    protected enum MonsterState
    {
        Idle,
        Trace,
        Attack,
        Damage
    }

    // 몬스터 현재 상태
    protected MonsterState monsterState = MonsterState.Idle;

    protected Transform playerTrs;  // 플레이어의 Transform
    protected Animator animator;

    public float characterMoveSpeed = 5f;     // 몬스터 이동 속도

    public float traceRange = 5f;   // 플레이어 캐릭터를 추격하는 범위
    public float commonAttackRange = 1f;  // 플레이어 캐릭터에게 공격을 시도하는 범위
    public float attackDistance = 2f;   // 몬스터의 공격이 닿는 범위
    public float commonAttackTime = 2.0f;    // 몬스터 일반공격 쿨타임
    public float characterDamageDelayTime = 1f;

    public int characterCurrentHP = 5;   // 몬스터의 체력
    public int characterAP = 1;   // 몬스터의 공격력

    protected bool inActive = false;    // 다른 동작을 실행중인지 아닌지 알 수 있게 하는 변수

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
        animator = GetComponent<Animator>();
        playerTrs = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        CharacterStateCheck();
    }

    /// <summary>
    /// 몬스터의 상태를 체크하고 상태에 따라 실행할 동작을 선택
    /// </summary>
    protected void CharacterStateCheck()
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
    protected virtual void CharacterMove()
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
