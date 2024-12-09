using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;


public class PlayerControl : MonoBehaviour
{
    public float force;
    public float torque;
    public float Activeforce = 0.0f;
    public float Activetorque = 0.0f;
    public float timeRemaining;
    public Text FuelText;
    public Text ScoreText;
    public Text TimeText;
    public Text VelocityText;
    public Text LevelText;
    public float Burner1 = 2.0f;
    public float Burner2 = 1.5f;
    public float Burner3 = 1.5f;
    public float Launch = 0f;

    private int score;
    private Transform Co;

    public ParticleSystem ps;
    public ParticleSystem ps2;

    public bool AndroidPushed;

    public AudioSource RocketAudio;
    public AudioSource ThrustAudio;
    public Sprite[] LanderSprites;

    void Start()
    {
        AudioSource[] audios = GetComponents<AudioSource>();
        RocketAudio = audios[0];
        ThrustAudio = audios[1];
        GlobalData.GlobalDataCarrier.LandedStatus = false;
        GlobalData.GlobalDataCarrier.LandedStatusOk = false;
    }

    void Update()
    {
        Movement();
        CheckCrashed();
        timeRemaining -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("Break");
        }
    }

    void Movement()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        Activeforce = 0;
        Activetorque = 0;

        UpdateUI();
        AndroidPushed = false;

        if (GlobalData.GlobalDataCarrier.Fuel > 0)
        {
            if (Input.GetKey(KeyCode.W))
            {
                AndroidPushed = true;
                Activeforce = force;
                PlayRocketAudio();
            }

            if (Input.GetKey(KeyCode.A))
            {
                Activetorque = torque;
                PlayThrustAudio();
            }

            if (Input.GetKey(KeyCode.D))
            {
                Activetorque = -torque;
                PlayThrustAudio();
            }

            if (Input.GetKey(KeyCode.A) & !Input.GetKey(KeyCode.W) & Input.GetKey(KeyCode.D))
            {
                Activetorque = 0;
                Activeforce = force;
            }

            if (Input.GetKey(KeyCode.A) & Input.GetKey(KeyCode.W) & Input.GetKey(KeyCode.D))
            {
                Activetorque = 0;
                Activeforce = force * 2;
                PlayRocketAudio();
                PlayThrustAudio();
            }

            rb.AddForce(transform.up * Activeforce, ForceMode2D.Force);
            rb.AddTorque(Activetorque, ForceMode2D.Force);

            UpdateSpriteAndFuelConsumption();
        }
        else
        {
            UpdateFuelSpriteAndFuelConsumption();
        }
    }

    void UpdateUI()
    {
        UpdateFuelText();
        UpdateTimeText();
        UpdateVelocityText();
    }

    void UpdateFuelText()
    {
        FuelText.text = ("Топлива: " + Math.Round(GlobalData.GlobalDataCarrier.Fuel).ToString() + " Литр");
    }

    void UpdateTimeText()
    {
        TimeText.text = ("Time: " + Math.Round(timeRemaining).ToString());
    }

    void UpdateVelocityText()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        VelocityText.text = ("Скорость: " + Math.Round(Vector2.SqrMagnitude(rb.linearVelocity) * 10).ToString() + " Км");
    }

    void CheckCrashed()
    {
        ps2 = transform.GetChild(1).gameObject.GetComponent<ParticleSystem>();
        if (GlobalData.GlobalDataCarrier.isCrashed == true)
        {
            if (GlobalData.GlobalDataCarrier.Fuel > 0f)
            {
                if (ps2.isStopped)
                {
                    ps2.Play();
                }
                GlobalData.GlobalDataCarrier.isCrashed = false;
            }
        }
    }

    void PlayRocketAudio()
    {
        if (!RocketAudio.isPlaying)
        {
            RocketAudio.Play();
        }
    }

    void PlayThrustAudio()
    {
        if (!ThrustAudio.isPlaying)
        {
            ThrustAudio.Play();
        }
    }

    void UpdateSpriteAndFuelConsumption()
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (Activeforce < (force * 2))
        {
            if (Activeforce != 0 & Activetorque == 0)
            {
                spriteRenderer.sprite = LanderSprites[1];
                RocketEngineSmoke(0.4f, 6.0f);
                GlobalData.GlobalDataCarrier.Fuel -= Burner1;
            }
            else if (Activeforce == 0 & Activetorque > 0)
            {
                spriteRenderer.sprite = LanderSprites[3];
                RocketEngineSmoke(0.2f, 3.0f);
                GlobalData.GlobalDataCarrier.Fuel -= Burner2;
            }
            else if (Activeforce == 0 & Activetorque < 0)
            {
                spriteRenderer.sprite = LanderSprites[2];
                RocketEngineSmoke(0.2f, 3.0f);
                GlobalData.GlobalDataCarrier.Fuel -= Burner2;
            }
            else if (Activeforce != 0 & Activetorque > 0)
            {
                spriteRenderer.sprite = LanderSprites[4];
                RocketEngineSmoke(0.5f, 8.0f);
                GlobalData.GlobalDataCarrier.Fuel -= Burner1 + Burner2;
            }
            else if (Activeforce != 0 & Activetorque < 0)
            {
                spriteRenderer.sprite = LanderSprites[5];
                RocketEngineSmoke(0.5f, 8.0f);
                GlobalData.GlobalDataCarrier.Fuel -= Burner1 + Burner3;
            }
            else
            {
                spriteRenderer.sprite = LanderSprites[0];
                RocketEngineSmoke(0.2f, 1.0f);
            }
        }
        else
        {
            spriteRenderer.sprite = LanderSprites[6];
            RocketEngineSmoke(0.8f, 10.0f);
            GlobalData.GlobalDataCarrier.Fuel -= Burner1 + Burner2 + Burner3;
        }
    }

    void UpdateFuelSpriteAndFuelConsumption()
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = LanderSprites[0];
        RocketEngineSmoke(0.1f, 1.0f);
    }

    void RocketEngineSmoke(float smokeForce, float smokeSpeed)
    {
        ps = transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
        ps.startSize = smokeForce;
        ps.startSpeed = smokeSpeed;
        if (ps.isStopped)
        {
            ps.Play();
        }
    }
}
