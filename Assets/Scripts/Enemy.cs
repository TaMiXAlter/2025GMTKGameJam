using System;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    bool canMove = false;
    float radius;
    float angle = 0;
    Vector3 origin;
    float LifeTime;
    float timer = 0f;
    public void Init(float SecPerDistance, float EarlySpawnCount,float pRadius,Vector3 pOrigin)
    {
        LifeTime = SecPerDistance * EarlySpawnCount;
        radius = pRadius;
        origin = pOrigin;
        canMove = true;
    }
    void Update()
    {
        if (!canMove) return;
        timer += Time.deltaTime;
        float t = Mathf.Clamp01(timer / LifeTime);
        angle = 90f * (1 - t);

        float y = origin.y - MathF.Cos(2 * MathF.PI * angle / 360) * radius;
        float z = origin.z + MathF.Sin(2 * MathF.PI * angle / 360) * radius;
        transform.position = new Vector3(0, y, z);
        if (t >= 1f)Destroy(gameObject);
    }
}