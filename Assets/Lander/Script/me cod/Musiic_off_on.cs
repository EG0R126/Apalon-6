using System;
using UnityEngine;
using UnityEngine.UI; // Для работы с UI элементами

public class Musiic_off_on : MonoBehaviour
{
    public GameObject musicObject;   // Объект, который нужно включать/выключать
    public Image imageToChange;      // Изображение, которое нужно менять
    public Sprite spriteOn;          // Картинка для состояния "включено"
    public Sprite spriteOff;         // Картинка для состояния "выключено"



    public void Start()
    {
        if (GlobalData.GlobalDataCarrier.StateMusiic == false)
        {
            imageToChange.sprite = spriteOff;  // Измени изображение на "выключенное"
        } 
        else
        {
            imageToChange.sprite = spriteOn;
        }
    }
    public void ToggleMusic()
    {
        if (GlobalData.GlobalDataCarrier.StateMusiic)    // Если состояние было "выключено"...
        {
            imageToChange.sprite = spriteOff;  // Измени изображение на "выключенное"
            GlobalData.GlobalDataCarrier.StateMusiic = false;                  // Переключаем состояние на "включено"
        }
        else // Иначе, если состояние было "включено"...
        {
            imageToChange.sprite = spriteOn;  // Измени изображение на "включенное"
            GlobalData.GlobalDataCarrier.StateMusiic = true;                  // Переключаем состояние на "выключено"
        }
       
    }
}
