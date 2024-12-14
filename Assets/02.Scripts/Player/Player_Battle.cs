using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract partial class Player : MonoBehaviour
{
    protected abstract void PlayerCommonAttack();

    public void PlayerGetDamage(int _damage)
    {
        playerHP -= _damage;
    }
}
