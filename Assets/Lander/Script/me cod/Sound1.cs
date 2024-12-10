using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundPlayer : MonoBehaviour
{
    public static SoundPlayer instance; // Static variable to hold the single instance of the class
    public GameObject soundObject;
    private AudioSource audioSource;
    public AudioClip correctSound;
    public AudioClip[] randomSounds; // Массив случайных звуков
    public float fadeDuration = 1f; // Длительность затухания и появления звука
    public int Time;


    private void Awake()
    {
            // Make sure only one instance of this script exists
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject); // Don't destroy the object when loading a new scene
            }
            else
            {
                Destroy(gameObject); // Destroy script duplicates
            }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        UpdateSound();
    }

    private void Update()
    {
            // Проверяем, если сцена изменилась
            if (SceneManager.GetActiveScene().name != previousScene)
            {
                UpdateSound();
            }
    }

    public void Sound_off_on()
    {
        if (GlobalData.GlobalDataCarrier.StateMusiic)
        {
            audioSource.enabled = false;
            Debug.Log("Выключен");
        }
        else
        {
            Debug.Log("Включён");
            audioSource.enabled = true;
        }
    }

    private string previousScene; // Переменная для хранения предыдущей сцены

    private void UpdateSound()
    {
            // Сохраняем текущую сцену
            previousScene = SceneManager.GetActiveScene().name;

            // Проверяем текущую активную сцену
            if (previousScene == "Manu_Scene" || previousScene == "StartScene")
            {
                if (!audioSource.isPlaying)
                {
                    StartCoroutine(FadeInMusic(correctSound));
                }
            }
            else
            {
                // Если не "Manu_Scene" или "StartScene", выбираем случайный звук из массива
                StartCoroutine(FadeInMusic(randomSounds[Random.Range(0, randomSounds.Length)]));
            }
    }

    private IEnumerator FadeInMusic(AudioClip clip)
    {
            // Постепенное включение музыки
            audioSource.clip = clip;
            audioSource.Play();
            while (audioSource.volume < 1)
            {
                audioSource.volume += UnityEngine.Time.deltaTime / fadeDuration;
                yield return null;
            }
    }

    private IEnumerator FadeOutMusic()
    {
            // Постепенное выключение музыки
            while (audioSource.volume > 0)
            {
                audioSource.volume -= UnityEngine.Time.deltaTime / fadeDuration;
                yield return null;
            }
            audioSource.Stop();
    }

    public void PlaySound()
    {
            StartCoroutine(FadeOutMusic());
    }
}