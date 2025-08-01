using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatMapReader : MonoBehaviour
{
    public Queue<EnemyData> Read(string path)
    {
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
                string trimNote = note.Trim();
                if (trimNote == "|") continue;
                if (string.IsNullOrWhiteSpace(trimNote))
                {
                    distance++;
                    continue;
                }

                EnemyType newType = CheckNote(trimNote);
                if (newType == EnemyType.Null)
                {
                    Debug.Log("no type accept");
                    continue;
                }
                EnemyData newData = new EnemyData(newType, distance);
                output.Enqueue(newData);
                distance = 1;

            }
        }
        return output;
    }

    EnemyType CheckNote(string note)
    {
        switch (note)
        {
            case "1":
                return EnemyType.Normal;
            case "2":
                return EnemyType.Helmet;
            case "3":
                return EnemyType.Underwear;

            default:
                return EnemyType.Null;
        }
    }
}
