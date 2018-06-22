using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSoundManager : MonoBehaviour {


    public List<AudioClip> watermelon_Hit;
    public List<AudioClip> pinapple_Hit;
    public List<AudioClip> mushroom_Hit;

    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Watermelon")
        {
            source.clip = watermelon_Hit[Random.Range(0, watermelon_Hit.Count)];
            source.Play();
        }
        else if (collision.gameObject.tag == "Pinapple")
        {
            source.clip = pinapple_Hit[Random.Range(0, pinapple_Hit.Count)];
            source.Play();
        }
        else if (collision.gameObject.tag == "Mushroom")
        {
            source.clip = mushroom_Hit[Random.Range(0, mushroom_Hit.Count)];
            source.Play();
        }

    }




}
