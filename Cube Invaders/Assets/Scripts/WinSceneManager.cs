using UnityEngine;
using TMPro;

public class WinSceneManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;

    private void Start()
    {
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager no está disponible en la escena Win.");
            return;
        }

        int finalScore = GameManager.Instance.GetScore();
        float finalTime = GameManager.Instance.GetElapsedTime();

        Debug.Log($"Cargando valores en WinScene: Final Score={finalScore}, Final Time={finalTime}");

        if (scoreText != null)
        {
            scoreText.text = "Final Score: " + finalScore;
        }

        if (timeText != null)
        {
            int minutes = Mathf.FloorToInt(finalTime / 60f);
            int seconds = Mathf.FloorToInt(finalTime % 60f);
            int milliseconds = Mathf.FloorToInt((finalTime % 1) * 1000);
            timeText.text = $"Final Time: {minutes:00}:{seconds:00}:{milliseconds:000}";
        }
    }
}

