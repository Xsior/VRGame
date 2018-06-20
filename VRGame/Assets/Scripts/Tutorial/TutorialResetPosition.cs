using UnityEngine;

public class TutorialResetPosition : TutorialResetTrigger
{
    private Vector3 initialPosition;

    public override void Reset()
    {
        transform.position = initialPosition;
    }

    private void Start()
    {
        initialPosition = transform.position;
    }
}