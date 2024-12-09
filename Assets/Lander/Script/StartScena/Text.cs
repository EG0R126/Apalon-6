using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Texts : MonoBehaviour
{
    public Image image; // ������ �� ��������� Image
    public float delayTime = 2.0f; // �������� ����� ������� �������� ���������
    public float fadeInTime = 1.0f; // ����� �������� ���������

    public string sceneName; // ��� �����, �� ������� �� ������ �������
    public float transitionDelay = 4.0f; // �������� ����� ���������

    public AudioSource Sound;

    void Start()
    {
        StartCoroutine(StartDelayedFadeIn());

        StartCoroutine(StartTransition());
    }

    IEnumerator StartTransition()
    {
        yield return new WaitForSeconds(transitionDelay); // ������� �������� ���������� ������� ����� ��������� �� ����� �����

        SceneManager.LoadScene(sceneName); // ��������� �� ����� �����
    }

    IEnumerator StartDelayedFadeIn()
    {
        yield return new WaitForSeconds(delayTime); // ������� �������� ���������� ������� ����� ������� �������� ���������

        StartCoroutine(FadeInImage()); // ��������� ������� ��������� �����������
    }

    IEnumerator FadeInImage()
    {
        Sound.Play();

        Color initialColor = image.color;
        Color targetColor = new Color(initialColor.r, initialColor.g, initialColor.b, 1.0f); // ������������� �������� �����-����� �� 1 (��������� ������������)

        float currentTime = 0.0f;

        while (currentTime < fadeInTime)
        {
            currentTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0.0f, 1.0f, currentTime / fadeInTime); // ������������� �������� �����-������ ����� 0 � 1
            image.color = new Color(initialColor.r, initialColor.g, initialColor.b, alpha);
            yield return null;
        }

        image.color = targetColor; // ������������� �����-����� � �������� ��������, ����� �������� ������ ����������.
    }
}
