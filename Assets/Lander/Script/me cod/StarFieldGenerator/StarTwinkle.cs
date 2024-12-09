using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarTwinkle : MonoBehaviour
{
    private SpriteRenderer sr;
    private float twinkleSpeed;
    private float minAlpha;
    private float maxAlpha;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        twinkleSpeed = Random.Range(0.3f, 0.9f);
        minAlpha = Random.Range(0.4f, 0.5f);
        maxAlpha = Random.Range(0.5f, 1f);
    }

    void Update()
    {
        float alpha = Mathf.PingPong(Time.time * twinkleSpeed, maxAlpha - minAlpha) + minAlpha;
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, alpha);
    }
}
