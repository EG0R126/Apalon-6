using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{

    public GameObject Sou;
    new AudioSource audio;
    public AudioClip corect;
    public int Time;

    public void SoundPlay()
    {
        audio = GetComponent<AudioSource>();
        DontDestroyOnLoad(Sou);
        audio.PlayOneShot(corect);
        Destroy(Sou, Time);
    }
}