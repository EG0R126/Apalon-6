using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
    public float openAngle = 89f; // ���� � �������� ���������
    public float closeAngle = 0f; // ���� � �������� ���������
    public float speed = 200f; // �������� �������� �����



    private bool isOpening = false;
    private bool isClosing = false;

    void Update()
    {

        if (isOpening)
        {
            float newAngle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, openAngle, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, newAngle);

            if (Mathf.Approximately(newAngle, openAngle))
            {
                isOpening = false; // �������� ������� ��������
            }
        }

        if (isClosing)
        {
            float newAngle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, closeAngle, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, newAngle);

            if (Mathf.Approximately(newAngle, closeAngle))
            {
                isClosing = false; // �������� ������� ��������

            }
        }
    }

    public void OpenDoor()
    {
        isOpening = true;
        isClosing = false;
    }

    public void CloseDoor()
    {
        isClosing = true;
        isOpening = false;
    }
}
