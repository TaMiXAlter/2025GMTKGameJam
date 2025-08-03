using System;
using UnityEngine;

class UnderwearEnemy : Enemy
{
    public override void OnHit(AttackType attackType)
    {
        if (attackType == AttackType.Front)
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