using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowTutorial : MonoBehaviour
{
    public RawImage rawImage;
    public Texture2D[] textures;
    public TMP_Text text;
    bool getBigger = true;
    float delta = 20;
    float maxSize = 60;
    float minSize = 50;
    int currentPage = 0;
    void OnEnable()
    {
        text.text = "Next Page->";
        currentPage = 0;
    }
    void Update()
    {
        if (getBigger)
        {
            text.fontSize += delta * Time.deltaTime;
            if (text.fontSize >= maxSize) getBigger = false;
        }
        else
        {
            text.fontSize -= delta* Time.deltaTime;
            if (text.fontSize <= minSize) getBigger = true;
        }
    }
    public void Next()
    {
        currentPage += 1;
        if (currentPage == 3)
        {
            gameObject.SetActive(false);
            return;
        }

        if (currentPage == 2) text.text = "X end X";
        rawImage.texture = textures[currentPage];

    }
}
