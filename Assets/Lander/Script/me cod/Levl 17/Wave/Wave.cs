using System.Collections;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public float minScale = 0.5f; // Минимальный начальный размер волны
    public float maxScale = 2f; // Максимальный конечный размер волны
    public float minSpeed = 10f; // Минимальная скорость вращения
    public float maxSpeed = 50f; // Максимальная скорость вращения
    public float fadeDuration = 1f; // Время, за которое волна исчезает
    public float minWaitTime = 0.5f; // Минимальное время до следующей волны
    public float maxWaitTime = 5f; // Максимальное время до следующей волны

    private SpriteRenderer spriteRenderer; // Компонент для управления прозрачностью
    private float targetScale; // Конечный размер волны
    private float rotationSpeed; // Скорость вращения
    private Color initialColor; // Начальный цвет волны

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("На объекте нет SpriteRenderer!");
            return;
        }

        initialColor = spriteRenderer.color; // Сохраняем исходный цвет
        StartCoroutine(WaveCycle());
    }

    private IEnumerator WaveCycle()
    {
        // Устанавливаем случайный начальный размер, конечный размер и скорость вращения
        transform.localScale = Vector3.zero;
        targetScale = Random.Range(minScale, maxScale);
        rotationSpeed = Random.Range(minSpeed, maxSpeed) * (Random.value > 0.5f ? 1 : -1);

        // Фаза увеличения волны
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / fadeDuration;

            // Увеличиваем размер волны
            float scale = Mathf.Lerp(0f, targetScale, t);
            transform.localScale = new Vector3(scale, scale, 1f);

            // Вращаем волну
            transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);

            // Обновляем прозрачность
            Color color = initialColor;
            color.a = Mathf.Lerp(1f, 0f, t);
            spriteRenderer.color = color;

            yield return null;
        }

        // Плавное исчезновение
        float fadeOutTime = Random.Range(1f, 2f);
        float fadeOutElapsed = 0f;
        while (fadeOutElapsed < fadeOutTime)
        {
            fadeOutElapsed += Time.deltaTime;
            float fadeOutT = fadeOutElapsed / fadeOutTime;

            // Уменьшаем размер
            float scale = Mathf.Lerp(targetScale, 0f, fadeOutT);
            transform.localScale = new Vector3(scale, scale, 1f);

            // Уменьшаем прозрачность
            Color color = initialColor;
            color.a = Mathf.Lerp(0f, 1f, fadeOutT);
            spriteRenderer.color = color;

            yield return null;
        }

        // После исчезновения удаляем объект
        Destroy(gameObject);
    }
}
