using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Monster : MonoBehaviour
{
    // ���� ���� enum
    protected enum MonsterState
    {
        Idle,
        Trace,
        Attack,
        Damage
    }

    // ���� ���� ����
    protected MonsterState monsterState = MonsterState.Idle;

    protected Transform playerTrs;  // �÷��̾��� Transform
    protected Animator animator;

    public float monsterMoveSpeed = 5f;     // ���� �̵� �ӵ�

    public float traceRange = 5f;   // �÷��̾� ĳ���͸� �߰��ϴ� ����
    public float attackRange = 1f;  // �÷��̾� ĳ���Ϳ��� ������ �õ��ϴ� ����
    public float attackDistance = 2f;   // ������ ������ ��� ����
    public float monsterCommonAttackCoolTime = 2.0f;    // ���� �Ϲݰ��� ��Ÿ��
    public float monsterDamageDelay = 1f;

    public int monsterHP = 5;   // ������ ü��
    public int monsterAP = 1;   // ������ ���ݷ�

    protected bool inActive = false;    // �ٸ� ������ ���������� �ƴ��� �� �� �ְ� �ϴ� ����

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
        MonsterStateCheck();
    }

    /// <summary>
    /// ������ ���¸� üũ�ϰ� ���¿� ���� ������ ������ ����
    /// </summary>
    protected void MonsterStateCheck()
    {
        switch(monsterState)
        {
            case MonsterState.Idle:
                // ��� ������ �� �÷��̾� ĳ���Ͱ� ������ �߰� ���� ������ ���´ٸ�
                if(Vector3.Distance(transform.position, playerTrs.position) <= traceRange
                    && Vector3.Distance(transform.position, playerTrs.position) > attackRange)
                {
                    monsterState = MonsterState.Trace;  // ������ ���� ���¸� �߰� ���·�
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

    /// <summary>
    /// ������ �̵�
    /// </summary>
    protected virtual void MoveMonster()
    {
        // ���Ϳ� �÷��̾��� ���� �Ÿ�
        float distance = Vector3.Distance(transform.position, playerTrs.position);

        // �÷��̾ ������ �߰� �������� ����ٸ�
        if(distance >= traceRange)
        {
            // ������ ���� ���¸� ��� ���·� �ٲٰ� return
            monsterState = MonsterState.Idle;
            return;
        }
        
        // �÷��̾ ������ �߰� ���� �ȿ� �ְ� ���� �������ٴ� �ָ� �ִٸ�
        if(distance > attackRange)
        {
            // �÷��̾ ���ؼ� �̵�
            transform.LookAt(playerTrs.position, Vector3.up);
            transform.position = Vector3.MoveTowards(transform.position, playerTrs.position, monsterMoveSpeed * Time.deltaTime);
        }
        else if(distance <= attackRange)
        {// �÷��̾ ���� ���� �ȿ� �ִٸ�
            monsterState = MonsterState.Attack;     // ������ ���� ���¸� �������� ����
        }
    }
}
