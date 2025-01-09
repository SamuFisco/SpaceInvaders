using UnityEngine;
using UnityEngine.SceneManagement;

public class InvadersSceneManager : MonoBehaviour
{
    public GameTimer gameTimer; // Referencia al GameTimer
    public ScoreManager scoreManager; // Referencia al ScoreManager

    public void OnPlayerWin()
    {
        if (GameManager.Instance != null)
        {
            int finalScore = scoreManager.GetTotalScore();
            float finalTime = gameTimer.GetElapsedTime();

            Debug.Log($"Guardando valores en GameManager: Final Score={finalScore}, Final Time={finalTime}");

            GameManager.Instance.SetFinalResults(finalScore, finalTime);
        }
        else
        {
            Debug.LogError("GameManager no está disponible al intentar guardar resultados.");
        }

        // Cambia a la escena "Win"
        SceneManager.LoadScene("Win");
    }
}
