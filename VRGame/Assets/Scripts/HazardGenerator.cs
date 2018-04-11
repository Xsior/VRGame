using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardGenerator : MonoBehaviour
{
    public List<GameObject> walls;
    public List<GameObject> blocks;
    public bool started = true;
    public float TimeToNext = 2;

    private float timer = 2;
    private float toNextWall = 3;

    private void generateBlock ()
    {
        int r = Random.Range(0, blocks.Count);
        float rX = Random.Range(-1.0f, 1.0f);
        float rY = Random.Range(1.0f, 2f);
        GameObject g = Instantiate(blocks[r], Vector3.zero, transform.rotation, transform);
        g.transform.localPosition = new Vector3(rX, rY, 35);
    }
    private void generatWall ()
    {
        int r = Random.Range(0, walls.Count);
        GameObject g = Instantiate(walls[r], Vector3.zero, transform.rotation, transform);
        g.transform.localPosition = new Vector3(0, 0, 35);
    }

    // Update is called once per frame
    void Update ()
    {
        if (started) {
            if (timer > 0) {
                timer -= Time.deltaTime;
            } else {
                if (toNextWall == 0) {
                    generatWall();
                    toNextWall = 3;
                } else {
                    generateBlock();
                    toNextWall--;
                }
                timer = TimeToNext;
                if (TimeToNext > 0.5f)
                    TimeToNext -= 0.02f;
            }
        }
    }
}
