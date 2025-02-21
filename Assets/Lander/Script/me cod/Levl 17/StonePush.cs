using UnityEngine;

public class StonePush : MonoBehaviour
{
    public float pushStrength = 10f; // Сила отталкивания
    public float effectRadius = 5f; // Радиус действия анти-гравитации
    public LayerMask playerLayer; // Слой, на котором находится игрок

    private void Update()
    {
        // Найти все коллайдеры в радиусе действия
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, effectRadius, playerLayer);

        foreach (Collider2D collider in colliders)
        {
            // Проверяем, что это игрок (например, если у него есть тег "Player")
            if (collider.CompareTag("Player"))
            {
                Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    // Вычисляем направление от камня к игроку
                    Vector2 direction = (collider.transform.position - transform.position).normalized;

                    // Применяем силу отталкивания
                    rb.AddForce(direction * pushStrength, ForceMode2D.Impulse);
                }
            }
        }
    }

    // Визуализируем радиус действия в редакторе
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, effectRadius);
    }
}
