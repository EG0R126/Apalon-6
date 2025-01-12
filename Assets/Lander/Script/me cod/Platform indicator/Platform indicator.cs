using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Platformindicator : MonoBehaviour
{
    [SerializeField] private Image img; // ������ ���������
    [SerializeField] private Transform target; // ����
    [SerializeField] private Transform referenceObject; // ������, ������������ �������� �������� ����������
    [SerializeField] private Camera cam; // ������ (������ ���� ���������������)
    [SerializeField] private float minSize = 0f; // ����������� ������ ������
    [SerializeField] private float maxSize = 1.0f; // ������������ ������ ������
    [SerializeField] private float minDistance = 1.0f; // ����������, ��� ������� ������ �����������
    [SerializeField] private float maxDistance = 10.0f; // ����������, ��� ������� ������ ������������

    void LateUpdate()
    {
        // �������� ���������� ���� �� ������
        Vector3 screenPos = cam.WorldToScreenPoint(target.position);

        // ������������ ������� �� ������
        float minX = img.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;

        float minY = img.GetPixelAdjustedRect().height / 2;
        float maxY = Screen.height - minY;

        screenPos.x = Mathf.Clamp(screenPos.x, minX, maxX);
        screenPos.y = Mathf.Clamp(screenPos.y, minY, maxY);

        img.transform.position = screenPos;

        // ��������� ��������� ����
        if (target.position.x < cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane)).x ||
            target.position.x > cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, cam.nearClipPlane)).x ||
            target.position.y < cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane)).y ||
            target.position.y > cam.ScreenToWorldPoint(new Vector3(0, Screen.height, cam.nearClipPlane)).y)
        {

        }
        else
        {

            // �������� ������ ������ � ����������� �� ���������� �� ����
            float distance = Vector3.Distance(referenceObject.position, target.position);
            float size = Mathf.Lerp(minSize, maxSize, Mathf.InverseLerp(minDistance, maxDistance, distance));
            img.rectTransform.localScale = new Vector3(size, size, 1);
        }
    }
}
