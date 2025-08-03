using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class AudioSystem : MonoBehaviour
{
    static private AudioSystem instance;
    public AudioClip CurrentClip;
    [HideInInspector]
    public UnityEvent<float> OnPlay;
    [HideInInspector]
    public UnityEvent OnFinish;
    public float bpm;
    private AudioSource AudioSource;
    private float startPlayTime;
    public double GetCurrentSongTime()
    {
        return AudioSettings.dspTime - startPlayTime;
    }
    static public AudioSystem Get()
    {
        if (instance == null) Debug.LogError("No AudioSystem");
        return instance;
    }
    void Awake()
    {
        instance = this;
        AudioSource = GetComponent<AudioSource>();
    }

    public void TryPlay()
    {
        AudioSource.loop = false;
        startPlayTime = Time.time;
        AudioSource.PlayOneShot(CurrentClip);
        StartCoroutine(WaitForAudioFinish());
        OnPlay.Invoke(bpm);
    }
    
    private IEnumerator WaitForAudioFinish()
    {
        yield return new WaitUntil(() => AudioSource.isPlaying == false);
        OnFinish.Invoke();
        Debug.Log("Audio clip finished playing!");
    }
}
