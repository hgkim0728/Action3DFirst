using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Player
{
    /// <summary>
    /// ���� ������ �ϴ� �÷��̾� ĳ������ �Ϲ� ������ �����ϴ� �Լ�
    /// </summary>
    protected override void PlayerCommonAttack()
    {
        // �÷��̾� ĳ���Ͱ� �ٸ� �ൿ�� �����ϴ� ���°� �ƴϸ鼭
        // ���� ��Ʈ�� Ű�� ������ ��
        if (inActive == false && Input.GetKeyDown(KeyCode.LeftControl))
        {
            inActive = true;    // �� ������ �����ϴ� �߿� �ٸ� ������ �������� ���ϵ���

            // �÷��̾� ĳ���� �ֺ��� ���͸� ��������
            attackTarget = Physics.OverlapSphere(transform.position, playerAttackRage, monsterLayer);

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

            RaycastHit hit;

            if(Physics.Raycast(transform.position, transform.forward, out hit, playerAttackRage,
                monsterLayer))
            {
                hit.transform.GetComponent<Monster>().MonsterGetDamage(playerAP);
            }

            // �Ϲ� ������ ����Ǵ� �ð� ���� inActive�� true�� ���� �ʵ���
            StartCoroutine(WaitTime(commonAttackCoolTime));
        }
    }
}
