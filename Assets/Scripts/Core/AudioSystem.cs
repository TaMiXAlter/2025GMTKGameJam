using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class AudioSystem : MonoBehaviour
{
    static private AudioSystem instance;
    public AudioClip CurrentClip;
    public UnityEvent<float> OnPlay;
    [HideInInspector]
    public float bpm;
    private AudioSource AudioSource;

    static public AudioSystem Get()
    {
        if (instance == null) Debug.LogError("No AudioSystem");
        return instance;
    }
    void Awake()
    {
        instance = this;
        AudioSource = GetComponent<AudioSource>();

        bpm = 150;
    }

    public void TryPlay()
    {
        AudioSource.clip = CurrentClip;
        AudioSource.loop = true;
        AudioSource.Play();
        OnPlay.Invoke(bpm);
    }
}
