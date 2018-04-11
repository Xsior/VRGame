using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VRControllerInput : MonoBehaviour
{
    public UnityEvent onHairTriggerDown;

    private SteamVR_TrackedObject trackedObj;

    private SteamVR_Controller.Device Controller => SteamVR_Controller.Input((int)trackedObj.index);

    private void Update ()
    {
        if (Controller.GetHairTriggerDown()) {
            onHairTriggerDown.Invoke();
        }
    }

    private void Awake ()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

}
