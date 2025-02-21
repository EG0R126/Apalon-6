using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System;
using System.IO;
using static Cinemachine.DocumentationSortingAttribute;

public class TimeOut : MonoBehaviour
{

    public GameObject Lander_0;
    public Text StatusText;
    private PlayerControl ScriptToAccess;
    private LanderSense Script2ToAccess;
    public int currentLevel;

    public Text LevelText;
    private float timeRemaining;
    private bool Chrashed;
    private bool Landed;
    private bool Lost;
    public AudioSource LandedVoice;
    private string fileName = "level.txt";

    public GameObject panel;
    public GameObject Restart_button; 
    public GameObject Manu_button;


    // Use this for initialization
    



    private bool HasSavedLevel()
    {
        string filePath = Path.Combine(UnityEngine.Application.persistentDataPath, fileName);
        return File.Exists(filePath);
    }

    private int LoadSavedLevel()
    {
        string filePath = Path.Combine(UnityEngine.Application.persistentDataPath, fileName);
        string levelString = File.ReadAllText(filePath);
        int savedLevel = int.Parse(levelString);
        return savedLevel;
    }

    private void SaveLevel(int level)
    {
        string filePath = Path.Combine(UnityEngine.Application.persistentDataPath, fileName);
        string levelString = level.ToString();
        File.WriteAllText(filePath, levelString);
    }





    void Start()
    {
        Time.timeScale = 1f;
        ScriptToAccess = Lander_0.GetComponent<PlayerControl>();
        Script2ToAccess = Lander_0.GetComponent<LanderSense>();

        Chrashed = false;
        Landed = false;
        Lost = false;

        panel.SetActive(false);
        Button btn = Restart_button.GetComponent<Button>();
        Button s = Manu_button.GetComponent<Button>();
        // Добавляем метод-обработчик события нажатия на кнопку
        btn.onClick.AddListener(TaskOnClick);
        s.onClick.AddListener(ManuButton);

        UpdateScoreText();

    }

