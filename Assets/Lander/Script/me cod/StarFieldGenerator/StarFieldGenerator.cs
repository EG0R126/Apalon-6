using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarFieldGenerator : MonoBehaviour
{
    public GameObject starPrefab; // Префаб звезды
    public int initialStarCount = 100; // Начальное количество звезд
    public float twinkleProbability = 0.5f; // Вероятность мерцания звезды

    public BoxCollider2D boxCollider;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        if (boxCollider == null)
        {
            Debug.LogError("BoxCollider2D not found on the GameObject. Please add a BoxCollider2D component.");
            return;
        }

        for (int i = 0; i < initialStarCount; i++)
        {
            CreateStar();
        }
    }

    void CreateStar()
    {
        Vector2 position = GetRandomPositionInBoxCollider();
        GameObject newStar = Instantiate(starPrefab, position, Quaternion.identity, transform);

        // Случайный размер и яркость
        float scale = Random.Range(0.05f, 0.2f);
        newStar.transform.localScale = new Vector3(scale, scale, 1);

        SpriteRenderer sr = newStar.GetComponent<SpriteRenderer>();
        float brightness = Random.Range(0.5f, 1f);
        sr.color = new Color(brightness, brightness, brightness, 1f);

        // Добавляем компонент мерцания с вероятностью twinkleProbability
        if (Random.value < twinkleProbability)
        {
            newStar.AddComponent<StarTwinkle>();
        }
    }

    Vector2 GetRandomPositionInBoxCollider()
    {
        float x = Random.Range(boxCollider.bounds.min.x, boxCollider.bounds.max.x);
        float y = Random.Range(boxCollider.bounds.min.y, boxCollider.bounds.max.y);
        float Z = 10f;
        return new Vector3(x, y, Z);
    }
}