using System;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected bool canMove = false;
    protected float radius;
    protected float angle = 90;
    protected Vector3 origin;
    protected float LifeTime;
    protected float timer = 0f;
    protected abstract void Move(float deltaTime);
    public abstract void OnHit(AttackType attackType);
    public abstract void Attack();
    public void Init(float SecPerDistance, float EarlySpawnCount, float pRadius, Vector3 pOrigin)
    {
        LifeTime = SecPerDistance * EarlySpawnCount;
        radius = pRadius;
        origin = pOrigin;
        canMove = true;
    }

    void Update()
    {
        if (angle == 0f)
        {
            canMove = false;
            Attack();
        }
        
            
        Move(Time.deltaTime);
    }

    
}