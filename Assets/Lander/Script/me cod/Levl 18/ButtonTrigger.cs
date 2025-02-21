using UnityEngine;
using System.Collections;

public class ButtonTrigger : MonoBehaviour
{
    public DoorController door; // ������ �� �����

    public GameObject targetObject;  // ������, �� ������� �������� �������
    public Sprite sprite1;           // ������ ������ (�� ���������)
    public Sprite sprite2;           // ������ ������ (�������� ����� 2 �������)
    public Sprite sprite3;           // ������ ������ (�������� ����� 2 ������� ����� �������)

    private SpriteRenderer spriteRenderer;
    private bool isButtonPressed = false; // ���� ��� ������������ ��������� ������


    void Start()
    {
        spriteRenderer = targetObject.GetComponent<SpriteRenderer>(); // �������� SpriteRenderer �������� �������
        spriteRenderer.sprite = sprite1; // ������������� ��������� ������
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Legs")) // ���� �� ������ ������ ������
        {
            door.OpenDoor();

            isButtonPressed = true;
            StartCoroutine(ChangeSprites());  // ��������� �������� ��� ����� ��������
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Legs")) // ���� ������ ������� � ������
        {
            door.CloseDoor();

            isButtonPressed = false;
            StopCoroutine(ChangeSprites()); // ������������� ��������
            spriteRenderer.sprite = sprite1; // ���������� ������ ������
        }
    }

    // �������� ��� ��������� ����� �������� � ����������
    IEnumerator ChangeSprites()
    {
        while (isButtonPressed)  // ���� ������ �������
        {
            // ������ ������ �� ������ ����� 2 �������
            spriteRenderer.sprite = sprite2;
            yield return new WaitForSeconds(1f);

            // ������ ������ �� ������ ����� 2 �������
            spriteRenderer.sprite = sprite3;
            yield return new WaitForSeconds(1f);
        }
    }
}
