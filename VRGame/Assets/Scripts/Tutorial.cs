using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [Header("Control fields")]
    public HazardGenerator hazardGenerator;
    public GameObject tutorialUI;
    public GameObject[] tutorialTexts;

    [Space]
    public GameObject hazardPrefab;
    public Transform hazardSpawnPoint;

    [Header("Tutorial parameters")]
    public float textWaitTime;
    public float hazardAppearenceTime;

    private bool isHazardDestroyed;

    public void OnHazardDestroyed()
    {
        isHazardDestroyed = true;
    }

    private void Start()
    {
        StartCoroutine(TutorialCoroutine());
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

        Instantiate(hazardPrefab, hazardSpawnPoint.position, Quaternion.identity);

        yield return new WaitUntil(() => isHazardDestroyed);

        tutorialUI.SetActive(false);
        hazardGenerator.enabled = true;
    }
}
