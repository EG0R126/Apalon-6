using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class DialogueBubbleEffect : MonoBehaviour
{
    [Header("Bubble Settings")]
    public GameObject[] bubblePrefabs; // Список пузырьков
    public Transform circleCenter;    // Центр круга
    public float radius = 1f;         // Радиус круга
    public float bubbleSpawnRate = 0.1f; // Частота появления пузырьков
    public float pathLength = 2f;     // Длина ножки пузырьков

    [Header("Circle and UI Settings")]
    public Image circleMask;          // UI-объект для затемнения круга
    public TextMeshProUGUI dialogueText; // Поле для текста
    public float typingSpeed = 0.05f; // Скорость эффекта "пишущей машинки"
    public string dialogueTextContent; // Текст диалога
    public float circleFadeDuration = 0.5f; // Время затемнения круга

    private bool isTriggered = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isTriggered && collision.CompareTag("Player"))
        {
            isTriggered = true;
            StartCoroutine(StartDialogueEffect());
        }
    }

    private IEnumerator StartDialogueEffect()
    {
        // 1. Генерация пузырьков от объекта к центру круга
        StartCoroutine(SpawnBubblePath());

        // 2. Ждём, пока создадутся все пузырьки
        yield return new WaitForSeconds(pathLength);

        // 3. Создаём пузырьки по кругу
        StartCoroutine(SpawnBubbleCircle());

        // 4. Затемняем круг
        yield return StartCoroutine(FadeInCircle());

        // 5. Появление текста
        StartCoroutine(TypeText(dialogueTextContent));
    }

    private IEnumerator SpawnBubblePath()
    {
        Vector3 startPosition = transform.position;
        Vector3 endPosition = circleCenter.position;

        float distance = Vector3.Distance(startPosition, endPosition);
        float steps = distance / bubbleSpawnRate;

        for (int i = 0; i <= steps; i++)
        {
            Vector3 position = Vector3.Lerp(startPosition, endPosition, i / steps);
            SpawnBubbleAt(position);
            yield return new WaitForSeconds(bubbleSpawnRate);
        }
    }

    private IEnumerator SpawnBubbleCircle()
    {
        float angleStep = 10f; // Шаг угла между пузырьками
        int bubbleCount = Mathf.RoundToInt(360 / angleStep);

        for (int i = 0; i < bubbleCount; i++)
        {
            float angle = i * angleStep * Mathf.Deg2Rad;
            Vector3 position = circleCenter.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
            SpawnBubbleAt(position);
            yield return new WaitForSeconds(bubbleSpawnRate);
        }
    }

    private void SpawnBubbleAt(Vector3 position)
    {
        GameObject bubblePrefab = bubblePrefabs[Random.Range(0, bubblePrefabs.Length)];
        Instantiate(bubblePrefab, position, Quaternion.identity);
    }

    private IEnumerator FadeInCircle()
    {
        Color color = circleMask.color;
        color.a = 0;
        circleMask.color = color;

        float timer = 0;
        while (timer < circleFadeDuration)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Lerp(0, 1, timer / circleFadeDuration);
            circleMask.color = color;
            yield return null;
        }
    }

    private IEnumerator TypeText(string text)
    {
        dialogueText.text = "";
        foreach (char letter in text.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
