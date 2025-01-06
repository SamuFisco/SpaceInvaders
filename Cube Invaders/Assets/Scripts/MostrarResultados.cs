using TMPro;
using UnityEngine;

public class MostrarResultados : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Texto para el puntaje
    public TextMeshProUGUI timeText;  // Texto para el tiempo

    void Start()
    {
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager no está disponible.");
            return;
        }

        if (scoreText == null || timeText == null)
        {
            Debug.LogError("Los textos no están asignados en el Inspector.");
            return;
        }

        // Mostrar puntaje
        scoreText.text = $"Puntaje: {GameManager.Instance.Score}";

        // Mostrar tiempo final
        float totalTime = GameManager.Instance.ElapsedTime;
        int minutes = Mathf.FloorToInt(totalTime / 60f);
        int seconds = Mathf.FloorToInt(totalTime % 60f);
        timeText.text = $"Tiempo: {minutes:00}:{seconds:00}";
    }
}
