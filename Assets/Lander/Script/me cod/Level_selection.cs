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
            case (11):
                if (GlobalData.GlobalDataCarrier.Level == 11 || GlobalData.GlobalDataCarrier.Level >= 11)
                {
                    image.sprite = sprites[1];
                }
                else
                {
                    image.sprite = sprites[0];
                }
                break;
            case (12):
                if (GlobalData.GlobalDataCarrier.Level == 12 || GlobalData.GlobalDataCarrier.Level >= 12)
                {
                    image.sprite = sprites[1];
                }
                else
                {
                    image.sprite = sprites[0];
                }
                break;
            case (13):
                if (GlobalData.GlobalDataCarrier.Level == 13 || GlobalData.GlobalDataCarrier.Level >= 13)
                {
                    image.sprite = sprites[1];
                }
                else
                {
                    image.sprite = sprites[0];
                }
                break;
            case (14):
                if (GlobalData.GlobalDataCarrier.Level == 14 || GlobalData.GlobalDataCarrier.Level >= 14)
                {
                    image.sprite = sprites[1];
                }
                else
                {
                    image.sprite = sprites[0];
                }
                break;
            case (15):
                if (GlobalData.GlobalDataCarrier.Level == 15 || GlobalData.GlobalDataCarrier.Level >= 15)
                {
                    image.sprite = sprites[1];
                }
                else
                {
                    image.sprite = sprites[0];
                }
                break;
            case (16):
                if (GlobalData.GlobalDataCarrier.Level == 16 || GlobalData.GlobalDataCarrier.Level >= 16)
                {
                    image.sprite = sprites[1];
                }
                else
                {
                    image.sprite = sprites[0];
                }
                break;
            case (17):
                if (GlobalData.GlobalDataCarrier.Level == 17 || GlobalData.GlobalDataCarrier.Level >= 17)
                {
                    image.sprite = sprites[1];
                }
                else
                {
                    image.sprite = sprites[0];
                }
                break;
            case (18):
                if (GlobalData.GlobalDataCarrier.Level == 18 || GlobalData.GlobalDataCarrier.Level >= 18)
                {
                    image.sprite = sprites[1];
                }
                else
                {
                    image.sprite = sprites[0];
                }
                break;
            case (19):
                if (GlobalData.GlobalDataCarrier.Level == 19 || GlobalData.GlobalDataCarrier.Level >= 19)
                {
                    image.sprite = sprites[1];
                }
                else
                {
                    image.sprite = sprites[0];
                }
                break;
            case (20):
                if (GlobalData.GlobalDataCarrier.Level == 20 || GlobalData.GlobalDataCarrier.Level >= 20)
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

            case (11):
                if (GlobalData.GlobalDataCarrier.Level == 11 || GlobalData.GlobalDataCarrier.Level >= 11)
                {
                    GlobalData.GlobalDataCarrier.FirstRun = true;
                    GlobalData.GlobalDataCarrier.Score = 0;
                    GlobalData.GlobalDataCarrier.Fuel = 1500.0f;
                    GlobalData.GlobalDataCarrier.LandedStatus = false;
                    GlobalData.GlobalDataCarrier.LandedStatusOk = false;
                    SceneManager.LoadScene("Lander11");
                }
                break;
            case (12):
                if (GlobalData.GlobalDataCarrier.Level == 12 || GlobalData.GlobalDataCarrier.Level >= 12)
                {
                    GlobalData.GlobalDataCarrier.FirstRun = true;
                    GlobalData.GlobalDataCarrier.Score = 0;
                    GlobalData.GlobalDataCarrier.Fuel = 2000.0f;
                    GlobalData.GlobalDataCarrier.LandedStatus = false;
                    GlobalData.GlobalDataCarrier.LandedStatusOk = false;
                    SceneManager.LoadScene("Lander12");
                }
                break;
            case (13):
                if (GlobalData.GlobalDataCarrier.Level == 13 || GlobalData.GlobalDataCarrier.Level >= 13)
                {
                    GlobalData.GlobalDataCarrier.FirstRun = true;
                    GlobalData.GlobalDataCarrier.Score = 0;
                    GlobalData.GlobalDataCarrier.Fuel = 3000.0f;
                    GlobalData.GlobalDataCarrier.LandedStatus = false;
                    GlobalData.GlobalDataCarrier.LandedStatusOk = false;
                    SceneManager.LoadScene("Lander13");
                }
                break;
            case (14):
                if (GlobalData.GlobalDataCarrier.Level == 14 || GlobalData.GlobalDataCarrier.Level >= 14)
                {
                    GlobalData.GlobalDataCarrier.FirstRun = true;
                    GlobalData.GlobalDataCarrier.Score = 0;
                    GlobalData.GlobalDataCarrier.Fuel = 3000.0f;
                    GlobalData.GlobalDataCarrier.LandedStatus = false;
                    GlobalData.GlobalDataCarrier.LandedStatusOk = false;
                    SceneManager.LoadScene("Lander14");
                }
                break;
            case (15):
                if (GlobalData.GlobalDataCarrier.Level == 15 || GlobalData.GlobalDataCarrier.Level >= 15)
                {
                    GlobalData.GlobalDataCarrier.FirstRun = true;
                    GlobalData.GlobalDataCarrier.Score = 0;
                    GlobalData.GlobalDataCarrier.Fuel = 2500.0f;
                    GlobalData.GlobalDataCarrier.LandedStatus = false;
                    GlobalData.GlobalDataCarrier.LandedStatusOk = false;
                    SceneManager.LoadScene("Lander15");

                }
                break;
            case (16):
                if (GlobalData.GlobalDataCarrier.Level == 16 || GlobalData.GlobalDataCarrier.Level >= 16)
                {
                    GlobalData.GlobalDataCarrier.FirstRun = true;
                    GlobalData.GlobalDataCarrier.Score = 0;
                    GlobalData.GlobalDataCarrier.Fuel = 1500.0f;
                    GlobalData.GlobalDataCarrier.LandedStatus = false;
                    GlobalData.GlobalDataCarrier.LandedStatusOk = false;
                    SceneManager.LoadScene("Lander16");
                }
                break;
            case (17):
                if (GlobalData.GlobalDataCarrier.Level == 17 || GlobalData.GlobalDataCarrier.Level >= 17)
                {
                    GlobalData.GlobalDataCarrier.FirstRun = true;
                    GlobalData.GlobalDataCarrier.Score = 0;
                    GlobalData.GlobalDataCarrier.Fuel = 3000.0f;
                    GlobalData.GlobalDataCarrier.LandedStatus = false;
                    GlobalData.GlobalDataCarrier.LandedStatusOk = false;
                    SceneManager.LoadScene("Lander17");
                }
                break;
            case (18):
                if (GlobalData.GlobalDataCarrier.Level == 18 || GlobalData.GlobalDataCarrier.Level >= 18)
                {
                    GlobalData.GlobalDataCarrier.FirstRun = true;
                    GlobalData.GlobalDataCarrier.Score = 0;
                    GlobalData.GlobalDataCarrier.Fuel = 3500.0f;
                    GlobalData.GlobalDataCarrier.LandedStatus = false;
                    GlobalData.GlobalDataCarrier.LandedStatusOk = false;
                    SceneManager.LoadScene("Lander18");
                }
                break;
            case (19):
                if (GlobalData.GlobalDataCarrier.Level == 19 || GlobalData.GlobalDataCarrier.Level >= 19)
                {
                    GlobalData.GlobalDataCarrier.FirstRun = true;
                    GlobalData.GlobalDataCarrier.Score = 0;
                    GlobalData.GlobalDataCarrier.Fuel = 8000.0f;
                    GlobalData.GlobalDataCarrier.LandedStatus = false;
                    GlobalData.GlobalDataCarrier.LandedStatusOk = false;
                    SceneManager.LoadScene("Lander19");
                }
                break;
            case (20):
                if (GlobalData.GlobalDataCarrier.Level == 20 || GlobalData.GlobalDataCarrier.Level >= 20)
                {
                    GlobalData.GlobalDataCarrier.FirstRun = true;
                    GlobalData.GlobalDataCarrier.Score = 0;
                    GlobalData.GlobalDataCarrier.Fuel = 10000.0f;
                    GlobalData.GlobalDataCarrier.LandedStatus = false;
                    GlobalData.GlobalDataCarrier.LandedStatusOk = false;
                    SceneManager.LoadScene("Lander20");
                }
                break;
        }
    }

}