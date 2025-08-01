using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class GameSystem : MonoBehaviour
{
    private BeatMapReader beatMapReader;
    private EnemySpawner enemySpawner;
    private Queue<EnemyData> data;
    void Awake()
    {
        beatMapReader = gameObject.AddComponent<BeatMapReader>();
        enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
    }
    void Start()
    {
        data = beatMapReader.Read("Assets/Beatmap/Gamejam_BeatMap - test2.csv");
        // AudioSystem.Get().OnPlay.AddListener(BeatMapTestLog);
        AudioSystem.Get().OnPlay.AddListener(StartSpawn);
        AudioSystem.Get().TryPlay();
    }
    void StartSpawn(float bpm)
    {
        enemySpawner.StartSpawnEnemy(bpm, data);
    }
    #region "Test"
    void BeatMapTestLog(float time)
    {
        foreach (EnemyData item in data)
        {
            string printLog = "Enemy Type: ";

            switch (item.type)
            {
                case EnemyType.Normal:
                    printLog += "Normal";
                    break;
                case EnemyType.Helmet:
                    printLog += "Helmet";
                    break;
                case EnemyType.Underwear:
                    printLog += "Underwear";
                    break;
                default:
                    printLog += "None";
                    break;
            }

            printLog += " Distance = " + item.distance;
            Debug.Log(printLog);
        }
    }
#endregion
}
