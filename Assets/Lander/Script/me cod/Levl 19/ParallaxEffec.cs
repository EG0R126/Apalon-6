using UnityEngine;

public class ParallaxEffec : MonoBehaviour
{
    [Header("Настройки параллакса")]
    [SerializeField] private Transform[] layers; // Слои для параллакса
    [SerializeField] private float[] layerSpeeds; // Скорость для каждого слоя
    [SerializeField] private Transform cameraTransform; // Камера

    private Vector3 previousCameraPosition;

    void Start()
    {
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
        previousCameraPosition = cameraTransform.position;
    }

    void Update()
    {
        for (int i = 0; i < layers.Length; i++)
        {
            if (layers[i] != null)
            {
                // Вычисляем смещение камеры
                float parallax = (previousCameraPosition.x - cameraTransform.position.x) * layerSpeeds[i];

                // Перемещаем слой
                Vector3 layerPosition = layers[i].position;
                layerPosition.x += parallax;
                layers[i].position = layerPosition;
            }
        }

        // Обновляем позицию камеры
        previousCameraPosition = cameraTransform.position;
    }
}
