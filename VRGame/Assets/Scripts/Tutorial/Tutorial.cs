using System.Collections;
using System.Collections.Generic;
using Framework.Events;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [Header("Control fields")]
    public GameObject tutorialUI;
    //public GameObject[] tutorialTexts;
    public GameObject watemelonUI;
    public GameObject mushroomUI;

    [Space]
    public GameObject pinapplePrefab;
    public GameObject watermelonPrefab;
    public GameObject mushroomPrefab;
    public Transform hazardSpawnPoint;
    public Transform mushroomSpawnPoint;

    public GameEvent mushroomEvent;
    
    [Header("Tutorial parameters")]
    public float textWaitTime;
    public float hazardAppearenceTime;

    private bool isHazardDestroyed;
    private WaitUntil waitForHazardDestroy;

    public void OnHazardDestroyed()
    {
        if (isActiveAndEnabled) {
            isHazardDestroyed = true;
        }
    }

    private void Start()
    {
        StartCoroutine(TutorialCoroutine());
    }

    private void Awake()
    {
        waitForHazardDestroy = new WaitUntil(IsHazardDestroyed);
    }

    private IEnumerator TutorialCoroutine()
    {
        yield return new WaitForSeconds(textWaitTime);
        
        tutorialUI.SetActive(true);

        yield return new WaitForSeconds(hazardAppearenceTime);

        Instantiate(pinapplePrefab, hazardSpawnPoint.position, Quaternion.identity);

        yield return waitForHazardDestroy;

        isHazardDestroyed = false;

        yield return new WaitForSeconds(1f);
        
        tutorialUI.SetActive(false);

        watemelonUI.SetActive(true);

        yield return new WaitForSeconds(2f);

        Instantiate(watermelonPrefab, hazardSpawnPoint.position, watermelonPrefab.transform.rotation);

        yield return waitForHazardDestroy;

        isHazardDestroyed = false;
        
        watemelonUI.SetActive(false);
        mushroomUI.SetActive(true);
        
        yield return new WaitForSeconds(3f);

        Instantiate(mushroomPrefab, mushroomSpawnPoint.position, mushroomSpawnPoint.rotation);

        yield return waitForHazardDestroy;

        mushroomUI.SetActive(false);
    }

    private bool IsHazardDestroyed()
    {
        return isHazardDestroyed;
    }
}
