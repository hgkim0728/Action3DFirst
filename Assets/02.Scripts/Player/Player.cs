using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player : MonoBehaviour
{
    #region Move
    protected Rigidbody rigid;

    public float moveSpeed = 1.0f;  // �÷��̾� ĳ���� �̵��ӵ�
    public float rotationSpeed = 100f;      // �÷��̾� ĳ���� �̵��� ȸ�� �ӵ�
    public float gravity = -3f;     // �÷��̾� ĳ���Ϳ��� ����Ǵ� �߷�
    #endregion

    #region Animation
    protected Animator animator;
    protected PlayerAnimationState animState = PlayerAnimationState.Idle;   // �÷��̾� ĳ���� �ִϸ��̼� ����
    #endregion

    #region Battle
    protected Collider[] attackTarget = null;   // �÷��̾� ĳ���Ͱ� ������ ������ �� �ֺ��� �ִ� ���� �ݶ��̴��� �� �迭
    public LayerMask monsterLayer;  // ���� ���̾� ����ũ�� �� ����

    public int playerHP = 10;   // �÷��̾� ĳ���� ü��
    public int playerAP = 5;    // �÷��̾� ĳ���� ���ݷ�

    public float playerAttackRage = 2.0f;   // �÷��̾� ĳ���� ���� ����
    public float commonAttackCoolTime = 1.0f;   // �÷��̾� ĳ���� �Ϲ� ���� ��Ÿ��
    public float damageTime = 1.5f;     // �÷��̾ �ǰ� ���� �� �������� ���� �ʰ� ������ �� ���� �ð�

    protected bool inActive = false;    // �÷��̾� ĳ���Ͱ� �̹� �ൿ������ �ƴ���
    #endregion

    protected void Start()
    {
        rigid = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    protected void Update()
    {
        Move();
        PlayerCommonAttack();
        AnimationStateCheck();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, playerAttackRage);
    }
}
