using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionBlurON : MonoBehaviour
{

    public bool isTriggered;
    public Material motionmaterial;
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (!isTriggered)
        {
            Graphics.Blit(source, destination);
            return;
        }

        Graphics.Blit(source, destination, motionmaterial);
    }

}
