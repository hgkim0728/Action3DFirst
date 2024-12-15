using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player : MonoBehaviour
{
    // �÷��̾� ĳ���� �ִϸ��̼� ���� enum
    protected enum PlayerAnimationState
    {
        Idle,
        Run,
        Attack,
        Damage,
        Die
    }

    /// <summary>
    /// �÷��̾� ĳ������ �ִϸ��̼� ���¿� ���� �ִϸ����� �Ķ���� ���� ������
    /// �ִϸ��̼��� ����ǵ��� �ϴ� �Լ�
    /// </summary>
    protected void AnimationStateCheck()
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
