using UnityEngine;

public class TutorialControllersDisable : MonoBehaviour
{
    private MeshRenderer[] renderers;
    private Collider[] colliders;

    private bool mushroomAppeared;

    public void OnMushroomAppeared()
    {
        mushroomAppeared = !mushroomAppeared;
        Toggle(!mushroomAppeared);
    }

    private void Toggle(bool isActive)
    {
        foreach (var meshRenderer in renderers) {
            meshRenderer.enabled = isActive;
        }

        foreach (var collider in colliders) {
            collider.enabled = isActive;
        }
    }

    private void Awake()
    {
        renderers = GetComponentsInChildren<MeshRenderer>();
        colliders = GetComponentsInChildren<Collider>();
    }
}