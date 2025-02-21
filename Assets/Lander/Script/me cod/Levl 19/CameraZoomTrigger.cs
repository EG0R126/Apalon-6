using UnityEngine;
using Cinemachine;

public class CameraZoomTrigger : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public float targetSize = 8f; // Новый размер камеры
    public float transitionSpeed = 2f; // Скорость изменения
    private float defaultSize;

    private void Start()
    {
        if (virtualCamera != null)
        {
            defaultSize = virtualCamera.m_Lens.OrthographicSize;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Проверяем, что это игрок
        {
            StopAllCoroutines();
            StartCoroutine(ChangeCameraSize(targetSize));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StopAllCoroutines();
            StartCoroutine(ChangeCameraSize(defaultSize));
        }
    }

    private System.Collections.IEnumerator ChangeCameraSize(float targetSize)
    {
        while (Mathf.Abs(virtualCamera.m_Lens.OrthographicSize - targetSize) > 0.01f)
        {
            virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(
                virtualCamera.m_Lens.OrthographicSize, targetSize, Time.deltaTime * transitionSpeed);
            yield return null;
        }
        virtualCamera.m_Lens.OrthographicSize = targetSize;
    }
}
