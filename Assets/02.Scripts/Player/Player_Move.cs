using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public partial class Player : MonoBehaviour
{
    /// <summary>
    /// 이동키를 눌렀을 때 플레이어 캐릭터가 이동
    /// </summary>
    protected void CharacterMove()
    {
        // 플레이어 캐릭터가 공격 등 다른 행동을 실행중일 때는
        // 이동할 수 없도록 return
        if (inActive == true) return;

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        // 입력된 방향키로 이동 방향을 설정
        Vector3 moveDir = new Vector3(x, 0, z).normalized;  // 대각선 이동시 속도가 증가하는 현상을 막기 위해 noramlized
        moveDir *= characterMoveSpeed;
        moveDir.y = gravity;
        rigid.velocity = moveDir;

        // 방향키를 입력중이라면
        if(x != 0 || z != 0)
        {
            animState = PlayerAnimationState.Run;   // 플레이어 캐릭터의 애니메이션 상태를 Run으로
            Rotate(moveDir);
        }
        else
        {// 방향키를 누르지 않는 상태라면
            animState = PlayerAnimationState.Idle;  // 플레이어 캐릭터 애니메이션 상태를 Idle로
        }
    }

    /// <summary>
    /// 플레이어 캐릭터의 이동방향에 따라 회전
    /// </summary>
    /// <param name="_moveDir">플레이어 캐릭터의 현재 이동 방향</param>
    protected void Rotate(Vector3 _moveDir)
    {
        Quaternion playerRotation = Quaternion.LookRotation(_moveDir, Vector3.up);
        playerRotation.z = 0;
        playerRotation.x = 0;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, 
            playerRotation, rotationSpeed * Time.deltaTime);
    }
}
