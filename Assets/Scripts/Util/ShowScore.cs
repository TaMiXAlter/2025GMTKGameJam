using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowScore : MonoBehaviour
{
    public TMP_Text Hit, HitRate;
    private AudioSource audioSource;
    [SerializeField] private AudioClip Cheering;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Show(float pHit, float pHitRate)
    {
        audioSource.PlayOneShot(Cheering);
        Hit.text = pHit.ToString();
        HitRate.text = pHitRate.ToString("#.##") + " %";
    }

    public void BackToMain()
    {
        SceneManager.LoadScene(0);
    }
}
