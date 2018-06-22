using Framework.References;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ResultsDisplay : MonoBehaviour, IFadeOutListener
{
    public CanvasGroup canvasGroup;
    public Camera renderingCamera;
    public float fadeSpeed;
    public IntReference score;
    public TMPro.TMP_Text scoreText;

    public void OnFadeOut()
    {
        scoreText.text = score.Value.ToString();
        renderingCamera.gameObject.SetActive(true);
        StartCoroutine(DisplayCoroutine());
    }

    private IEnumerator DisplayCoroutine()
    {
        while (canvasGroup.alpha < 1f)
        {
            canvasGroup.alpha += fadeSpeed * Time.deltaTime;
            yield return null;
            renderingCamera.gameObject.SetActive(false);
        }
    }
}
