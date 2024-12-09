using System;
using UnityEngine;
using UnityEngine.UI; // ��� ������ � UI ����������

public class Musiic_off_on : MonoBehaviour
{
    public GameObject musicObject;   // ������, ������� ����� ��������/���������
    public Image imageToChange;      // �����������, ������� ����� ������
    public Sprite spriteOn;          // �������� ��� ��������� "��������"
    public Sprite spriteOff;         // �������� ��� ��������� "���������"



    public void Start()
    {
        if (GlobalData.GlobalDataCarrier.StateMusiic == false)
        {
            imageToChange.sprite = spriteOff;  // ������ ����������� �� "�����������"
        } 
        else
        {
            imageToChange.sprite = spriteOn;
        }
    }
    public void ToggleMusic()
    {
        if (GlobalData.GlobalDataCarrier.StateMusiic)    // ���� ��������� ���� "���������"...
        {
            imageToChange.sprite = spriteOff;  // ������ ����������� �� "�����������"
            GlobalData.GlobalDataCarrier.StateMusiic = false;                  // ����������� ��������� �� "��������"
        }
        else // �����, ���� ��������� ���� "��������"...
        {
            imageToChange.sprite = spriteOn;  // ������ ����������� �� "����������"
            GlobalData.GlobalDataCarrier.StateMusiic = true;                  // ����������� ��������� �� "���������"
        }
       
    }
}
