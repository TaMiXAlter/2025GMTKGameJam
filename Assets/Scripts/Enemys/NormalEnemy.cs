using System;
using UnityEngine;
using UnityEngine.UIElements;

class NormalEnemy : Enemy
{

    public override void OnHit(AttackType attackType)
    {
        if (attackType == AttackType.Miss || attackType == AttackType.Right || attackType == AttackType.Left)
        {
            return;
        }
        Die();
    }

    public override void Attack()
    {
        Destroy(gameObject);
    }
}