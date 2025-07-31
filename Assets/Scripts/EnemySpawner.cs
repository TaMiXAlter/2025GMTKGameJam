using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemySpawner : MonoBehaviour
{
    public MeshRenderer testMesh;
    [SerializeField] private Enemy enemy;

    #region SpawnTime
    private bool isSpawning = false;
    private float SecPerDistance = 1.0f;
    private Queue<EnemyData> enemyDatas;
    private float nextTime = 1.0f;
    private float Timer = 0.0f;
    private EnemyData currentEnemy;
    #endregion

    #region SpawnProperty
    float radius = 15;
    Vector3 SpawnPosition;
    #endregion
    void Awake()
    {
        SpawnPosition = new Vector3(0, radius, radius);
    }
    public void StartSpawnEnemy(float bpm, Queue<EnemyData> datas)
    {
        //setup globe data
        SecPerDistance = 60 / bpm / 2;
        enemyDatas = datas;

        nextEnemy();

        isSpawning = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (!isSpawning) return;
        if (enemyDatas.Count <= 0) isSpawning = false;

        Timer += Time.deltaTime;
        if (Timer < nextTime) return;

        DoSomething();
        nextEnemy();
        Timer = 0;
    }
    void nextEnemy()
    {
        currentEnemy = enemyDatas.Dequeue();
        nextTime = SecPerDistance * currentEnemy.distance;
    }
    void DoSomething()
    {
        testMesh.material.color = Color.blue;
        StartCoroutine(backTowhite());
        Enemy newEnemy =  Instantiate(enemy,SpawnPosition,Quaternion.identity);
        newEnemy.Init(SecPerDistance, 8, radius,new Vector3(0,radius,0));
    }

    IEnumerator backTowhite()
    {
        yield return new WaitForSeconds(0.1f);
        testMesh.material.color = Color.white;
    }
}
