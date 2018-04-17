using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCreating : MonoBehaviour {
    public GameObject wallPrefab;
    GameObject wall, wall2,wall3;
   
    // Use this for initialization
    void Start () {
        GenerateWall(wallPrefab, new Vector3(0, 5, -7), new Vector3(1, 5, 3), new Vector3(0, 5, 0), new Vector3(1, 5, 5), new Vector3(0, 7, -5), new Vector3(1, 1, 7));
       
        
        
      
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void GenerateWall(GameObject prefab,Vector3 wp1,Vector3 ws1,Vector3 wp2,Vector3 ws2,Vector3 wp3,Vector3 ws3)
    {
        wall = Instantiate(prefab, wp1, Quaternion.identity) as GameObject;
        wall.transform.localScale = ws1;
        wall2 = Instantiate(prefab, wp2, Quaternion.identity) as GameObject;
        wall2.transform.localScale = ws2;
        wall3 = Instantiate(prefab, wp3, Quaternion.identity) as GameObject;
        wall3.transform.localScale = ws3;

    }
}
