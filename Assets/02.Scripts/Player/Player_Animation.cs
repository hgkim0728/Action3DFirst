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

    protected void AnimationStateCheck()
    {
        switch(animState)
        {
            case PlayerAnimationState.Idle:
            break;

            case PlayerAnimationState.Run:
            break;

            case PlayerAnimationState.Attack:
                AttackAnimationState();
            break;

            case PlayerAnimationState.Damage:
            break;

            case PlayerAnimationState.Die:
            break;
        }

        animator.SetInteger("Run", (int)animState);
        animator.SetInteger("Attack", (int)animState);
    }

    protected void AttackAnimationState()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("CommonAttack") == true)
        {
            float time = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
            float end = animator.GetCurrentAnimatorStateInfo(0).length;

            if(time >= end)
            {
                //animator.SetInteger("Attack", 0);
                inActive = false;
            }
        }
    }
}
