using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitToMenu : MonoBehaviour
{

    public GameObject button_level;

    void Start()
    {
        Button btn = button_level.GetComponent<Button>();
        // Добавляем метод-обработчик события нажатия на кнопку
        btn.onClick.AddListener(ExitToMenus);

    }

    private void ExitToMenus()
    {
        SceneManager.LoadScene("StartScene");
    }
}
