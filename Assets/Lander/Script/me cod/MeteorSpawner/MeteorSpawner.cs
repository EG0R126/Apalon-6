using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [Header("Основные настройки")]
    [SerializeField, Tooltip("Префаб метеорита, который будет создаваться")]
    private GameObject meteorPrefab;

    [SerializeField, Tooltip("Зона, внутри которой создаются метеориты")]
    private BoxCollider2D spawnArea;

    [SerializeField, Tooltip("Интервал между спавнами метеоритов (в секундах)")]
    private float spawnInterval = 1.0f;

    [Header("Скорость метеоритов")]
    [SerializeField, Tooltip("Минимальная и максимальная скорость падения метеоритов")]
    private Vector2 speedRange = new Vector2(1.0f, 5.0f); // minSpeed и maxSpeed

    [Header("Уклон метеоритов")]
    [SerializeField, Tooltip("Минимальный и максимальный уклон метеоритов")]
    private Vector2 tiltRange = new Vector2(-1.0f, 1.0f); // minTilt и maxTilt

    [Header("Размер метеоритов")]
    [SerializeField, Tooltip("Минимальный и максимальный размер метеоритов")]
    private Vector2 sizeRange = new Vector2(0.5f, 2.0f); // minSize и maxSize

    private void Start()
    {
        // Запускаем цикл появления метеоритов
        InvokeRepeating(nameof(SpawnMeteor), 0f, spawnInterval);
    }

    private void SpawnMeteor()
    {
        // Случайная позиция внутри зоны спавна
        float x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
        float z = 2.32f;
        float y = spawnArea.bounds.max.y; // Верхняя граница зоны

        Vector3 spawnPosition = new Vector3(x, y, z);

        // Создаём метеорит
        GameObject meteor = Instantiate(meteorPrefab, spawnPosition, Quaternion.identity);

        // Устанавливаем случайный размер метеорита
        float randomSize = Random.Range(sizeRange.x, sizeRange.y);
        meteor.transform.localScale = new Vector3(randomSize, randomSize, 1);

        // Получаем компонент Rigidbody2D
        Rigidbody2D rb = meteor.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Случайная скорость и направление (уклон)
            float speed = Random.Range(speedRange.x, speedRange.y);
            float tilt = Random.Range(tiltRange.x, tiltRange.y);

            // Устанавливаем скорость метеорита
            rb.velocity = new Vector2(tilt, -speed);
        }
    }
}
