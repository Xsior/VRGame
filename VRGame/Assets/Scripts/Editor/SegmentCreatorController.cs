using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentCreatorController : MonoBehaviour
{

    private SteamVR_TrackedObject trackedObj;

    private SteamVR_Controller.Device Controller => SteamVR_Controller.Input((int)trackedObj.index);
    private SegmentCreator segmentCreator;


    private void Update()
    {
        if (Controller.GetHairTriggerDown())
        {
            segmentCreator.CreatePinapple(transform.position);
        }
        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
        {
            segmentCreator.SaveSegment();
        }
    }
    private void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }
    private void Start()
    {
        segmentCreator = FindObjectOfType<SegmentCreator>();
    }
}
