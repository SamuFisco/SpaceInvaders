using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Referencia al texto que muestra los puntos
    private int totalScore = 0; // Puntuaci�n total

    // M�todo para agregar puntos seg�n la fila
    public void AddPoints(int fila)
    {
        int pointsToAdd = 0;

        // Determina los puntos seg�n la fila
        switch (fila)
        {
            case 1: pointsToAdd = 40; break; // Fila m�s alejada
            case 2: pointsToAdd = 30; break;
            case 3: pointsToAdd = 20; break;
            case 4: pointsToAdd = 10; break; // Fila m�s pr�xima
            default: Debug.LogError("Fila inv�lida asignada al enemigo."); break;
        }

        totalScore += pointsToAdd;
        UpdateScoreUI();
    }

    // Actualiza el texto de los puntos
    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + totalScore;
        }
    }
}
