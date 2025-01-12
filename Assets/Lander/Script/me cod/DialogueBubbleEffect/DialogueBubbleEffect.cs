using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class DialogueBubbleEffect : MonoBehaviour
{
    [Header("Bubble Settings")]
    public GameObject[] bubblePrefabs; // ������ ���������
    public Transform circleCenter;    // ����� �����
    public float radius = 1f;         // ������ �����
    public float bubbleSpawnRate = 0.1f; // ������� ��������� ���������
    public float pathLength = 2f;     // ����� ����� ���������

    [Header("Circle and UI Settings")]
    public Image circleMask;          // UI-������ ��� ���������� �����
    public TextMeshProUGUI dialogueText; // ���� ��� ������
    public float typingSpeed = 0.05f; // �������� ������� "������� �������"
    public string dialogueTextContent; // ����� �������
    public float circleFadeDuration = 0.5f; // ����� ���������� �����

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
        // 1. ��������� ��������� �� ������� � ������ �����
        StartCoroutine(SpawnBubblePath());

        // 2. ���, ���� ���������� ��� ��������
        yield return new WaitForSeconds(pathLength);

        // 3. ������ �������� �� �����
        StartCoroutine(SpawnBubbleCircle());

        // 4. ��������� ����
        yield return StartCoroutine(FadeInCircle());

        // 5. ��������� ������
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
        float angleStep = 10f; // ��� ���� ����� ����������
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
