using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Monster : MonoBehaviour
{
    protected enum MonsterState
    {
        Idle,
        Trace,
        Attack,
        Damage
    }

    protected MonsterState monsterState = MonsterState.Idle;

    protected Transform playerTrs;
    protected Animator animator;

    public float monsterMoveSpeed = 5f;

    public float traceRange = 5f;
    public float attackRange = 1f;
    public float attackDistance = 2f;

    public int monsterHP = 5;
    public int monsterAP = 1;

    protected bool inActive = false;

    private void OnDrawGizmos()
    {
        if(monsterState == MonsterState.Idle || monsterState == MonsterState.Trace)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, traceRange);
        }
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        playerTrs = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        MonsterStateCheck();
    }

    protected void MonsterStateCheck()
    {
        switch(monsterState)
        {
            case MonsterState.Idle:
                if(Vector3.Distance(transform.position, playerTrs.position) <= traceRange
                    && Vector3.Distance(transform.position, playerTrs.position) > attackRange)
                {
                    monsterState = MonsterState.Trace;
                }
            break;

            case MonsterState.Trace:
                MoveMonster();
            break;

            case MonsterState.Attack:
                MonsterCommonAttack();
            break;

            case MonsterState.Damage:
            break;
        }

        animator.SetInteger("Move", (int)monsterState);
        animator.SetInteger("Attack", (int)monsterState);
    }

    protected virtual void MoveMonster()
    {
        float distance = Vector3.Distance(transform.position, playerTrs.position);

        if(distance >= traceRange)
        {
            monsterState = MonsterState.Idle;
            return;
        }
        
        if(distance > attackRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerTrs.position, monsterMoveSpeed * Time.deltaTime);
            transform.LookAt(playerTrs.position, Vector3.up);
        }
        else if(distance <= attackRange)
        {
            monsterState = MonsterState.Attack;
        }
    }
}
