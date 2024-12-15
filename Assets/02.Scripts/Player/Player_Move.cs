using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public partial class Player : MonoBehaviour
{
    /// <summary>
    /// �̵�Ű�� ������ �� �÷��̾� ĳ���Ͱ� �̵�
    /// </summary>
    protected void Move()
    {
        // �÷��̾� ĳ���Ͱ� ���� �� �ٸ� �ൿ�� �������� ����
        // �̵��� �� ������ return
        if (inActive == true) return;

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        // �Էµ� ����Ű�� �̵� ������ ����
        Vector3 moveDir = new Vector3(x, 0, z).normalized;  // �밢�� �̵��� �ӵ��� �����ϴ� ������ ���� ���� noramlized
        moveDir *= moveSpeed;
        moveDir.y = gravity;
        rigid.velocity = moveDir;

        // ����Ű�� �Է����̶��
        if(x != 0 || z != 0)
        {
            animState = PlayerAnimationState.Run;   // �÷��̾� ĳ������ �ִϸ��̼� ���¸� Run����
            Rotate(moveDir);
        }
        else
        {// ����Ű�� ������ �ʴ� ���¶��
            animState = PlayerAnimationState.Idle;  // �÷��̾� ĳ���� �ִϸ��̼� ���¸� Idle��
        }
    }

    /// <summary>
    /// �÷��̾� ĳ������ �̵����⿡ ���� ȸ��
    /// </summary>
    /// <param name="_moveDir">�÷��̾� ĳ������ ���� �̵� ����</param>
    protected void Rotate(Vector3 _moveDir)
    {
        Quaternion playerRotation = Quaternion.LookRotation(_moveDir, Vector3.up);
        playerRotation.z = 0;
        playerRotation.x = 0;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, 
            playerRotation, rotationSpeed * Time.deltaTime);
    }
}
