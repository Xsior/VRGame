using UnityEngine;

public class TutorialTrigger : MonoBehaviour, IHitListener
{
    public Tutorial tutorial;
    
    public void OnHit(Collision collision)
    {
        tutorial.enabled = true;
    }
}