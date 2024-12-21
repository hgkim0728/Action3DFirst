using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Player
{
    public GameObject arrow;
    public Transform shotPosition;

    protected virtual void CharacterCommonAttack()
    {
        // �÷��̾� ĳ���Ͱ� �ٸ� �ൿ�� �����ϴ� ���°� �ƴϸ鼭
        // ���� ��Ʈ�� Ű�� ������ ��
        if (inActive == false && Input.GetKeyDown(KeyCode.LeftControl))
        {
            inActive = true;    // �� ������ �����ϴ� �߿� �ٸ� ������ �������� ���ϵ���

            // �÷��̾� ĳ���� �ֺ��� ���͸� ��������
            attackTarget = Physics.OverlapSphere(transform.position, commonAttackRange, monsterLayer);

            // �ֺ��� ���Ͱ� �ϳ� �̻� �ִٸ�
            if (attackTarget.Length >= 1)
            {
                // ���� �ϳ��� �ٶ󺸵���
                transform.LookAt(attackTarget[0].transform.position);
            }

            Debug.Log("����");
            // �÷��̾� ĳ���� �ִϸ��̼� ���¸� ��������
            animState = PlayerAnimationState.Attack;
            // �̵����̾��� �� ���� �ִϸ��̼��� �����ϸ鼭 �����̴� ��Ȳ ����
            rigid.velocity = new Vector3(0, rigid.velocity.y, 0);

            GameObject.Instantiate(arrow, shotPosition.position, Quaternion.identity);

            // �Ϲ� ������ ����Ǵ� �ð� ���� inActive�� true�� ���� �ʵ���
            StartCoroutine(WaitTime(commonAttackTime));
        }
    }
}
