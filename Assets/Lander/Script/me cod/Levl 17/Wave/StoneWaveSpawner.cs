using System.Collections;
using UnityEngine;

public class StoneWaveSpawner : MonoBehaviour
{
    public GameObject wavePrefab; // Сюда укажем Prefab волны
    public float spawnIntervalMin = 0.5f; // Минимальный интервал между волнами
    public float spawnIntervalMax = 2f; // Макимальный интервал между волнами

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        while (true)
        {
            // Создаём волну
            GameObject wave = Instantiate(wavePrefab, transform.position, Quaternion.identity);

            // Указываем камень как родителя (если нужно, чтобы волны двигались вместе с камнем)
            wave.transform.SetParent(transform);

            // Ждём случайное время до следующей волны
            float waitTime = Random.Range(spawnIntervalMin, spawnIntervalMax);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
