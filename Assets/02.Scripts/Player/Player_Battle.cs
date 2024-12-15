using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract partial class Player : MonoBehaviour
{
    /// <summary>
    /// �÷��̾� ĳ���� �Ϲݰ���
    /// �ڽ� ������Ʈ���� ���ݹ�Ŀ� ���� ����
    /// </summary>
    protected abstract void PlayerCommonAttack();

    /// <summary>
    /// �÷��̾ �������� ������ ���� ������ ����ϰ� ����
    /// </summary>
    /// <returns></returns>
    protected IEnumerator WaitTime(float _delayTime)
    {
        yield return new WaitForSeconds(_delayTime);

        inActive = false;
    }

    /// <summary>
    /// �÷��̾� ĳ������ �ǰ� �Լ�
    /// </summary>
    /// <param name="_damage">�÷��̾� ĳ���Ͱ� ���� ������</param>
    public void PlayerGetDamage(int _damage)
    {
        if (inActive == true) return;

        inActive = true;
        // ĳ���� �̵� ����
        rigid.velocity = new Vector3(0, rigid.velocity.y, 0);
        playerHP -= _damage;    // ������ ��ŭ ü���� ��´�
        animator.SetTrigger("Damage");
        animState = PlayerAnimationState.Damage;
        StartCoroutine(WaitTime(damageTime));
        Debug.Log("�ǰ�");
    }
}
