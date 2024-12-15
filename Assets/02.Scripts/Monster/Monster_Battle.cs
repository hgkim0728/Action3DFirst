using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract partial class Monster : MonoBehaviour
{
    protected abstract void MonsterCommonAttack();

    protected IEnumerator MonsterWaitTime(float _waitTime)
    {
        yield return new WaitForSeconds(_waitTime);

        inActive = false;
    }

    public void MonsterGetDamage(int _damage)
    {
        if (inActive == true) return;

        inActive = true;
        // 캐릭터 이동 정지
        monsterHP -= _damage;    // 데미지 만큼 체력을 깎는다
        animator.SetTrigger("Damage");
        monsterState = MonsterState.Damage;
        StartCoroutine(MonsterWaitTime(monsterDamageDelay));
        Debug.Log("피격");
    }
}
