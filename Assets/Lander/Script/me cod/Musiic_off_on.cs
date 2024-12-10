using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI; // ��� ������ � UI ����������

public class Musiic_off_on : MonoBehaviour
{
    public Image imageToChange;      // �����������, ������� ����� ������
    public Sprite spriteOn;          // �������� ��� ��������� "��������"
    public Sprite spriteOff;         // �������� ��� ��������� "���������"

    private Button button;


    public void Start()
    {
        if (GlobalData.GlobalDataCarrier.StateMusiic == false)
        {
            imageToChange.sprite = spriteOn;  // ������ ����������� �� "�����������"
        } 
        else
        {
            imageToChange.sprite = spriteOff;
        }

        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClicked);
    }
    public void ToggleMusic()
    {
        if (GlobalData.GlobalDataCarrier.StateMusiic)    // ���� ��������� ���� "���������"...
        {
            imageToChange.sprite = spriteOn;  // ������ ����������� �� "�����������"
            GlobalData.GlobalDataCarrier.StateMusiic = false;                  // ����������� ��������� �� "��������"
        }
        else // �����, ���� ��������� ���� "��������"...
        {
            imageToChange.sprite = spriteOff;  // ������ ����������� �� "����������"
            GlobalData.GlobalDataCarrier.StateMusiic = true;                  // ����������� ��������� �� "���������"
        }
       
    }

    private void OnButtonClicked()
    {
        // ������� ������ �� ����
        GameObject persistentObj = GameObject.FindWithTag("Sound_off_on");

        if (persistentObj != null)
        {
            Debug.Log("�����");
            // �������� �����
            persistentObj.GetComponent<SoundPlayer>().Sound_off_on();
        }
    }
}
