using System;
using UnityEngine;
using UnityEngine.UIElements;

class NormalEnemy : Enemy
{
    protected override void Move(float deltaTime)
    {
        if (!canMove) return;
        timer += deltaTime;
        float t = Mathf.Clamp01(timer / LifeTime);
        angle = 90f * (1 - t);

        float y = origin.y - MathF.Cos(2 * MathF.PI * angle / 360) * radius;
        float z = origin.z + MathF.Sin(2 * MathF.PI * angle / 360) * radius;
        transform.position = new Vector3(0, y, z);
    }

    public override void OnHit(AttackType attackType)
    {
        if (attackType == AttackType.Miss)
        {
            return;
        }
        Destroy(gameObject);
    }

    public override void Attack()
    {
        Destroy(gameObject);
    }
}