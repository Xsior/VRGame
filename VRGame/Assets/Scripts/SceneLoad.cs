using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour, IHitListener
{
    public String SceneName;

    public void OnHit(Collision collision)
    {
        SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
    }

}
