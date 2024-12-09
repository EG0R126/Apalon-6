using UnityEngine;

public class QuitGame : MonoBehaviour
{
    // Ётот метод будет вызыватьс€ дл€ выхода из игры
    public void ExitGame()
    {
        // ѕровер€ем, запущена ли игра в редакторе
#if UNITY_EDITOR
        // ≈сли да, то останавливаем игру в редакторе
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // ≈сли нет, то выходим из приложени€
        Application.Quit();
#endif
    }
}