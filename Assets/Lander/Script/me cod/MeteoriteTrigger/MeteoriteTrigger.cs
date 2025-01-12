using UnityEngine;

public class MeteoriteTrigger : MonoBehaviour
{
 public GameObject animatedObject; // ������, �� ������� ����� ����������� ��������
 public Animator animator;         // ��������� Animator ������� � ���������


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetTrigger("Trigger"); // ��������� ��������
        }
    }
}
