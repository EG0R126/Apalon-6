using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class WindZone : MonoBehaviour
{
    [Header("��������� �����")]
    [SerializeField] private float minWindForce = 2f;
    [SerializeField] private float maxWindForce = 10f;
    [SerializeField] private float minInterval = 0.5f;
    [SerializeField] private float maxInterval = 3f;
    [SerializeField] private float smoothTime = 1f;
    [SerializeField] private Vector2 windDirection = Vector2.right;

    [Header("��������� ��������")]
    [SerializeField] private GameObject windPrefab;
    [SerializeField] private float objectLifetime = 5f;
    [SerializeField] private PolygonCollider2D windArea;

    [Header("������������ ���������� ������")]
    [SerializeField] private int minWindObjects = 10; // ����������� ���������� ������
    [SerializeField] private int maxWindObjects = 100; // ������������ ���������� ������

    [Header("��������� ������")]
    [SerializeField] private float xOffsetFromPlayer = 20f; // ������� �������� �� X
    [SerializeField] private float xSpread = 5f; // ������� �� X
    [SerializeField] private float minYSpawn = -6f; // ����������� Y
    [SerializeField] private float maxYSpawn = 20f; // ������������ Y
    [SerializeField] private float minSpawnInterval = 0.05f; // ����������� ��������
    [SerializeField] private float maxSpawnInterval = 0.2f; // ������������ ��������
    [SerializeField] private int maxSpawnAttempts = 10;

    [Header("������� ������")]
    [SerializeField] private List<ParticleSystem> particleSystems; // ������ ������ ������

    [Header("���������� � ������")]
    [SerializeField] private AudioSource alertAudioSource; // �������� ����� ��� ����������
    [SerializeField] private AudioClip stormAlertClip; // ���� ����������
    [SerializeField] private float stormThreshold = 90f; // ����� �������� ����� ��� ������

    private bool alertPlayed = false; // ����, ����� ���� �� ����������


    [Header("���� �����")]
    [SerializeField] private AudioSource windAudioSource; // �������� ����� �����
    [SerializeField] private AudioClip windLoopClip; // ���� �����
    [SerializeField] private float minVolume = 0.1f; // ����������� ���������
    [SerializeField] private float maxVolume = 1f; // ������������ ���������
    [SerializeField] private float minPitch = 0.8f; // ����������� �����������
    [SerializeField] private float maxPitch = 1.2f; // ������������ �����������

    [Header("��������� UI")]
    [SerializeField] private Image targetImage;
    [SerializeField] private float minAlpha = 0f;
    [SerializeField] private float maxAlpha = 1f;

    private Transform playerTransform;
    private Rigidbody2D playerRb;
    private bool playerInZone = false;
    private float currentWindForce = 0f;
    private float targetWindForce = 0f;
    private List<GameObject> windObjects = new List<GameObject>();

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) playerTransform = player.transform;

        StartCoroutine(ChangeWindForce());
        StartCoroutine(SpawnWindObjects());

        InitializeWindSound();

        StartCoroutine(ChangeWindForce());
    }

    void InitializeWindSound()
    {
        if (windAudioSource != null && windLoopClip != null)
        {
            windAudioSource.clip = windLoopClip;
            windAudioSource.loop = true;
            windAudioSource.Play();
        }
    }

    IEnumerator ChangeWindForce()
    {
        while (true)
        {
            targetWindForce = Random.Range(minWindForce, maxWindForce);
            float interval = Random.Range(minInterval, maxInterval);

            float elapsedTime = 0f;
            float startForce = currentWindForce;

            while (elapsedTime < smoothTime)
            {
                elapsedTime += Time.deltaTime;
                currentWindForce = Mathf.Lerp(startForce, targetWindForce, elapsedTime / smoothTime);

                // ��������� ��������� ������
                UpdateParticleSystems();
                yield return null;
            }

            yield return new WaitForSeconds(interval);
        }
    }

    void UpdateParticleSystems()
    {
        // ����������� ���� ����� (�� 0 �� 1)
        float windStrength = Mathf.InverseLerp(minWindForce, maxWindForce, currentWindForce);

        foreach (var ps in particleSystems)
        {
            if (ps != null)
            {
                var velocityOverLifetime = ps.velocityOverLifetime;
                var main = ps.main;

                // �������� ���������� (�� 1 �� 0)
                main.gravityModifier = Mathf.Lerp(1f, 0f, windStrength);

                // �������� �������� ������ (�����������)
                if (velocityOverLifetime.enabled)
                {
                    velocityOverLifetime.x = Mathf.Lerp(1f, 10f, windStrength); // ������: ����������� �������� �� ��� X
                }
            }
        }
    }

    void FixedUpdate()
    {
        Debug.Log("�������� �����: " + currentWindForce);

        if (playerInZone && playerRb != null)
        {
            Vector2 playerVelocity = playerRb.velocity;
            float dotProduct = Vector2.Dot(playerVelocity.normalized, windDirection.normalized);
            float adjustedForce = currentWindForce * (1 - 0.5f * Mathf.Abs(dotProduct));

            playerRb.AddForce(windDirection.normalized * adjustedForce * Time.fixedDeltaTime, ForceMode2D.Force);
        }

        CheckStormAlert();
    }

    void CheckStormAlert()
    {
        if (currentWindForce > stormThreshold && !alertPlayed)
        {
            // ������������� ���� ����������
            if (alertAudioSource != null && stormAlertClip != null)
            {
                alertAudioSource.PlayOneShot(stormAlertClip);
            }
            alertPlayed = true; // ���� ������������
        }
        else if (currentWindForce <= stormThreshold && alertPlayed)
        {
            // ���������� ����, ����� ���� ��� ����������� �����
            alertPlayed = false;
        }
    }


    private int CalculateMaxObjects()
    {
        float t = Mathf.InverseLerp(minWindForce, maxWindForce, currentWindForce);
        return Mathf.RoundToInt(Mathf.Lerp(minWindObjects, maxWindObjects, t));
    }

    Vector2 GetValidSpawnPosition()
    {
        if (playerTransform == null || windArea == null) return Vector2.zero;

        for (int i = 0; i < maxSpawnAttempts; i++)
        {
            // ��������� ������� �� X
            float spawnX = playerTransform.position.x + xOffsetFromPlayer + Random.Range(-xSpread, xSpread);

            // ��������� ������
            float spawnY = Random.Range(minYSpawn, maxYSpawn);

            Vector2 spawnPos = new Vector2(spawnX, spawnY);

            if (windArea.OverlapPoint(spawnPos))
            {
                return spawnPos;
            }
        }
        return Vector2.zero;
    }

    IEnumerator SpawnWindObjects()
    {
        while (true)
        {
            int currentMaxObjects = CalculateMaxObjects();

            if (windObjects.Count < currentMaxObjects)
            {
                Vector2 spawnPos = GetValidSpawnPosition();

                if (spawnPos != Vector2.zero)
                {
                    GameObject obj = Instantiate(windPrefab, spawnPos, Quaternion.identity);
                    windObjects.Add(obj);
                    StartCoroutine(FadeAndDestroy(obj));
                }
            }

            while (windObjects.Count > currentMaxObjects)
            {
                GameObject objToRemove = windObjects[0];
                windObjects.RemoveAt(0);
                Destroy(objToRemove);
            }

            // ��������� �������� ����� ��������� ������
            yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));
        }
    }

    void Update()
    {
        UpdateWindSound();

        foreach (var obj in windObjects)
        {
            if (obj != null)
            {
                Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.velocity = windDirection.normalized * (currentWindForce / 20f);
                }
            }
        }

        if (targetImage != null)
        {
            float alpha = Mathf.PingPong(Time.time * (currentWindForce / 27f), maxAlpha - minAlpha) + minAlpha;
            Color newColor = targetImage.color;
            newColor.a = alpha;
            targetImage.color = newColor;
        }
    }

    IEnumerator FadeAndDestroy(GameObject obj)
    {
        SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
        TrailRenderer trail = obj.GetComponent<TrailRenderer>();
        float fadeTime = Mathf.Min(1f, objectLifetime / 2);

        yield return Fade(sr, trail, 0f, 1f, fadeTime);

        yield return new WaitForSeconds(objectLifetime - fadeTime * 2);

        yield return Fade(sr, trail, 1f, 0f, fadeTime);

        if (obj != null)
        {
            windObjects.Remove(obj);
            Destroy(obj);
        }
    }

    IEnumerator Fade(SpriteRenderer sr, TrailRenderer trail, float startAlpha, float endAlpha, float duration)
    {
        Color startColor = sr.color;
        Color trailStart = trail != null ? trail.startColor : Color.white;
        Color trailEnd = trail != null ? trail.endColor : Color.white;

        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(startAlpha, endAlpha, t / duration);

            sr.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

            if (trail != null)
            {
                trail.startColor = new Color(trailStart.r, trailStart.g, trailStart.b, alpha);
                trail.endColor = new Color(trailEnd.r, trailEnd.g, trailEnd.b, alpha);
            }

            yield return null;
        }
    }

    void UpdateWindSound()
    {
        if (windAudioSource != null)
        {
            // ��������� ��������������� �������� ���� ����� (�� 0 �� 1)
            float windStrength = Mathf.InverseLerp(minWindForce, maxWindForce, currentWindForce);

            // �������� ���������
            windAudioSource.volume = Mathf.Lerp(minVolume, maxVolume, windStrength);

            // �������� �����������
            windAudioSource.pitch = Mathf.Lerp(minPitch, maxPitch, windStrength);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerRb = other.GetComponent<Rigidbody2D>();
            playerInZone = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
            playerRb = null;
        }
    }
}