using System.Collections.Generic;
using UnityEngine;

public class Lightscript : MonoBehaviour
{
    // ������ ��������� ��������
    public List<GameObject> nearbyObjects;

    // ����������� ����������, ����� �������� ���������� ����������
    public float minDistance = 5f;

    // ������������ ������� ���������� (0 - ����������, 1 - ��������� ������)
    public float maxDarkness = 0.75f;

    // ���� ��� ������������ �������
    public SpriteRenderer darkenLayer;

    void Update()
    {
        // ��������� ����������� ���������� �� ���������� �������
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

        // ���������� ����������� ����������
        float darknessFactor = Mathf.Clamp01((minDistanceToObject - minDistance) / (minDistanceToObject));
        darknessFactor *= maxDarkness;

        // ��������� ���������� � ����
        Color color = darkenLayer.color;
        color.a = darknessFactor;
        darkenLayer.color = color;
    }
}
