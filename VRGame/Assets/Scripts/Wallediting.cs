﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallediting : MonoBehaviour {
    bool creating;
    public GameObject start;
    public GameObject end;
    public GameObject wallPrefab;
    GameObject wall;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        getInput();
    }

    void getInput()
    {
        if (Input.GetMouseButtonDown(0))
        {

            SetStart();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            SetEnd();
        }
        else
        {
            if (creating)
            {


                Adjust();
            }
        }
    }
    void SetStart()
    {
        creating = true;
        start.transform.position = getWorldPoint();
        wall = Instantiate(wallPrefab, start.transform.position, Quaternion.identity) as GameObject;
    }
    void SetEnd()
    {
        creating = false;
        end.transform.position = getWorldPoint();
    }
    void Adjust() {
        end.transform.position = getWorldPoint();
        AdjustWall();
    }
    void AdjustWall() {
        start.transform.LookAt(end.transform.position);
        start.transform.LookAt(start.transform.position);
        float distance = Vector3.Distance(start.transform.position, end.transform.position);
        wall.transform.position = start.transform.position + distance / 2*start.transform.forward;
        wall.transform.rotation = start.transform.rotation;
        wall.transform.localScale = new Vector3(wall.transform.localScale.x, wall.transform.localScale.y, distance);
    }
    Vector3 getWorldPoint() {
        Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            return hit.point;
        }return new Vector3(0,0,0);
    } 
}
