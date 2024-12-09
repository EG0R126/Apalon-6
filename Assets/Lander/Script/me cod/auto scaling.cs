using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScaler : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Camera mainCamera;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        mainCamera = Camera.main;

        ScaleBackground();
    }

    private void ScaleBackground()
    {
        if (spriteRenderer == null || mainCamera == null)
            return;

        // ������ �������� ������
        float cameraHeight = mainCamera.orthographicSize * 2f;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        // ������ �������� ������� ����
        float spriteHeight = spriteRenderer.sprite.bounds.size.y;
        float spriteWidth = spriteRenderer.sprite.bounds.size.x;

        // Calculation of scaling factors for X and Y
        float scaleX = cameraWidth / spriteWidth;
        float scaleY = cameraHeight / spriteHeight;

        // ��������� ������ �������� � ������� ��� �������� �������
        transform.localScale = new Vector3(scaleX, scaleY, 1f);
        transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, transform.position.z);
    }
}