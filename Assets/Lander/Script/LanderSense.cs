using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Audio;




public class LanderSense : MonoBehaviour
{

    public bool Chrashed;
    public bool Landed;
    public bool Lost;
    public bool Runnings;
    public double LandingVelocity;
    public AudioSource ChrashSound;
    public AudioSource CrashVoice;
    public AudioSource LostVoice;
    public AudioSource Break;


    void OnTriggerEnter2D(Collider2D col)
    {

    }

    void Start()
    {
        AudioSource audioSource = GetComponent<AudioSource>();

        InvokeRepeating("DecreaseVariable", 0.5f, 0.5f);

    }

    void DecreaseVariable()
    {
       
        if (GlobalData.GlobalDataCarrier.Fuel == 0 || GlobalData.GlobalDataCarrier.Fuel < 0)
        {
            GlobalData.GlobalDataCarrier.isCrashed = true;
        } else
        {
            GlobalData.GlobalDataCarrier.Fuel -= 1f;

        }

        // Добавьте дополнительные действия при уменьшении переменной, если необходимо
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {  
            Chrashed = true;
            GlobalData.GlobalDataCarrier.isCrashed = true;

            CrashVoice.Play();

        }
        else if (col.gameObject.CompareTag("Platform"))
        {
            if (!Landed)
            {
                LostVoice.Play();
                Landed = true;
                Chrashed = true;
            }          
        } 
        else if (col.gameObject.CompareTag("Background"))
        {    
            Lost = true;

            Break.Play();
        }
    }
}



