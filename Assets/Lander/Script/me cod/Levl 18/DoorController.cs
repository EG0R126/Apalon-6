using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
    public float openAngle = 89f; // Угол в открытом состоянии
    public float closeAngle = 0f; // Угол в закрытом состоянии
    public float speed = 200f; // Скорость вращения двери



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
                isOpening = false; // Достигли полного открытия
            }
        }

        if (isClosing)
        {
            float newAngle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, closeAngle, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, newAngle);

            if (Mathf.Approximately(newAngle, closeAngle))
            {
                isClosing = false; // Достигли полного закрытия

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
