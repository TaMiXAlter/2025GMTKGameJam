using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BeatMapReader : MonoBehaviour
{

    public void ReadAsync(string filename, System.Action<Queue<EnemyData>> onComplete)
    {
        StartCoroutine(ReadCoroutine(filename, onComplete));
    }
    

    private IEnumerator ReadCoroutine(string filename, System.Action<Queue<EnemyData>> onComplete)
    {
        string readData = null;

        yield return StartCoroutine(TryReadFileAsync(filename, (data) => readData = data));
        
        if (string.IsNullOrEmpty(readData))
        {
            Debug.LogError("Failed to read beatmap file: " + filename);
            onComplete?.Invoke(new Queue<EnemyData>());
            yield break;
        }
        

        Queue<EnemyData> output = ParseBeatmapData(readData);
        onComplete?.Invoke(output);
    }
    

    private IEnumerator TryReadFileAsync(string filename, System.Action<string> onComplete)
    {
        string path = System.IO.Path.Combine(Application.streamingAssetsPath, filename);
        
#if UNITY_WEBGL && !UNITY_EDITOR
        UnityWebRequest request = UnityWebRequest.Get(path);
        yield return request.SendWebRequest();
        
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Failed to load beatmap: " + request.error);
            onComplete?.Invoke(null);
        }
        else
        {
            onComplete?.Invoke(request.downloadHandler.text);
        }
#else

        try
        {
            string data = System.IO.File.ReadAllText(path);
            onComplete?.Invoke(data);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to read file: " + e.Message);
            onComplete?.Invoke(null);
        }
        yield break;
#endif
    }
    

    private Queue<EnemyData> ParseBeatmapData(string readData)
    {
        Queue<EnemyData> output = new Queue<EnemyData>();
        string[] sections = readData.Split("\n");
        int currentDistance = 0; 
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
                    currentDistance++;
                    continue;
                }
                
                EnemyType newType = CheckNote(trimNote);
                if (newType == EnemyType.Null)
                {
                    currentDistance++; 
                    continue;
                }
                
                EnemyData newData = new EnemyData(newType, currentDistance);
                output.Enqueue(newData);
                
                currentDistance =1; 
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
            case "4":
                return EnemyType.Right;
            case "5":
                return EnemyType.Left;
            default:
                return EnemyType.Null;
        }
    }
    

    public Queue<EnemyData> ReadSync(string filename)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        Debug.LogWarning("ReadSync should not be used in WebGL builds. Use ReadAsync instead.");
        return new Queue<EnemyData>();
#else
        string readData = TryReadFileSync(filename);
        if (string.IsNullOrEmpty(readData))
        {
            return new Queue<EnemyData>();
        }
        return ParseBeatmapData(readData);
#endif
    }
    

    private string TryReadFileSync(string filename)
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        string path = System.IO.Path.Combine(Application.streamingAssetsPath, filename);
        try
        {
            return System.IO.File.ReadAllText(path);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to read file: " + e.Message);
            return null;
        }
#else
        Debug.LogError("Sync file reading not supported in WebGL builds");
        return null;
#endif
    }
}

