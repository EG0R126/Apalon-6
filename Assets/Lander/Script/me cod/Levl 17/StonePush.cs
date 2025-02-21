using UnityEngine;

public class StonePush : MonoBehaviour
{
    public float pushStrength = 10f; // ���� ������������
    public float effectRadius = 5f; // ������ �������� ����-����������
    public LayerMask playerLayer; // ����, �� ������� ��������� �����

    private void Update()
    {
        // ����� ��� ���������� � ������� ��������
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, effectRadius, playerLayer);

        foreach (Collider2D collider in colliders)
        {
            // ���������, ��� ��� ����� (��������, ���� � ���� ���� ��� "Player")
            if (collider.CompareTag("Player"))
            {
                Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    // ��������� ����������� �� ����� � ������
                    Vector2 direction = (collider.transform.position - transform.position).normalized;

                    // ��������� ���� ������������
                    rb.AddForce(direction * pushStrength, ForceMode2D.Impulse);
                }
            }
        }
    }

    // ������������� ������ �������� � ���������
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, effectRadius);
    }
}
