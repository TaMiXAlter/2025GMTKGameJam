using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

[RequireComponent(typeof(TMP_Text))]
public class ScoreSystem : MonoBehaviour
{
    static private ScoreSystem instance;
    static public ScoreSystem Get()
    {
        return instance;
    }
    float hit = 0;
    int max;
    TMP_Text text;
    ShowScore showScore;

    float defaultFontSize = 50;
    float maxFontSize = 100;
    float currentFontSize = 50;
    float fontSizeBiggerDelta = 30;
    float fontSizeSmallerDelta = 10;
    bool Greater = false, Smaller = false;
    void Awake()
    {
        instance = this;
        text = GetComponent<TMP_Text>();
        showScore = transform.Find("ShowCase").GetComponent<ShowScore>();
        showScore.gameObject.SetActive(false);
    }
    void Update()
    {
        if (Greater)
        {
            currentFontSize += fontSizeBiggerDelta * Time.deltaTime;
            text.fontSize = currentFontSize;
            if (currentFontSize >= maxFontSize)
            {
                Greater = false;
                Smaller = true;
            }
        }

        if (Smaller)
        {
            currentFontSize -= fontSizeSmallerDelta* Time.deltaTime;
            text.fontSize = currentFontSize;
            if (currentFontSize <= defaultFontSize)
            {
                Smaller = false;
            }
        }
    }
    public void AddHit()
    {
        hit++;
        updateText();
    }
    public void SetMax(int x)
    {
        max = x;
    }
    void updateText()
    {
        text.text = "Hit: " + hit;
        Greater = true;
    }
    public void ShowHitRate()
    {
        showScore.gameObject.SetActive(true);
        showScore.Show(hit, (float)(hit / max));
    }
}
