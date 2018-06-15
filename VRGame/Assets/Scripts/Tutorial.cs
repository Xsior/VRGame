using System.Collections;
using System.Collections.Generic;
using Framework.Events;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [Header("Control fields")]
    public HazardGenerator hazardGenerator;
    public GameObject tutorialUI;
    public GameObject[] tutorialTexts;
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
        isHazardDestroyed = true;
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
        hazardGenerator.enabled = false;

        tutorialUI.SetActive(true);

        foreach (var text in tutorialTexts) {
            text.SetActive(true);
            yield return new WaitForSeconds(textWaitTime);
        }

        yield return new WaitForSeconds(hazardAppearenceTime);

        Instantiate(pinapplePrefab, hazardSpawnPoint.position, Quaternion.identity);

        yield return waitForHazardDestroy;

        isHazardDestroyed = false;

        yield return new WaitForSeconds(1f);

        watemelonUI.SetActive(true);

        yield return new WaitForSeconds(2f);

        Instantiate(watermelonPrefab, hazardSpawnPoint.position, watermelonPrefab.transform.rotation);

        yield return waitForHazardDestroy;

        isHazardDestroyed = false;
        
        watemelonUI.SetActive(false);
        tutorialUI.SetActive(false);
        
        mushroomEvent.Raise();

        Instantiate(mushroomPrefab, mushroomSpawnPoint.position, mushroomSpawnPoint.rotation);

        yield return new WaitForSeconds(4f);

        mushroomUI.SetActive(true);

        mushroomEvent.Raise();
        
        Instantiate(pinapplePrefab, hazardSpawnPoint.position, Quaternion.identity);

        yield return waitForHazardDestroy;

        isHazardDestroyed = false;

        mushroomUI.SetActive(false);
        
        hazardGenerator.enabled = true;
    }

    private bool IsHazardDestroyed()
    {
        return isHazardDestroyed;
    }
}
