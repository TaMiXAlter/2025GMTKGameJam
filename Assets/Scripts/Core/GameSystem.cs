using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameSystem : MonoBehaviour
{
    private BeatMapReader beatMapReader;
    private EnemySpawner enemySpawner;
    private Queue<EnemyData> data;
    public string FileName="Tutorial.csv";
    void Awake()
    {
        beatMapReader = gameObject.AddComponent<BeatMapReader>();
        enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
    }
    void Start()
    {
        beatMapReader.ReadAsync(FileName, PlayOnLoaded);
    }
    void StartSpawn(float bpm)
    {
        enemySpawner.StartSpawnEnemy(bpm, data);
    }
    void Finish()
    {
        ScoreSystem.Get().ShowHitRate();
    }
    void PlayOnLoaded(Queue<EnemyData> readDatas)
    {
        data = readDatas;
        // AudioSystem.Get().OnPlay.AddListener(BeatMapTestLog);
        AudioSystem.Get().OnPlay.AddListener(StartSpawn);
        AudioSystem.Get().OnFinish.AddListener(Finish);

        ScoreSystem.Get().SetMax(data.Count);
        AudioSystem.Get().TryPlay();
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
