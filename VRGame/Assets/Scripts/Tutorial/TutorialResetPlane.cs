using UnityEngine;

public class TutorialResetPlane : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var trigger = other.GetComponent<TutorialResetTrigger>();
        if (trigger != null) {
            trigger.Reset();
        }
    }
}