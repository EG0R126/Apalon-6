using UnityEngine;
using System.Collections;

public class WindSpawner : MonoBehaviour
{
    public PolygonCollider2D windZone; // ���������, � ������� ��������� �������
    public GameObject windPrefab; // ������ �����
    public int spawnCount = 1000; // ���������� ����������� ��������
    public float minLifetime = 1f; // ����������� ����� �������������
    public float maxLifetime = 3f; // ������������ ����� �������������

    void Start()
    {
        StartCoroutine(SpawnWindParticles());
    }

    IEnumerator SpawnWindParticles()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector2 randomPos = GetRandomPointInPolygon();
            GameObject windObject = Instantiate(windPrefab, randomPos, Quaternion.identity);
            windObject.transform.SetParent(transform); // ��� ��������
            StartCoroutine(FadeInAndOut(windObject));

            yield return new WaitForSeconds(Random.Range(0.01f, 0.1f)); // ������ ����� �� ����������
        }
    }

    Vector2 GetRandomPointInPolygon()
    {
        Vector2 randomPoint;
        do
        {
            // ���� ��������� ����� � �������� ����������
            Bounds bounds = windZone.bounds;
            randomPoint = new Vector2(
                Random.Range(bounds.min.x, bounds.max.x),
                Random.Range(bounds.min.y, bounds.max.y)
            );
        }
        while (!PointInPolygon(randomPoint)); // ���������, ������ �� ��� ��������
        return randomPoint;
    }

    bool PointInPolygon(Vector2 point)
    {
        return windZone.OverlapPoint(point);
    }

    IEnumerator FadeInAndOut(GameObject obj)
    {
        SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
        if (sr == null) yield break;

        float lifetime = Random.Range(minLifetime, maxLifetime);
        float halfTime = lifetime / 2f;
        float elapsed = 0f;

        // ������� ���������
        while (elapsed < halfTime)
        {
            elapsed += Time.deltaTime;
            sr.color = new Color(1, 1, 1, elapsed / halfTime);
            yield return null;
        }

        elapsed = 0f;

        // ������� ������������
        while (elapsed < halfTime)
        {
            elapsed += Time.deltaTime;
            sr.color = new Color(1, 1, 1, 1 - (elapsed / halfTime));
            yield return null;
        }

        Destroy(obj); // ������� ����� ������������
    }
}