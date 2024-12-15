using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player : MonoBehaviour
{
    #region Move
    protected Rigidbody rigid;

    public float moveSpeed = 1.0f;
    public float rotationSpeed = 100f;
    public float gravity = -3f;
    #endregion

    #region Animation
    protected Animator animator;
    [SerializeField]protected PlayerAnimationState animState = PlayerAnimationState.Idle;
    #endregion

    #region Battle
    protected Collider[] attackTarget = null;
    public LayerMask monsterLayer;

    public int playerHP = 10;
    public int playerAP = 5;

    public float playerAttackRage = 2.0f;
    public float commonAttackCoolTime = 1.0f;

    protected bool inActive = false;
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
