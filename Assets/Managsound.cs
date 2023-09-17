using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managsound : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip soundclip1;
    public AudioClip soundclip2;
    public AudioClip soundclip3;
 


    AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.Play();
    }

    // Update is called once per frame
    public void playsound1()
    {
        source.PlayOneShot(soundclip1);
    }
    public void playsound2()
    {
        source.PlayOneShot(soundclip2);
    }
    public void playsound3()
    {
        source.PlayOneShot(soundclip3);
    }
}
