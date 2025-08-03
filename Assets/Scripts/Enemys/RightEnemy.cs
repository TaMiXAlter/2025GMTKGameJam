using System;
using UnityEngine;

class RightEnemy : Enemy
{


    public override void OnHit(AttackType attackType)
    {
       if (attackType == AttackType.Right)
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