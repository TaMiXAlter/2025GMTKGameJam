using System;
using UnityEngine;

class LeftEnemy : Enemy
{


    public override void OnHit(AttackType attackType)
    {
        if (attackType == AttackType.Left)
        {
            Die();
        }
        return;
    }

    public override void Attack()
    {
        Destroy(gameObject);
    }
}