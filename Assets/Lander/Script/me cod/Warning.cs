using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    //public AudioClip WarningSound;
    public AudioSource audioSource;
    private int start = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (start == 0)
        {
            if (GlobalData.GlobalDataCarrier.Fuel <= 100f)
            {
                start = 1;
                audioSource.Play();
            }
        }
    }
}
