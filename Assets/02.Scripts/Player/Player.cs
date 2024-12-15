using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player : MonoBehaviour
{
    #region Move
    protected Rigidbody rigid;

    public float moveSpeed = 1.0f;  // 플레이어 캐릭터 이동속도
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

    public int playerHP = 10;   // 플레이어 캐릭터 체력
    public int playerAP = 5;    // 플레이어 캐릭터 공격력

    public float playerAttackRage = 2.0f;   // 플레이어 캐릭터 공격 범위
    public float commonAttackCoolTime = 1.0f;   // 플레이어 캐릭터 일반 공격 쿨타임
    public float damageTime = 1.5f;     // 플레이어가 피격 당한 뒤 데미지를 받지 않고 조작할 수 없는 시간

    protected bool inActive = false;    // 플레이어 캐릭터가 이미 행동중인지 아닌지
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
