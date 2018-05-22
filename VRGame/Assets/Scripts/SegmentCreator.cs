using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentCreator : MonoBehaviour {

    public GameObject parentGO;
    public GameObject Representation;

    private SteamVR_TrackedObject trackedObj;

    private SteamVR_Controller.Device Controller => SteamVR_Controller.Input((int)trackedObj.index);

    private void Update()
    {
        if (Controller.GetHairTriggerDown())
        {
            CreatePinapple();
        }
    }


    private void CreatePinapple()
    {
        var child = new GameObject();
        child.transform.position = transform.position;
        child.transform.parent = parentGO.transform;
        child.transform.localRotation = Quaternion.identity;
        child.name = "childPinapple";
        Instantiate(Representation,transform.position,Quaternion.identity);

    }

    private void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }



}
