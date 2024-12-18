using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player : Character
{
    #region Move
    protected Rigidbody rigid;

    public float rotationSpeed = 100f;      // 플레이어 캐릭터 이동시 회전 속도
    public float gravity = -3f;     // 플레이어 캐릭터에게 적용되는 중력
    #endregion

    #region Animation
    protected Animator animator;
    protected PlayerAnimationState animState = PlayerAnimationState.Idle;   // 플레이어 캐릭터 애니메이션 상태
    #endregion

    #region Battle
    protected Collider[] attackTarget = null;   // 플레이어 캐릭터가 공격을 눌렀을 때 주변에 있는 적의 콜라이더가 들어갈 배열
    public LayerMask monsterLayer;  // 몬스터 레이어 마스크가 들어갈 변수
    #endregion

    protected void Start()
    {
        base.Start();
        rigid = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    protected void Update()
    {
        CharacterMove();
        CharacterCommonAttack();
        CharacterStateCheck();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, commonAttackRange);
    }
}
