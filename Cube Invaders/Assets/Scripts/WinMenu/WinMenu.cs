using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor; // Solo disponible en el editor
#endif

public class WinMenu : MonoBehaviour
{
    public void GoToIntro()
    {
        SceneManager.LoadScene("Intro");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        // Detiene la ejecución en el editor
        EditorApplication.isPlaying = false;
#else
        // Cierra la aplicación en la build
        Application.Quit();
#endif
        Debug.Log("El juego se ha cerrado.");
    }
}

