using System.Collections;
using UnityEngine;

public class StoneWaveSpawner : MonoBehaviour
{
    public GameObject wavePrefab; // ���� ������ Prefab �����
    public float spawnIntervalMin = 0.5f; // ����������� �������� ����� �������
    public float spawnIntervalMax = 2f; // ����������� �������� ����� �������

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        while (true)
        {
            // ������ �����
            GameObject wave = Instantiate(wavePrefab, transform.position, Quaternion.identity);

            // ��������� ������ ��� �������� (���� �����, ����� ����� ��������� ������ � ������)
            wave.transform.SetParent(transform);

            // ��� ��������� ����� �� ��������� �����
            float waitTime = Random.Range(spawnIntervalMin, spawnIntervalMax);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
