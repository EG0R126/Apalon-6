using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField]
    private List<AudioClip> soundClips; // ������ ������

    private AudioSource audioSource;

    void Start()
    {
        // �������� ������ �� ��������� AudioSource
        audioSource = GetComponent<AudioSource>();
    }

    // ������� ��� ��������������� ������������� ����� �� �������
    public void PlaySound(int index)
    {
        if (index < soundClips.Count && audioSource != null)
        {
            audioSource.clip = soundClips[index];
            audioSource.Play();
        }
    }
}
