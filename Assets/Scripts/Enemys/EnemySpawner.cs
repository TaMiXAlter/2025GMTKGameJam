using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private NormalEnemy normalEnemy;
    [SerializeField] private HelmetEnemy helmetEnemy;
    [SerializeField] private UnderwearEnemy underwearEnemy;
    [SerializeField] private RightEnemy rightEnemy;
    [SerializeField] private LeftEnemy leftEnemy;


    #region SpawnTime
    private bool isSpawning = false;
    private float SecPerDistance = 1.0f;
    private Queue<EnemyData> enemyDatas;
    private double nextTime = 1.0f;
    private EnemyData currentEnemy;
    #endregion

    #region SpawnProperty
    float radius = 10;
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
        nextTime = AudioSystem.Get().GetCurrentSongTime();
        nextEnemy();

        isSpawning = true;
    }
    void FixedUpdate()
    {
        if (!isSpawning) return;
        if (enemyDatas.Count <= 0) isSpawning = false;

        
        if (AudioSystem.Get().GetCurrentSongTime() < nextTime) return;

        Spawn();
        nextEnemy();
    }
    void nextEnemy()
    {
        currentEnemy = enemyDatas.Dequeue();
        nextTime += SecPerDistance * currentEnemy.distance;
    }
    void Spawn()
    {
        Enemy newEnemy;
        switch (currentEnemy.type)
        {
            case EnemyType.Normal:
                newEnemy = Instantiate(normalEnemy, SpawnPosition, Quaternion.identity);
                newEnemy.Init(SecPerDistance,8, radius,new Vector3(0,radius,0),0);
                break;
            case EnemyType.Helmet:
                newEnemy = Instantiate(helmetEnemy, SpawnPosition, Quaternion.identity);
                newEnemy.Init(SecPerDistance,8, radius,new Vector3(0,radius,0),0);
                break;
            case EnemyType.Underwear:
                newEnemy = Instantiate(underwearEnemy, SpawnPosition, Quaternion.identity);
                newEnemy.Init(SecPerDistance,8, radius,new Vector3(0,radius,0),0);
                break;
            case EnemyType.Right:
                newEnemy = Instantiate(rightEnemy, SpawnPosition +Vector3.right * radius, Quaternion.identity);
                newEnemy.Init(SecPerDistance,8, radius,new Vector3(0,radius,0),1);
                break;
            case EnemyType.Left:
                newEnemy = Instantiate(leftEnemy, SpawnPosition +Vector3.left * radius, Quaternion.identity);
                newEnemy.Init(SecPerDistance,8, radius,new Vector3(0,radius,0),-1);
                break;
            default:
                Debug.Log("No This enemy type available");
                return;
        }
        
        
    }

}
