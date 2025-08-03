using System;
using UnityEngine;

class HelmetEnemy : Enemy
{
    public override void Attack()
    {
        Destroy(gameObject);
    }

    public override void OnHit(AttackType attackType)
    {
        if (attackType == AttackType.Back)
        {
            Die();
        }
        return;
    }
}