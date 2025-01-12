using UnityEngine;

public class MeteoriteTrigger : MonoBehaviour
{
 public GameObject animatedObject; // Объект, на котором будет происходить анимация
 public Animator animator;         // Компонент Animator объекта с анимацией


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetTrigger("Trigger"); // Запускаем анимацию
        }
    }
}
