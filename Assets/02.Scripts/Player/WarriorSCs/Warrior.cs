using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Player
{
    protected override void PlayerCommonAttack()
    {
        if (inActive == false && Input.GetKeyDown(KeyCode.LeftControl))
        {
            inActive = true;
            Debug.Log("АјАн");
            animState = PlayerAnimationState.Attack;
            rigid.velocity = new Vector3(0, rigid.velocity.y, 0);
        }
    }
}
