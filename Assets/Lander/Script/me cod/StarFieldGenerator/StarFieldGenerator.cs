using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarFieldGenerator : MonoBehaviour
{
    public GameObject starPrefab; // ������ ������
    public int initialStarCount = 100; // ��������� ���������� �����
    public float twinkleProbability = 0.5f; // ����������� �������� ������

    private BoxCollider2D boxCollider;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();

        for (int i = 0; i < initialStarCount; i++)
        {
            CreateStar();
        }
    }

    void CreateStar()
    {
        Vector3 position = GetRandomPositionInBoxCollider();
        GameObject newStar = Instantiate(starPrefab, position, Quaternion.identity, transform);

        // ��������� ������ � �������
        float scale = Random.Range(0.05f, 0.2f);
        newStar.transform.localScale = new Vector3(scale, scale, 1);

        SpriteRenderer sr = newStar.GetComponent<SpriteRenderer>();
        float brightness = Random.Range(0.5f, 1f);
        sr.color = new Color(brightness, brightness, brightness, 1f);

        // ��������� ��������� �������� � ������������ twinkleProbability
        if (Random.value < twinkleProbability)
        {
            newStar.AddComponent<StarTwinkle>();
        }
    }

    Vector3 GetRandomPositionInBoxCollider()
    {
        float x = Random.Range(boxCollider.bounds.min.x, boxCollider.bounds.max.x);
        float y = Random.Range(boxCollider.bounds.min.y, boxCollider.bounds.max.y);
        float z = 50f;
        return new Vector3(x, y, z);
    }
}