using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Texts : MonoBehaviour
{
    public Image image; // ссылка на компонент Image
    public float delayTime = 2.0f; // задержка перед началом плавного появления
    public float fadeInTime = 1.0f; // время плавного появления

    public string sceneName; // Имя сцены, на которую вы хотите перейти
    public float transitionDelay = 4.0f; // Задержка перед переходом

    public AudioSource Sound;

    void Start()
    {
        StartCoroutine(StartDelayedFadeIn());

        StartCoroutine(StartTransition());
    }

    IEnumerator StartTransition()
    {
        yield return new WaitForSeconds(transitionDelay); // Ожидаем заданное количество времени перед переходом на новую сцену

        SceneManager.LoadScene(sceneName); // Переходим на новую сцену
    }

    IEnumerator StartDelayedFadeIn()
    {
        yield return new WaitForSeconds(delayTime); // Ожидаем заданное количество времени перед началом плавного появления

        StartCoroutine(FadeInImage()); // Запускаем плавное появление изображения
    }

    IEnumerator FadeInImage()
    {
        Sound.Play();

        Color initialColor = image.color;
        Color targetColor = new Color(initialColor.r, initialColor.g, initialColor.b, 1.0f); // Устанавливаем конечный альфа-канал на 1 (полностью непрозрачный)

        float currentTime = 0.0f;

        while (currentTime < fadeInTime)
        {
            currentTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0.0f, 1.0f, currentTime / fadeInTime); // Интерполируем значение альфа-канала между 0 и 1
            image.color = new Color(initialColor.r, initialColor.g, initialColor.b, alpha);
            yield return null;
        }

        image.color = targetColor; // Устанавливаем альфа-канал в конечное значение, чтобы избежать ошибок округления.
    }
}
