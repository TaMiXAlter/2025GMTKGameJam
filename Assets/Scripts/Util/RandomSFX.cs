using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RandomSFX : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip[] audioClips;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        int randNum = Random.Range(0, 2);
        audioSource.PlayOneShot(audioClips[randNum]);
    }
}
