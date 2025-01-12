using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField]
    private List<AudioClip> soundClips; // Список звуков

    private AudioSource audioSource;

    void Start()
    {
        // Получаем ссылку на компонент AudioSource
        audioSource = GetComponent<AudioSource>();
    }

    // Функция для воспроизведения определенного звука по индексу
    public void PlaySound(int index)
    {
        if (index < soundClips.Count && audioSource != null)
        {
            audioSource.clip = soundClips[index];
            audioSource.Play();
        }
    }
}
