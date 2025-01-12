using UnityEngine;

public class MeteorNlo : MonoBehaviour
{
    [SerializeField] private float destroyDelay = 5.0f; // Время до удаления объекта

    private void Start()
    {
        // Удаляем объект через заданное время
        Destroy(gameObject, destroyDelay);
    }
}
