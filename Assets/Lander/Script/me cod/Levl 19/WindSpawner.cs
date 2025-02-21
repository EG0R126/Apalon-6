using UnityEngine;
using System.Collections;

public class WindSpawner : MonoBehaviour
{
    public PolygonCollider2D windZone; // Коллайдер, в котором создаются частицы
    public GameObject windPrefab; // Префаб ветра
    public int spawnCount = 1000; // Количество создаваемых объектов
    public float minLifetime = 1f; // Минимальное время существования
    public float maxLifetime = 3f; // Максимальное время существования

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
            windObject.transform.SetParent(transform); // Для удобства
            StartCoroutine(FadeInAndOut(windObject));

            yield return new WaitForSeconds(Random.Range(0.01f, 0.1f)); // Делаем спавн не мгновенным
        }
    }

    Vector2 GetRandomPointInPolygon()
    {
        Vector2 randomPoint;
        do
        {
            // Берём случайную точку в границах коллайдера
            Bounds bounds = windZone.bounds;
            randomPoint = new Vector2(
                Random.Range(bounds.min.x, bounds.max.x),
                Random.Range(bounds.min.y, bounds.max.y)
            );
        }
        while (!PointInPolygon(randomPoint)); // Проверяем, внутри ли она полигона
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

        // Плавное появление
        while (elapsed < halfTime)
        {
            elapsed += Time.deltaTime;
            sr.color = new Color(1, 1, 1, elapsed / halfTime);
            yield return null;
        }

        elapsed = 0f;

        // Плавное исчезновение
        while (elapsed < halfTime)
        {
            elapsed += Time.deltaTime;
            sr.color = new Color(1, 1, 1, 1 - (elapsed / halfTime));
            yield return null;
        }

        Destroy(obj); // Удаляем после исчезновения
    }
}