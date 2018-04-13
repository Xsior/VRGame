using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardGenerator : MonoBehaviour
{
    public List<GameObject> walls;
    public List<GameObject> blocks;
    public bool started = true;
    public float TimeToNext = 3.5f;
    public float startSpeed = 5;
    public float distanceBetweenSegmentsd = 5;

    private float currentSpeed = 5;
    private float timer = 2;
    private float toNextWall = 3;

    private void generateBlock()
    {
        int r = Random.Range(0, blocks.Count);
        GameObject g = Instantiate(blocks[r], Vector3.zero, transform.rotation, transform);
        BlocksSegment b = g.GetComponent<BlocksSegment>();
        g.transform.localPosition = new Vector3(0, 1, 35);
        b.setSpeed(new Vector3(0, 0, -currentSpeed));
        float length;
        if (b.length == 0)
        {
            length = b.getLength();
        }
        else
        {
            length = b.length;
        }
        Debug.Log(length);
        timer = (length + distanceBetweenSegmentsd) / currentSpeed;
    }
    private void generatWall()
    {
        int r = Random.Range(0, walls.Count);
        GameObject g = Instantiate(walls[r], Vector3.zero, transform.rotation, transform);
        g.transform.localPosition = new Vector3(0, 0, 35);
        
    }

    void Start()
    {
        currentSpeed = startSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (started)
        {
            if (timer > 0)
            {
                timer -= Time.fixedDeltaTime;
            }
            else {
                /*if (toNextWall == 0) {
                    //generatWall();
                    generateBlock();
                    toNextWall = 3;
                } else {*/
                generateBlock();
                toNextWall--;
                // }
                //timer = TimeToNext;
                currentSpeed += 0.05f;
                if (TimeToNext > 1.5f)
                    TimeToNext -= 0.02f;
            }
        }
    }
}
