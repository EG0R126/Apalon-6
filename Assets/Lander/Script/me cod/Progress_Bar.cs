using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress_Bar : MonoBehaviour
{
    private float value = GlobalData.GlobalDataCarrier.Fuel; // Обычная переменная, значение которой будет использоваться для изменения ширины изображения
    public Slider slider;

    void Start()
    {
        slider.maxValue = value;
    }
    

    void Update()
    {
        value = GlobalData.GlobalDataCarrier.Fuel;
        slider.value = value;
    }
}
