using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SegmentCreator : MonoBehaviour
{
    public GameObject segmentPrefab;
    public GameObject parentGO;
    public GameObject Representation;
    public GameObject pivot;

    private SteamVR_TrackedObject trackedObj;

    private SteamVR_Controller.Device Controller => SteamVR_Controller.Input((int)trackedObj.index);
    private string segmentsPath;
    private List<GameObject> representations = new List<GameObject>();


    public void CreatePinapple(Vector3 pos)
    {
        var child = new GameObject();
        child.transform.position = pos;
        child.transform.parent = parentGO.transform;
        child.transform.localRotation = Quaternion.identity;
        child.name = "childPinapple";
        representations.Add(Instantiate(Representation, pos, Quaternion.identity));

    }
    public void SaveSegment()
    {
        if (representations.Count != 0)
        {
            DirectoryInfo levelDirectoryPath = new DirectoryInfo(segmentsPath);
            FileInfo[] fileInfo = levelDirectoryPath.GetFiles("Segment*");
            UnityEditor.PrefabUtility.CreatePrefab(segmentsPath + "/Segment" + fileInfo.Length/2 + ".prefab", parentGO);
            Transform parent = parentGO.transform.parent;
            Vector3 pos = parentGO.transform.position;
            Destroy(parentGO);
            foreach (GameObject g in representations)
            {
                Destroy(g);
            }
            parentGO = Instantiate(segmentPrefab, pos, Quaternion.identity, parent);
            Debug.Log("Segment" + fileInfo.Length + ".prefab created!");
        }

    }
    private void Awake()
    {
        segmentsPath = "Assets/Prefabs/BlockSegments";
        Debug.Log(segmentsPath);

    }

    private void Start()
    {
        float PlayerHeight = Camera.main.transform.localPosition.y;
        if (PlayerHeight < 1.2f)
            PlayerHeight = 1.2f;
        else if (PlayerHeight > 2f)
            PlayerHeight = 2f;

        pivot.transform.localPosition = new Vector3(0, PlayerHeight - 0.2f, 1);
        segmentPrefab.transform.position = pivot.transform.position;
    }



}
