using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Referencia al UI Text para mostrar el tiempo
    public GameObject gameplayElements; // Referencia a GameplayElements
    private float elapsedTime = 0f; // Tiempo transcurrido en segundos
    private bool isGameActive = false; // Estado del juego

    void Update()
    {
        // Verifica si GameplayElements está activo
        if (gameplayElements != null && gameplayElements.activeSelf && !isGameActive)
        {
            isGameActive = true;
            Debug.Log("GameplayElements activado. Temporizador iniciado.");
        }

        // Incrementa el tiempo solo si el juego está activo
        if (isGameActive)
        {
            elapsedTime += Time.deltaTime;

            // Convierte el tiempo a minutos, segundos y milisegundos
            int minutes = Mathf.FloorToInt(elapsedTime / 60f);
            int seconds = Mathf.FloorToInt(elapsedTime % 60f);
            int milliseconds = Mathf.FloorToInt((elapsedTime % 1) * 1000);

            // Actualiza el texto del contador
            timerText.text = $"Time: {minutes:00}:{seconds:00}:{milliseconds:000}";
        }
    }

    // Detener el contador
    public void StopTimer()
    {
        isGameActive = false;
    }

    // Obtener el tiempo final formateado
    public string GetFormattedTime()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        int milliseconds = Mathf.FloorToInt((elapsedTime % 1) * 1000);
        return $"{minutes:00}:{seconds:00}:{milliseconds:000}";
    }
}
