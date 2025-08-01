using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private NormalEnemy normalEnemy;
    [SerializeField] private HelmetEnemy helmetEnemy;
    [SerializeField] private UnderwearEnemy underwearEnemy;


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
        SecPerDistance = 60 / bpm /2 ;
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

        Spawn();
        nextEnemy();
        Timer = 0;
    }
    void nextEnemy()
    {
        currentEnemy = enemyDatas.Dequeue();
        nextTime = SecPerDistance * currentEnemy.distance;
    }
    void Spawn()
    {
        Enemy newEnemy;
        switch (currentEnemy.type)
        {
            case EnemyType.Normal:
                newEnemy = Instantiate(normalEnemy, SpawnPosition, Quaternion.identity);
                break;
            case EnemyType.Helmet:
                newEnemy = Instantiate(helmetEnemy, SpawnPosition, Quaternion.identity);
                break;
            case EnemyType.Underwear:
                newEnemy = Instantiate(underwearEnemy, SpawnPosition, Quaternion.identity);
                break;
            default:
                Debug.Log("No This enemy type available");
                return;
        }
        
        newEnemy.Init(SecPerDistance, 8, radius,new Vector3(0,radius,0));
    }

}
