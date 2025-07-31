using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatMapReader : MonoBehaviour
{
    public Queue<EnemyData> Read(string path){
        Queue<EnemyData> output = new Queue<EnemyData>();

        string readData = System.IO.File.ReadAllText(path);
        string[] sections = readData.Split("\n");
        
        int distance = 0;

        foreach (var section in sections)
        {
            if (section == string.Empty) continue;
            string[] notes = section.Split(",");
            foreach (string note in notes)
            {
                if (string.IsNullOrWhiteSpace(note) || note == "|")
                {
                    distance++;
                    continue;
                }
                EnemyData newData = null;
                switch (note)
                {
                    case "1":
                        newData = new EnemyData(EnemyType.Normal, distance);
                        break;
                    default:
                        break;
                }
                if (newData != null)
                {
                    output.Enqueue(newData);
                    distance = 1;
                }
                
            }
        }
        return output;
    }
}
