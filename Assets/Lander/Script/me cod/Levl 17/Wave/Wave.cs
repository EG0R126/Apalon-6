using System.Collections;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public float minScale = 0.5f; // ����������� ��������� ������ �����
    public float maxScale = 2f; // ������������ �������� ������ �����
    public float minSpeed = 10f; // ����������� �������� ��������
    public float maxSpeed = 50f; // ������������ �������� ��������
    public float fadeDuration = 1f; // �����, �� ������� ����� ��������
    public float minWaitTime = 0.5f; // ����������� ����� �� ��������� �����
    public float maxWaitTime = 5f; // ������������ ����� �� ��������� �����

    private SpriteRenderer spriteRenderer; // ��������� ��� ���������� �������������
    private float targetScale; // �������� ������ �����
    private float rotationSpeed; // �������� ��������
    private Color initialColor; // ��������� ���� �����

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("�� ������� ��� SpriteRenderer!");
            return;
        }

        initialColor = spriteRenderer.color; // ��������� �������� ����
        StartCoroutine(WaveCycle());
    }

    private IEnumerator WaveCycle()
    {
        // ������������� ��������� ��������� ������, �������� ������ � �������� ��������
        transform.localScale = Vector3.zero;
        targetScale = Random.Range(minScale, maxScale);
        rotationSpeed = Random.Range(minSpeed, maxSpeed) * (Random.value > 0.5f ? 1 : -1);

        // ���� ���������� �����
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / fadeDuration;

            // ����������� ������ �����
            float scale = Mathf.Lerp(0f, targetScale, t);
            transform.localScale = new Vector3(scale, scale, 1f);

            // ������� �����
            transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);

            // ��������� ������������
            Color color = initialColor;
            color.a = Mathf.Lerp(1f, 0f, t);
            spriteRenderer.color = color;

            yield return null;
        }

        // ������� ������������
        float fadeOutTime = Random.Range(1f, 2f);
        float fadeOutElapsed = 0f;
        while (fadeOutElapsed < fadeOutTime)
        {
            fadeOutElapsed += Time.deltaTime;
            float fadeOutT = fadeOutElapsed / fadeOutTime;

            // ��������� ������
            float scale = Mathf.Lerp(targetScale, 0f, fadeOutT);
            transform.localScale = new Vector3(scale, scale, 1f);

            // ��������� ������������
            Color color = initialColor;
            color.a = Mathf.Lerp(0f, 1f, fadeOutT);
            spriteRenderer.color = color;

            yield return null;
        }

        // ����� ������������ ������� ������
        Destroy(gameObject);
    }
}
