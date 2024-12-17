using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public float characterMoveSpeed;    // 캐릭터 이동속도
    
    public float commonAttackRange;     // 캐릭터의 일반 공격 범위
    public float commonAttackTime;      // 일반 공격을 실행하는 데 걸리는 시간
    public float characterDamageDelayTime;  // 피격된 캐릭터가 다음 동작을 실행할 수 있는 상태가 되기까지의 시간
    public int characterMaxHP;      // 캐릭터의 최대체력
    protected int characterCurrentHP;      // 캐릭터의 현재 체력
    public int characterAP;     // 캐릭터의 공격력

    protected bool inAction;    // 캐릭터가 동작을 실행중인지 여부

    /// <summary>
    /// 캐릭터의 일반 공격
    /// </summary>
    protected abstract void CharacterCommonAttack();

    /// <summary>
    /// 캐릭터의 이동
    /// </summary>
    protected abstract void CharacterMove();

    /// <summary>
    /// 캐릭터 상태 체크
    /// </summary>
    protected abstract void CharacterStateCheck();

    protected void CharacterGetDamage(int _damage)
    {
        if(inAction == true) return;

        inAction = true;
        characterCurrentHP -= _damage;
        StartCoroutine(WaitTime(characterDamageDelayTime));
    }

    /// <summary>
    /// 캐릭터가 실행중인 동작을 끝낼 때까지 대기
    /// </summary>
    /// <param name="_time">동작을 실행하는 데 필요한 시간</param>
    /// <returns></returns>
    protected IEnumerator WaitTime(float _time)
    {
        yield return new WaitForSeconds(_time);

        inAction = false;
    }
}
