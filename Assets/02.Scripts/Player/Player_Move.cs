using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public partial class Player : MonoBehaviour
{
    protected void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(x, 0, z).normalized;
        moveDir *= moveSpeed;
        moveDir.y = gravity;
        rigid.velocity = moveDir;

        if(x != 0 || z != 0)
        {
            animState = PlayerAnimationState.Run;
            Rotate(moveDir);
        }
        else
        {
            animState = PlayerAnimationState.Idle;
        }
    }

    protected void Rotate(Vector3 _moveDir)
    {
        Quaternion playerRotation = Quaternion.LookRotation(_moveDir, Vector3.up);
        playerRotation.z = 0;
        playerRotation.x = 0;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, 
            playerRotation, rotationSpeed * Time.deltaTime);
    }
}
