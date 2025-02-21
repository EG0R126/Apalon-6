using UnityEngine;
using System.Collections;

public class ButtonTrigger : MonoBehaviour
{
    public DoorController door; // Ссылка на дверь

    public GameObject targetObject;  // Объект, на котором меняются спрайты
    public Sprite sprite1;           // Первый спрайт (по умолчанию)
    public Sprite sprite2;           // Второй спрайт (меняется через 2 секунды)
    public Sprite sprite3;           // Третий спрайт (меняется через 2 секунды после второго)

    private SpriteRenderer spriteRenderer;
    private bool isButtonPressed = false; // Флаг для отслеживания состояния кнопки


    void Start()
    {
        spriteRenderer = targetObject.GetComponent<SpriteRenderer>(); // Получаем SpriteRenderer целевого объекта
        spriteRenderer.sprite = sprite1; // Устанавливаем начальный спрайт
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Legs")) // Если на кнопку падает камень
        {
            door.OpenDoor();

            isButtonPressed = true;
            StartCoroutine(ChangeSprites());  // Запускаем корутину для смены спрайтов
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Legs")) // Если камень убирают с кнопки
        {
            door.CloseDoor();

            isButtonPressed = false;
            StopCoroutine(ChangeSprites()); // Останавливаем корутину
            spriteRenderer.sprite = sprite1; // Возвращаем первый спрайт
        }
    }

    // Корутина для цикличной смены спрайтов с интервалом
    IEnumerator ChangeSprites()
    {
        while (isButtonPressed)  // Пока кнопка активна
        {
            // Меняем спрайт на второй через 2 секунды
            spriteRenderer.sprite = sprite2;
            yield return new WaitForSeconds(1f);

            // Меняем спрайт на третий через 2 секунды
            spriteRenderer.sprite = sprite3;
            yield return new WaitForSeconds(1f);
        }
    }
}
