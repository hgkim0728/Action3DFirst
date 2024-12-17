using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract partial class Monster : MonoBehaviour
{
    protected abstract void CharacterCommonAttack();

    protected IEnumerator WaitTime(float _time)
    {
        yield return new WaitForSeconds(_time);

        inActive = false;
    }

    public void CharacterGetDamage(int _damage)
    {
        if (inActive == true) return;

        inActive = true;
        // 캐릭터 이동 정지
        characterCurrentHP -= _damage;    // 데미지 만큼 체력을 깎는다
        animator.SetTrigger("Damage");
        monsterState = MonsterState.Damage;
        StartCoroutine(WaitTime(characterDamageDelayTime));
        Debug.Log("피격");
    }
}
