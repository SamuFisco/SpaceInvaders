using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesMenu : MonoBehaviour
{
    // Método público que cambia a la escena "Invaders"
    public void LaunchGame()
    {
        SceneManager.LoadScene("Selection");
    }
}
