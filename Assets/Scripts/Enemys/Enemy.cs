using System;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected GameObject effectPrefab;
    protected bool canMove = false;
    protected float radius;
    protected double angle = 90;
    protected Vector3 origin;
    protected float LifeTime;
    protected double timer = 0f;
    private double prevTime = 0;
    protected float LeftRightMove = 0;
    public abstract void OnHit(AttackType attackType);
    public abstract void Attack();
    public void Init(float SecPerDistance, float EarlySpawnCount, float pRadius, Vector3 pOrigin, float leftRight)
    {
        LifeTime = SecPerDistance * EarlySpawnCount;
        radius = pRadius;
        origin = pOrigin;
        canMove = true;
        LeftRightMove = leftRight;
        prevTime = AudioSystem.Get().GetCurrentSongTime();
    }

    void Update()
    {
        if (angle <= -3)
        {
            canMove = false;
            Attack();
        }


        Move();
    }

    protected void Die()
    {
        ScoreSystem.Get().AddHit();
        GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
        Destroy(effect, .5f);
        Destroy(gameObject);
    }
    protected void Move() {
        if (!canMove) return;
        double songTime = AudioSystem.Get().GetCurrentSongTime();
        double deltaTime = songTime - prevTime;
        prevTime = songTime;
        timer += deltaTime;
        double t = timer / LifeTime;
        angle = 90 * (1 - t);

        float Rad = Mathf.Deg2Rad * (float)(angle);
        float y = origin.y - MathF.Cos(Rad) * radius;
        float z = origin.z + MathF.Sin(Rad) * radius;
        float x = origin.x + MathF.Sin(Rad) * radius * LeftRightMove;
        transform.position = new Vector3(x, y, z);
    }
}