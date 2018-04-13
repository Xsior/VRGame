using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReloading : MonoBehaviour, IFadeOutListener
{
    public float timeOut;

    public void OnFadeOut ()
    {
        StartCoroutine(ReloadingCoroutine());
    }

    private IEnumerator ReloadingCoroutine ()
    {
        yield return new WaitForSeconds(timeOut);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