    private void ManuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Manu_Scene");
        GlobalData.GlobalDataCarrier.LandedLeft = false;
        GlobalData.GlobalDataCarrier.LandedRight = false;
        Script2ToAccess.Landed = false;
        Script2ToAccess.Chrashed = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckTimeExec();
        CheckLandedExec();
        CheckCrashExec();
        CheckLostExec();
        CheckRunningsExec();
    }

    void UpdateScoreText()
    {
        LevelText.text = ("Уровень :" + (currentLevel - 1));
    }

    void CheckTimeExec()
    {
        timeRemaining = ScriptToAccess.timeRemaining;
        if (timeRemaining <= 0.1f)
        {
            StatusText.text = ("Время вышло");
            StartCoroutine(PauseExecution(5f, 0f, true));
        }
    }



    void CheckLandedExec()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Landed = Script2ToAccess.Landed;
        Chrashed = Script2ToAccess.Chrashed;
        if (Landed & Chrashed)
        {
            panel.SetActive(true);

            StatusText.text = ("Поломка на платформе");
            GlobalData.GlobalDataCarrier.LandedLeft = false;
            GlobalData.GlobalDataCarrier.LandedRight = false;
          
            StartCoroutine(PauseExecution(5f, 0.3f, true));
        }
        else if (GlobalData.GlobalDataCarrier.LandedLeft & GlobalData.GlobalDataCarrier.LandedRight)
        {

            //* Kolla hastigheten just vid det ögonblick då båda benen touchar


            if ((rb.rotation < 1.0f) & (rb.rotation >-1.0f) & ((Vector2.SqrMagnitude(rb.linearVelocity) * 10) < 1.0f) & GlobalData.GlobalDataCarrier.LandedStatusOk == false)
            {
                LandedVoice.Play();
                GlobalData.GlobalDataCarrier.LandedStatusOk = true;
                StatusText.text = ("Хьюстон мы на платформе!" + Convert.ToChar(10));
                GlobalData.GlobalDataCarrier.LandedLeft = false;
                GlobalData.GlobalDataCarrier.LandedRight = false;
                StartCoroutine(PauseExecution(5f, 0.3f, false));
                panel.SetActive(true);
                Restart_button.SetActive(false);
                Manu_button.SetActive(false);


                if (HasSavedLevel())
                {
                    // Загружаем сохраненный уровень
                    int savedLevel = LoadSavedLevel();
                    Debug.Log("Сохранил " + GlobalData.GlobalDataCarrier.Level);

                    // Сравниваем сохраненный уровень с текущим уровнем
                    if (savedLevel < currentLevel)
                    {
                        // Обновляем сохранение на текущий уровень
                        SaveLevel(currentLevel);
                        GlobalData.GlobalDataCarrier.Level = currentLevel;
                        Debug.Log("Доступен новый уровень " + GlobalData.GlobalDataCarrier.Level);
                    }
                }

            }
        }

    }

    

    void CheckRunningsExec()
    {
        if (!GlobalData.GlobalDataCarrier.LandedStatusOk)
        {
            if (GlobalData.GlobalDataCarrier.Fuel == 0 || GlobalData.GlobalDataCarrier.Fuel < 0)
            {
                panel.SetActive(true);

                StatusText.text = ("Хьюстон мы без топлива");
                StartCoroutine(PauseExecution(5f, 0.3f, true));
            }
        }
    }


    void CheckCrashExec()
    {
        if (!GlobalData.GlobalDataCarrier.LandedStatusOk)
        {
            Chrashed = Script2ToAccess.Chrashed;
            if (Chrashed & !Landed)
            {
                panel.SetActive(true);

                StatusText.text = ("Хьюстон мы разбились");
                StartCoroutine(PauseExecution(5f, 0.3f, true));
            }
        }
    }
    void CheckLostExec()
    {
        if (!GlobalData.GlobalDataCarrier.LandedStatusOk)
        {
            Lost = Script2ToAccess.Lost;
            if (Lost)
            {
                panel.SetActive(true);

                StatusText.text = ("Хьюстон мы отправились в космом");
                StartCoroutine(PauseExecution(5f, 0f, true));
            }
        }
    }


    void TaskOnClick()
    {
        Time.timeScale = 1f;
        GlobalData.GlobalDataCarrier.LandedStatus = false;
        GlobalData.GlobalDataCarrier.LandedLeft = false;
        GlobalData.GlobalDataCarrier.LandedRight = false;
        switch (currentLevel - 1)
        {
            case (1):
                SceneManager.LoadScene("Lander1");
                GlobalData.GlobalDataCarrier.Fuel = 1500.0f;
                break;
            case (2):
                SceneManager.LoadScene("Lander2");
                GlobalData.GlobalDataCarrier.Fuel = 600.0f;
                break;
            case (3):
                SceneManager.LoadScene("Lander3");
                GlobalData.GlobalDataCarrier.Fuel = 600.0f;
                break;
            case (4):
                SceneManager.LoadScene("Lander4");
                GlobalData.GlobalDataCarrier.Fuel = 400.0f;
                break;
            case (5):
                SceneManager.LoadScene("Lander5");
                GlobalData.GlobalDataCarrier.Fuel = 400.0f;
                break;
            case (6):
                SceneManager.LoadScene("Lander6");
                GlobalData.GlobalDataCarrier.Fuel = 350.0f;
                break;
            case (7):
                SceneManager.LoadScene("Lander7");
                GlobalData.GlobalDataCarrier.Fuel = 400.0f;
                break;
            case (8):
                SceneManager.LoadScene("Lander8");
                GlobalData.GlobalDataCarrier.Fuel = 800.0f;
                break;
            case (9):
                SceneManager.LoadScene("Lander9");
                GlobalData.GlobalDataCarrier.Fuel = 600.0f;
                break;
            case (10):
                SceneManager.LoadScene("Lander10");
                GlobalData.GlobalDataCarrier.Fuel = 400.0f;
                break;
            case (11):
                SceneManager.LoadScene("Lander11");
                GlobalData.GlobalDataCarrier.Fuel = 1500.0f;
                break;
            case (12):
                SceneManager.LoadScene("Lander12");
                GlobalData.GlobalDataCarrier.Fuel = 2000.0f;
                break;
            case (13):
                SceneManager.LoadScene("Lander13");
                GlobalData.GlobalDataCarrier.Fuel = 3000.0f;
                break;
            case (14):
                SceneManager.LoadScene("Lander14");
                GlobalData.GlobalDataCarrier.Fuel = 2000.0f;
                break;
            case (15):
                SceneManager.LoadScene("Lander15");
                GlobalData.GlobalDataCarrier.Fuel = 2500.0f;
                break;
            case (16):
                SceneManager.LoadScene("Lander16");
                GlobalData.GlobalDataCarrier.Fuel = 1500.0f;
                break;
            case (17):
                SceneManager.LoadScene("Lander17");
                GlobalData.GlobalDataCarrier.Fuel = 3000.0f;
                break;
            case (18):
                SceneManager.LoadScene("Lander18");
                GlobalData.GlobalDataCarrier.Fuel = 3000.0f;
                break;
            case (19):
                SceneManager.LoadScene("Lander19");
                GlobalData.GlobalDataCarrier.Fuel = 8000.0f;
                break;
            case (20):
                SceneManager.LoadScene("Lander20");
                GlobalData.GlobalDataCarrier.Fuel = 10000.0f;
                break;
        }

        //Поменять логику для каждого уровння должно быть своё кол-во топлива
    }
    public IEnumerator PauseExecution(float pauseTime, float slowMot, bool GameOver)
    {

        Time.timeScale = slowMot;

        float pauseEndTime = Time.realtimeSinceStartup + pauseTime;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {

            yield return 0;
        }

        Time.timeScale = 1f;
        if (GameOver)
        {           
            GlobalData.GlobalDataCarrier.LandedLeft = false;
            GlobalData.GlobalDataCarrier.LandedRight = false;
            Script2ToAccess.Landed = false;
            Script2ToAccess.Chrashed = false;
            //SceneManager.LoadScene("StartScene");

        }
        else
        {
            if (GlobalData.GlobalDataCarrier.LandedStatus == false)
            {
                GlobalData.GlobalDataCarrier.LandedStatus = true;
                GlobalData.GlobalDataCarrier.LandedLeft = false;
                GlobalData.GlobalDataCarrier.LandedRight = false;
                Debug.Log(GlobalData.GlobalDataCarrier.Level);
                Time.timeScale = 1f;
                switch (currentLevel)
                {
                    case (1):
                        SceneManager.LoadScene("Lander1");
                        GlobalData.GlobalDataCarrier.Fuel = 1500.0f;
                        break;
                    case (2):
                        SceneManager.LoadScene("Lander2");
                        GlobalData.GlobalDataCarrier.Fuel = 600.0f;
                        break;
                    case (3):
                        SceneManager.LoadScene("Lander3");
                        GlobalData.GlobalDataCarrier.Fuel = 600.0f;
                        break;
                    case (4):
                        SceneManager.LoadScene("Lander4");
                        GlobalData.GlobalDataCarrier.Fuel = 400.0f;
                        break;
                    case (5):
                        SceneManager.LoadScene("Lander5");
                        GlobalData.GlobalDataCarrier.Fuel = 400.0f;
                        break;
                    case (6):
                        SceneManager.LoadScene("Lander6");
                        GlobalData.GlobalDataCarrier.Fuel = 350.0f;
                        break;
                    case (7):
                        SceneManager.LoadScene("Lander7");
                        GlobalData.GlobalDataCarrier.Fuel = 400.0f;
                        break;
                    case (8):
                        SceneManager.LoadScene("Lander8");
                        GlobalData.GlobalDataCarrier.Fuel = 800.0f;
                        break;
                    case (9):
                        SceneManager.LoadScene("Lander9");
                        GlobalData.GlobalDataCarrier.Fuel = 600.0f;
                        break;
                    case (10):
                        SceneManager.LoadScene("Lander10");
                        GlobalData.GlobalDataCarrier.Fuel = 400.0f;
                        break;
                    case (11):
                        SceneManager.LoadScene("Lander11");
                        GlobalData.GlobalDataCarrier.Fuel = 1500.0f;
                        break;
                    case (12):
                        SceneManager.LoadScene("Lander12");
                        GlobalData.GlobalDataCarrier.Fuel = 2000.0f;
                        break;
                    case (13):
                        SceneManager.LoadScene("Lander13");
                        GlobalData.GlobalDataCarrier.Fuel = 3000.0f;
                        break;
                    case (14):
                        SceneManager.LoadScene("Lander14");
                        GlobalData.GlobalDataCarrier.Fuel = 3000.0f;
                        break;
                    case (15):
                        SceneManager.LoadScene("Lander15");
                        GlobalData.GlobalDataCarrier.Fuel = 2500.0f;
                        break;
                    case (16):
                        SceneManager.LoadScene("Lander16");
                        GlobalData.GlobalDataCarrier.Fuel = 1500.0f;
                        break;
                    case (17):
                        SceneManager.LoadScene("Lander17");
                        GlobalData.GlobalDataCarrier.Fuel = 3000.0f;
                        break;
                    case (18):
                        SceneManager.LoadScene("Lander18");
                        GlobalData.GlobalDataCarrier.Fuel = 3500.0f;
                        break;
                    case (19):
                        SceneManager.LoadScene("Lander19");
                        GlobalData.GlobalDataCarrier.Fuel = 8000.0f;
                        break;
                    case (20):
                        SceneManager.LoadScene("Lander20");
                        GlobalData.GlobalDataCarrier.Fuel = 10000.0f;
                        break;

                }

            }
        }
    }
}