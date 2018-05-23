using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SegmentCreator : MonoBehaviour
{
    public GameObject segmentPrefab;
    public GameObject parentGO;
    public GameObject Representation;

    private SteamVR_TrackedObject trackedObj;

    private SteamVR_Controller.Device Controller => SteamVR_Controller.Input((int)trackedObj.index);
    private string segmentsPath = Application.dataPath + "/Prefabs/BlockSegments";
    private void Update()
    {
        if (Controller.GetHairTriggerDown())
        {
            CreatePinapple();
        }
        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
        {
            SaveSegment();
        }
    }


    private void CreatePinapple()
    {
        var child = new GameObject();
        child.transform.position = transform.position;
        child.transform.parent = parentGO.transform;
        child.transform.localRotation = Quaternion.identity;
        child.name = "childPinapple";
        Instantiate(Representation, transform.position, Quaternion.identity);

    }
    private void SaveSegment()
    {
        DirectoryInfo levelDirectoryPath = new DirectoryInfo(segmentsPath);
        FileInfo[] fileInfo = levelDirectoryPath.GetFiles("Segment*");
        UnityEditor.PrefabUtility.CreatePrefab(segmentsPath + "Segment" + fileInfo.Length, parentGO);
        Transform parent = parentGO.transform.parent;
        Vector3 pos = parentGO.transform.position;
        Destroy(parentGO);
        parentGO = Instantiate(segmentPrefab, pos, Quaternion.identity,parent);

    }
    private void Awake()
    {
        Debug.Log(segmentsPath);
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }



}
