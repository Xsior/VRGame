using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffectsManager : MonoBehaviour, IHitListener
{
    public AudioClip crashSoft;
    public AudioClip crashHard;


    private AudioSource source;
    private float lowPitchRange = .75F;
    private float highPitchRange = 1.5F;
    private float velToVol = .2F;
    private float velocityClipSplit = 10F;





    public void OnHit(Collision collision)
    {
        source.pitch = Random.Range(lowPitchRange, highPitchRange);
        float hitVol = collision.relativeVelocity.magnitude * velToVol;
        if (collision.relativeVelocity.magnitude < velocityClipSplit)
            source.PlayOneShot(crashSoft, hitVol);
        
        else 
            source.PlayOneShot(crashHard, hitVol);
    }
}
