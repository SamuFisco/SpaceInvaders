using UnityEngine;
using TMPro;

public class VictoryManager : MonoBehaviour
{
    public GameObject victoryCanvas; // Referencia al Canvas de victoria
    public TextMeshProUGUI scoreText; // Texto para mostrar el puntaje
    public TextMeshProUGUI timeText; // Texto para mostrar el tiempo
    public GameTimer gameTimer; // Referencia al GameTimer
    public ScoreManager scoreManager; // Referencia al ScoreManager

    private void Start()
    {
        // Asegúrate de que el Canvas esté desactivado al inicio
        if (victoryCanvas != null)
        {
            victoryCanvas.SetActive(false);
        }
        else
        {
            Debug.LogError("VictoryCanvas no asignado en VictoryManager.");
        }
    }

    public void DisplayVictory()
    {
        Debug.Log("LlamadoDisplayVida");

        // Validación de referencias
        if (victoryCanvas == null)
        {
            Debug.LogError("VictoryCanvas no asignado en VictoryManager.");
            return;
        }

        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager no asignado en VictoryManager.");
            return;
        }

        if (gameTimer == null)
        {
            Debug.LogError("GameTimer no asignado en VictoryManager.");
            return;
        }

        // Activa el Canvas
        victoryCanvas.SetActive(true);

        // Pausa el juego
        Time.timeScale = 0;

        // Obtiene los valores de puntaje y tiempo
       int finalScore = scoreManager.GetTotalScore();
        float finalTime = gameTimer.GetElapsedTime();

        // Actualiza los textos
        if (scoreText != null)
        {
            scoreText.text = "Final Score: " + finalScore;
        }
        else
        {
            Debug.LogError("ScoreText no asignado en VictoryManager.");
        }

        if (timeText != null)
        {
            int minutes = Mathf.FloorToInt(finalTime / 60f);
            int seconds = Mathf.FloorToInt(finalTime % 60f);
            int milliseconds = Mathf.FloorToInt((finalTime % 1) * 1000);
            timeText.text = $"Final Time: {minutes:00}:{seconds:00}:{milliseconds:000}";
        }
        else
        {
            Debug.LogError("TimeText no asignado en VictoryManager.");
        }
    }
}
