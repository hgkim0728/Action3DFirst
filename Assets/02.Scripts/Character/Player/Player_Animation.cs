using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player : Character
{
    // 플레이어 캐릭터 애니메이션 상태 enum
    protected enum PlayerAnimationState
    {
        Idle,
        Run,
        Attack,
        Damage,
        Die
    }

    /// <summary>
    /// 플레이어 캐릭터의 애니메이션 상태에 따라서 애니메이터 파라미터 값을 적용해
    /// 애니메이션이 실행되도록 하는 함수
    /// </summary>
    protected override void CharacterStateCheck()
    {
        //switch(animState)
        //{
        //    case PlayerAnimationState.Idle:
        //    break;

        //    case PlayerAnimationState.Run:
        //    break;

        //    case PlayerAnimationState.Attack:
        //    break;

        //    case PlayerAnimationState.Damage:
        //    break;

        //    case PlayerAnimationState.Die:
        //    break;
        //}

        animator.SetInteger("Run", (int)animState);
        animator.SetInteger("Attack", (int)animState);
    }

    
}
