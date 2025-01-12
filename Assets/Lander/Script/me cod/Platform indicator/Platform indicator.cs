using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Platformindicator : MonoBehaviour
{
    [SerializeField] private Image img; // Иконка указателя
    [SerializeField] private Transform target; // Цель
    [SerializeField] private Transform referenceObject; // Объект, относительно которого измеряем расстояние
    [SerializeField] private Camera cam; // Камера (должна быть ортографическая)
    [SerializeField] private float minSize = 0f; // Минимальный размер иконки
    [SerializeField] private float maxSize = 1.0f; // Максимальный размер иконки
    [SerializeField] private float minDistance = 1.0f; // Расстояние, при котором размер минимальный
    [SerializeField] private float maxDistance = 10.0f; // Расстояние, при котором размер максимальный

    void LateUpdate()
    {
        // Получаем координаты цели на экране
        Vector3 screenPos = cam.WorldToScreenPoint(target.position);

        // Ограничиваем позицию на экране
        float minX = img.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;

        float minY = img.GetPixelAdjustedRect().height / 2;
        float maxY = Screen.height - minY;

        screenPos.x = Mathf.Clamp(screenPos.x, minX, maxX);
        screenPos.y = Mathf.Clamp(screenPos.y, minY, maxY);

        img.transform.position = screenPos;

        // Проверяем видимость цели
        if (target.position.x < cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane)).x ||
            target.position.x > cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, cam.nearClipPlane)).x ||
            target.position.y < cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane)).y ||
            target.position.y > cam.ScreenToWorldPoint(new Vector3(0, Screen.height, cam.nearClipPlane)).y)
        {

        }
        else
        {

            // Изменяем размер иконки в зависимости от расстояния до цели
            float distance = Vector3.Distance(referenceObject.position, target.position);
            float size = Mathf.Lerp(minSize, maxSize, Mathf.InverseLerp(minDistance, maxDistance, distance));
            img.rectTransform.localScale = new Vector3(size, size, 1);
        }
    }
}
