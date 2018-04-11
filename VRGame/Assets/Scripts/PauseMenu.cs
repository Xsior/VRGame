using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject baseObject;

    public void Open ()
    {
        baseObject.SetActive(true);
    }

    public void Close ()
    {
        baseObject.SetActive(false);
    }

    private void Start ()
    {
        Open();
    }
}
