using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI; // Для работы с UI элементами

public class Musiic_off_on : MonoBehaviour
{
    public Image imageToChange;      // Изображение, которое нужно менять
    public Sprite spriteOn;          // Картинка для состояния "включено"
    public Sprite spriteOff;         // Картинка для состояния "выключено"

    private Button button;


    public void Start()
    {
        if (GlobalData.GlobalDataCarrier.StateMusiic == false)
        {
            imageToChange.sprite = spriteOn;  // Измени изображение на "выключенное"
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
        if (GlobalData.GlobalDataCarrier.StateMusiic)    // Если состояние было "выключено"...
        {
            imageToChange.sprite = spriteOn;  // Измени изображение на "выключенное"
            GlobalData.GlobalDataCarrier.StateMusiic = false;                  // Переключаем состояние на "включено"
        }
        else // Иначе, если состояние было "включено"...
        {
            imageToChange.sprite = spriteOff;  // Измени изображение на "включенное"
            GlobalData.GlobalDataCarrier.StateMusiic = true;                  // Переключаем состояние на "выключено"
        }
       
    }

    private void OnButtonClicked()
    {
        // Находим объект по тегу
        GameObject persistentObj = GameObject.FindWithTag("Sound_off_on");

        if (persistentObj != null)
        {
            Debug.Log("Нашёл");
            // Вызываем метод
            persistentObj.GetComponent<SoundPlayer>().Sound_off_on();
        }
    }
}
