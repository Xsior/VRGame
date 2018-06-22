using System.Collections;
using System.Collections.Generic;
using Framework.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    [Header("Control fields")]
    public GameObject pizzaHint;
    public GameObject pinappleHint;
    public GameObject watermelonHint;
    public GameObject mushroomHint;
    public GameObject finishTrigger;

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

    public string sceneName;

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
        isHazardDestroyed = false;
        StartCoroutine(TutorialCoroutine());
    }

    private void Awake()
    {
        waitForHazardDestroy = new WaitUntil(IsHazardDestroyed);
    }

    private IEnumerator TutorialCoroutine()
    {
        yield return new WaitForSeconds(textWaitTime);

        pizzaHint.SetActive(true);

        yield return new WaitForSeconds(3f);

        pizzaHint.SetActive(false);
        pinappleHint.SetActive(true);

        yield return new WaitForSeconds(hazardAppearenceTime);

        Instantiate(pinapplePrefab, hazardSpawnPoint.position, Quaternion.identity);

        yield return waitForHazardDestroy;

        isHazardDestroyed = false;

        yield return new WaitForSeconds(1f);
        
        pinappleHint.SetActive(false);

        watermelonHint.SetActive(true);

        yield return new WaitForSeconds(2f);

        Instantiate(watermelonPrefab, hazardSpawnPoint.position, watermelonPrefab.transform.rotation);

        yield return waitForHazardDestroy;

        isHazardDestroyed = false;
        
        watermelonHint.SetActive(false);
        mushroomHint.SetActive(true);
        
        yield return new WaitForSeconds(3f);

        Instantiate(mushroomPrefab, mushroomSpawnPoint.position, mushroomSpawnPoint.rotation);

        yield return waitForHazardDestroy;

        isHazardDestroyed = false;
        mushroomHint.SetActive(false);

        finishTrigger.SetActive(true);

        yield return waitForHazardDestroy;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private bool IsHazardDestroyed()
    {
        return isHazardDestroyed;
    }
}
