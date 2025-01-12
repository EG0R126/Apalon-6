using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] private AudioSource Bax; 
    [SerializeField] private ParticleSystem explosionEffect; // Эффект взрыва
    [SerializeField] private float destroyDelay = 2.0f; // Задержка перед удалением

    private Rigidbody2D rb;
    private Collider2D col;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        Bax = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверяем, что метеорит ударился об землю
        if (collision.collider.CompareTag("Ground"))
        {
            // Останавливаем физическое взаимодействие
            rb.velocity = Vector2.zero; // Останавливаем скорость
            rb.angularVelocity = 0f; // Останавливаем вращение
            rb.isKinematic = true; // Переводим Rigidbody2D в кинематическое состояние

            // Отключаем коллайдер, чтобы метеорит больше не реагировал на столкновения
            col.enabled = false;

            // Скрываем метеорит
            GetComponent<SpriteRenderer>().enabled = false;

            // Активируем эффект взрыва
            if (explosionEffect != null)
            {
                Bax.Play();
                explosionEffect.gameObject.SetActive(true);
                explosionEffect.transform.position = transform.position;
                explosionEffect.Play();
            }

            // Удаляем объект через заданное время
            Destroy(gameObject, destroyDelay);
        }
    }
}
