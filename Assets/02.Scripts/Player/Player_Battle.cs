using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract partial class Player : MonoBehaviour
{
    /// <summary>
    /// 플레이어 캐릭터 일반공격
    /// 자식 오브젝트에서 공격방식에 따라 구현
    /// </summary>
    protected abstract void PlayerCommonAttack();

    /// <summary>
    /// 플레이어가 실행중인 동작을 끝낼 때까지 대기하게 해줌
    /// </summary>
    /// <returns></returns>
    protected IEnumerator WaitTime(float _delayTime)
    {
        yield return new WaitForSeconds(_delayTime);

        inActive = false;
    }

    /// <summary>
    /// 플레이어 캐릭터의 피격 함수
    /// </summary>
    /// <param name="_damage">플레이어 캐릭터가 받을 데미지</param>
    public void PlayerGetDamage(int _damage)
    {
        if (inActive == true) return;

        inActive = true;
        // 캐릭터 이동 정지
        rigid.velocity = new Vector3(0, rigid.velocity.y, 0);
        playerHP -= _damage;    // 데미지 만큼 체력을 깎는다
        animator.SetTrigger("Damage");
        animState = PlayerAnimationState.Damage;
        StartCoroutine(WaitTime(damageTime));
        Debug.Log("피격");
    }
}
