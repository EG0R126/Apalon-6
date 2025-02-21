using UnityEngine;

public class ParallaxEffec : MonoBehaviour
{
    [Header("��������� ����������")]
    [SerializeField] private Transform[] layers; // ���� ��� ����������
    [SerializeField] private float[] layerSpeeds; // �������� ��� ������� ����
    [SerializeField] private Transform cameraTransform; // ������

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
                // ��������� �������� ������
                float parallax = (previousCameraPosition.x - cameraTransform.position.x) * layerSpeeds[i];

                // ���������� ����
                Vector3 layerPosition = layers[i].position;
                layerPosition.x += parallax;
                layers[i].position = layerPosition;
            }
        }

        // ��������� ������� ������
        previousCameraPosition = cameraTransform.position;
    }
}
