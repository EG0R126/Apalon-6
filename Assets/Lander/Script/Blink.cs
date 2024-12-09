using UnityEngine;
using System.Collections;

public class Blink : MonoBehaviour {
    public Light ThisLight;
    public int Number = 1;
    public float Timeon;
    public float Timeoff;


    // Use this for initialization
    void Start()
    {
        Light ThisLight = GetComponent<Light>();        
        Number = 1;
        ThisLight.intensity= 0;        
    }

    // Update is called once per frame
    void Update()
    {
        Light ThisLight = GetComponent<Light>();
        if (Number == 1)
        {
            ThisLight.intensity = 0;
            StartCoroutine(waitfornext1(Timeoff));
        }
        if (Number == 2)
        {
            ThisLight.intensity = 1;
            StartCoroutine(waitfornext2(Timeon));
        }
    }

    IEnumerator waitfornext1(float Tid)
    {
        yield return new WaitForSeconds(Tid);
        Number = 2;
    }

    IEnumerator waitfornext2(float Tid)
    {
        yield return new WaitForSeconds(Tid);
        Number = 1;
    }
}
