using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JuiceFadeIn : MonoBehaviour {

    public float fadeSpeed = 4;
    public Material fadeOutMaterial;
    private bool isTriggered;

    public void FadeIn()
    {
        if (isTriggered)
        {
            return;
        }

        isTriggered = true;
        StartCoroutine(FadeOutCoroutine());
    }

    private IEnumerator FadeOutCoroutine()
    {
        float progress = 0.8f;
        //while (progress < 0.6f)
        //{
        //    fadeOutMaterial.SetFloat("_Progress", progress);
        //    progress += fadeSpeed*20 * Time.deltaTime;

        //    yield return null;
        //}

        fadeOutMaterial.SetFloat("_Progress", 0.8f);

        yield return new WaitForSeconds(0.2f);
        while (progress > 0f)
        {
            fadeOutMaterial.SetFloat("_Progress", progress);
            progress -= fadeSpeed * Time.deltaTime;

            yield return null;
        }
        fadeOutMaterial.SetFloat("_Progress", 0f);
        isTriggered = false;
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (!isTriggered)
        {
            Graphics.Blit(source, destination);
            return;
        }

        Graphics.Blit(source, destination, fadeOutMaterial);
    }

    private void SendFadeOutMessage()
    {
        ExecuteEvents.Execute<IFadeOutListener>(gameObject, null, (handler, data) => handler.OnFadeOut());
    }
}
