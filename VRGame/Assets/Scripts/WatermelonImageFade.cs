using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WatermelonImageFade : MonoBehaviour {

    [SerializeField]
    private float timeShown = 0.8f;
    [SerializeField]
    private Image UiImage;
    private float timer = 0;
    private bool showSplat = false;

    public void OnHit()
    {
        showSplat = true;
        timer = 0;
    }




    void Update()
    {
        if (showSplat)
        {
            Color spriteColor = UiImage.color;
            if (timer >= timeShown)
            {
                spriteColor.a = 0f;
                showSplat = false;
            }
            else
            {
                timer += Time.deltaTime;
                spriteColor.a = (timeShown - timer) / timeShown;
            }

            UiImage.color = spriteColor;
        }
    }
}
