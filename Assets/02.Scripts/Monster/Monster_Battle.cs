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
        // ĳ���� �̵� ����
        monsterHP -= _damage;    // ������ ��ŭ ü���� ��´�
        animator.SetTrigger("Damage");
        monsterState = MonsterState.Damage;
        StartCoroutine(MonsterWaitTime(monsterDamageDelay));
        Debug.Log("�ǰ�");
    }
}
