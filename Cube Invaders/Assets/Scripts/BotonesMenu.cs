using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesMenu : MonoBehaviour
{
    // M�todo p�blico que cambia a la escena "Invaders"
    public void LaunchGame()
    {
        SceneManager.LoadScene("Selection");
    }
}
