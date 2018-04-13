﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFadeOut : MonoBehaviour
{
    public float fadeSpeed = 4;
    public Material fadeOutMaterial;

    private bool isPressed;

    public void FadeOut ()
    {
        isPressed = true;
        StartCoroutine(FadeOutCoroutine());
    }

    private IEnumerator FadeOutCoroutine ()
    {
        float progress = 0f;
        while (progress < 1f) {
            fadeOutMaterial.SetFloat("_Progress", progress);
            progress += fadeSpeed * Time.deltaTime;

            yield return null;
        }

        fadeOutMaterial.SetFloat("_Progress", 1f);
    }

    private void OnRenderImage (RenderTexture source, RenderTexture destination)
    {
        if (!isPressed) {
            Graphics.Blit(source, destination);
            return;
        }

        Graphics.Blit(source, destination, fadeOutMaterial, 0);
    }
}
