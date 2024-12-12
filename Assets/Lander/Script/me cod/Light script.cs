using System.Collections.Generic;
using UnityEngine;

public class Lightscript : MonoBehaviour
{
    // Список ближайших объектов
    public List<GameObject> nearbyObjects;

    // Минимальное расстояние, после которого затемнение начинается
    public float minDistance = 5f;

    // Максимальная степень затемнения (0 - прозрачный, 1 - полностью черный)
    public float maxDarkness = 0.75f;

    // Слой для затемняющего эффекта
    public SpriteRenderer darkenLayer;

    void Update()
    {
        // Вычислить минимальное расстояние до ближайшего объекта
        float minDistanceToObject = float.MaxValue;
        foreach (GameObject obj in nearbyObjects)
        {
            if (obj != null)
            {
                float distance = Vector2.Distance(transform.position, obj.transform.position);
                if (distance < minDistanceToObject)
                    minDistanceToObject = distance;
            }
        }

        // Рассчитать коэффициент затемнения
        float darknessFactor = Mathf.Clamp01((minDistanceToObject - minDistance) / (minDistanceToObject));
        darknessFactor *= maxDarkness;

        // Применить затемнение к слою
        Color color = darkenLayer.color;
        color.a = darknessFactor;
        darkenLayer.color = color;
    }
}
