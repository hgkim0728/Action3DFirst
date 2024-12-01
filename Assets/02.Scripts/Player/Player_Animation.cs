using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player : MonoBehaviour
{
    protected enum PlayerAnimationState
    {
        Idle,
        Run,
        Attack,
        Damage,
        Die
    }

    protected PlayerAnimationState animState = PlayerAnimationState.Idle;

    protected void AnimationStateCheck()
    {
        switch(animState)
        {
            case PlayerAnimationState.Idle:
                animator.SetInteger("Run", 0);
            break;

            case PlayerAnimationState.Run:
                animator.SetInteger("Run", 1);
            break;

            case PlayerAnimationState.Attack:
            break;

            case PlayerAnimationState.Damage:
            break;

            case PlayerAnimationState.Die:
            break;
        }
    }
}
