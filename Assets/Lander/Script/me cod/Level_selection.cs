using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Cinemachine.DocumentationSortingAttribute;
using System.IO;

public class LevelSelection : MonoBehaviour
{
    public GameObject button_level;
    public int level;
    private int currentLevel;
    private string fileName = "level.txt";

    public Image image; // Ссылка на компонент Image объекта, у которого нужно менять спрайт
    public Sprite[] sprites; // Массив спрайтов для выбора

    private bool HasSavedLevel()
    {
        string filePath = Path.Combine(Application.persistentDataPath, fileName);
        return File.Exists(filePath);
    }

    private int LoadSavedLevel()
    {
        string filePath = Path.Combine(Application.persistentDataPath, fileName);
        string levelString = File.ReadAllText(filePath);
        int savedLevel = int.Parse(levelString);
        return savedLevel;
    }

    private void SaveLevel(int level)
    {
        string filePath = Path.Combine(Application.persistentDataPath, fileName);
        string levelString = level.ToString();
        File.WriteAllText(filePath, levelString);
    }



    void Start()
    {
        Button btn = button_level.GetComponent<Button>();
        // Добавляем метод-обработчик события нажатия на кнопку
        btn.onClick.AddListener(TaskOnClick);
        // Проверяем наличие сохранения уровня
        if (HasSavedLevel())
        {
            // Загружаем сохраненный уровень
            int savedLevel = LoadSavedLevel();
            GlobalData.GlobalDataCarrier.Level = LoadSavedLevel();
            Debug.Log("Сохранил " + GlobalData.GlobalDataCarrier.Level);

            // Сравниваем сохраненный уровень с текущим уровнем
            if (savedLevel < currentLevel)
            {
                // Обновляем сохранение на текущий уровень
                SaveLevel(currentLevel);

            }
            else
            {
                // Текущий уровень не выше сохраненного, оставляем сохранение без изменений
                currentLevel = savedLevel;

            }
        }
        else
        {
            // Если сохранение отсутствует, сохраняем текущий уровень
            SaveLevel(1);
            GlobalData.GlobalDataCarrier.Level = 1;
        }



        switch (level)
        {
            case (1):
                if (GlobalData.GlobalDataCarrier.Level == 1 || GlobalData.GlobalDataCarrier.Level >= 1)
                {
                    image.sprite = sprites[1];
                } else
                {
                    image.sprite = sprites[0];
                }
                break;

            case (2):
                if (GlobalData.GlobalDataCarrier.Level == 2 || GlobalData.GlobalDataCarrier.Level >= 2)
                {
                    image.sprite = sprites[1];
                } else
                {
                    image.sprite = sprites[0];
                }
                break;

            case (3):
                if (GlobalData.GlobalDataCarrier.Level == 3 || GlobalData.GlobalDataCarrier.Level >= 3)
                {
                    image.sprite = sprites[1];
                }
                else
                {
                    image.sprite = sprites[0];
                }
                break;

            case (4):
                if (GlobalData.GlobalDataCarrier.Level == 4 || GlobalData.GlobalDataCarrier.Level >= 4)
                {
                    image.sprite = sprites[1];
                }
                else
                {
                    image.sprite = sprites[0];
                }
                break;

            case (5):
                if (GlobalData.GlobalDataCarrier.Level == 5 || GlobalData.GlobalDataCarrier.Level >= 5)
                {
                    image.sprite = sprites[1];
                }
                else
                {
                    image.sprite = sprites[0];
                }
                break;

            case (6):
                if (GlobalData.GlobalDataCarrier.Level == 6 || GlobalData.GlobalDataCarrier.Level >= 6)
                {
                    image.sprite = sprites[1];
                }
                else
                {
                    image.sprite = sprites[0];
                }
                break;

            case (7):
                if (GlobalData.GlobalDataCarrier.Level == 7 || GlobalData.GlobalDataCarrier.Level >= 7)
                {
                    image.sprite = sprites[1];
                }
                else
                {
                    image.sprite = sprites[0];
                }
                break;

            case (8):
                if (GlobalData.GlobalDataCarrier.Level == 8 || GlobalData.GlobalDataCarrier.Level >= 8)
                {
                    image.sprite = sprites[1];
                }
                else
                {
                    image.sprite = sprites[0];
                }
                break;

            case (9):
                if (GlobalData.GlobalDataCarrier.Level == 9 || GlobalData.GlobalDataCarrier.Level >= 9)
                {
                    image.sprite = sprites[1];
                }
                else
                {
                    image.sprite = sprites[0];
                }
                break;

            case (10):
                if (GlobalData.GlobalDataCarrier.Level == 10 || GlobalData.GlobalDataCarrier.Level >= 10)
                {
                    image.sprite = sprites[1];
                }
                else
                {
                    image.sprite = sprites[0];
                }
                break;
        }
    }
    private void TaskOnClick()
    {
        switch (level)
        {
            case (1):
                if (GlobalData.GlobalDataCarrier.Level == 1 || GlobalData.GlobalDataCarrier.Level >= 1)
                {
                    SceneManager.LoadScene("Lander1");
                    GlobalData.GlobalDataCarrier.FirstRun = true;
                    GlobalData.GlobalDataCarrier.Score = 0;
                    GlobalData.GlobalDataCarrier.Fuel = 1500.0f;
                    GlobalData.GlobalDataCarrier.LandedStatus = false;
                    GlobalData.GlobalDataCarrier.LandedStatusOk = false;

                }
                break;

            case (2):
                if (GlobalData.GlobalDataCarrier.Level == 2 || GlobalData.GlobalDataCarrier.Level >= 2)
                {
                    SceneManager.LoadScene("Lander2");
                    GlobalData.GlobalDataCarrier.FirstRun = true;
                    GlobalData.GlobalDataCarrier.Score = 0;
                    GlobalData.GlobalDataCarrier.Fuel = 600.0f;
                    GlobalData.GlobalDataCarrier.LandedStatus = false;
                    GlobalData.GlobalDataCarrier.LandedStatusOk = false;
                }
                break;

            case (3):
                if (GlobalData.GlobalDataCarrier.Level == 3 || GlobalData.GlobalDataCarrier.Level >= 3)
                {
                    SceneManager.LoadScene("Lander3");
                    GlobalData.GlobalDataCarrier.FirstRun = true;
                    GlobalData.GlobalDataCarrier.Score = 0;
                    GlobalData.GlobalDataCarrier.Fuel = 600.0f;
                    GlobalData.GlobalDataCarrier.LandedStatus = false;
                    GlobalData.GlobalDataCarrier.LandedStatusOk = false;
                }
                break;

            case (4):
                if (GlobalData.GlobalDataCarrier.Level == 4 || GlobalData.GlobalDataCarrier.Level >= 4)
                {
                    GlobalData.GlobalDataCarrier.FirstRun = true;
                    GlobalData.GlobalDataCarrier.Score = 0;
                    GlobalData.GlobalDataCarrier.Fuel = 400.0f;
                    GlobalData.GlobalDataCarrier.LandedStatus = false;
                    GlobalData.GlobalDataCarrier.LandedStatusOk = false;
                    SceneManager.LoadScene("Lander4");
                }
                break;

            case (5):
                if (GlobalData.GlobalDataCarrier.Level == 5 || GlobalData.GlobalDataCarrier.Level >= 5)
                {
                    GlobalData.GlobalDataCarrier.FirstRun = true;
                    GlobalData.GlobalDataCarrier.Score = 0;
                    GlobalData.GlobalDataCarrier.Fuel = 400.0f;
                    GlobalData.GlobalDataCarrier.LandedStatus = false;
                    GlobalData.GlobalDataCarrier.LandedStatusOk = false;
                    SceneManager.LoadScene("Lander5");
                }
                break;

            case (6):
                if (GlobalData.GlobalDataCarrier.Level == 6 || GlobalData.GlobalDataCarrier.Level >= 6)
                {
                    GlobalData.GlobalDataCarrier.FirstRun = true;
                    GlobalData.GlobalDataCarrier.Score = 0;
                    GlobalData.GlobalDataCarrier.Fuel = 350.0f;
                    GlobalData.GlobalDataCarrier.LandedStatus = false;
                    GlobalData.GlobalDataCarrier.LandedStatusOk = false;
                    SceneManager.LoadScene("Lander6");
                }
                break;

            case (7):
                if (GlobalData.GlobalDataCarrier.Level == 7 || GlobalData.GlobalDataCarrier.Level >= 7)
                {
                    GlobalData.GlobalDataCarrier.FirstRun = true;
                    GlobalData.GlobalDataCarrier.Score = 0;
                    GlobalData.GlobalDataCarrier.Fuel = 400.0f;
                    GlobalData.GlobalDataCarrier.LandedStatus = false;
                    GlobalData.GlobalDataCarrier.LandedStatusOk = false;
                    SceneManager.LoadScene("Lander7");
                }
                break;

            case (8):
                if (GlobalData.GlobalDataCarrier.Level == 8 || GlobalData.GlobalDataCarrier.Level >= 8)
                {
                    GlobalData.GlobalDataCarrier.FirstRun = true;
                    GlobalData.GlobalDataCarrier.Score = 0;
                    GlobalData.GlobalDataCarrier.Fuel = 800.0f;
                    GlobalData.GlobalDataCarrier.LandedStatus = false;
                    GlobalData.GlobalDataCarrier.LandedStatusOk = false;
                    SceneManager.LoadScene("Lander8");
                }
                break;

            case (9):
                if (GlobalData.GlobalDataCarrier.Level == 9 || GlobalData.GlobalDataCarrier.Level >= 9)
                {
                    GlobalData.GlobalDataCarrier.FirstRun = true;
                    GlobalData.GlobalDataCarrier.Score = 0;
                    GlobalData.GlobalDataCarrier.Fuel = 600.0f;
                    GlobalData.GlobalDataCarrier.LandedStatus = false;
                    GlobalData.GlobalDataCarrier.LandedStatusOk = false;
                    SceneManager.LoadScene("Lander9");
                }
                break;

            case (10):
                if (GlobalData.GlobalDataCarrier.Level == 10 || GlobalData.GlobalDataCarrier.Level >= 10)
                {
                    GlobalData.GlobalDataCarrier.FirstRun = true;
                    GlobalData.GlobalDataCarrier.Score = 0;
                    GlobalData.GlobalDataCarrier.Fuel = 400.0f;
                    GlobalData.GlobalDataCarrier.LandedStatus = false;
                    GlobalData.GlobalDataCarrier.LandedStatusOk = false;
                    SceneManager.LoadScene("Lander10");
                }
                break;

            //fault:
                // Обновляем сохранение на текущий уровень
        
                //SceneManager.LoadScene("Lander10");
    }
    }

}