using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameTimer : MonoBehaviour
{
    [Header("Configuración")]
    public TextMeshProUGUI timerText; // Referencia al UI Text para mostrar el tiempo
    public GameObject gameplayElements; // Referencia al objeto GameplayElements
    private float elapsedTime = 0f; // Tiempo transcurrido en segundos
    private bool isGameActive = false; // Estado del juego

    void Update()
    {
        // Verificar si GameplayElements está activo
        if (gameplayElements != null && gameplayElements.activeSelf && !isGameActive)
        {
            isGameActive = true; // Activar el contador
        }

        if (isGameActive)
        {
            // Incrementa el tiempo transcurrido
            elapsedTime += Time.deltaTime;

            // Convierte el tiempo a minutos, segundos y milisegundos
            int minutes = Mathf.FloorToInt(elapsedTime / 60f);
            int seconds = Mathf.FloorToInt(elapsedTime % 60f);
            int milliseconds = Mathf.FloorToInt((elapsedTime % 1f) * 1000f);

            // Actualiza el texto del contador con "Time:" delante
            timerText.text = $"Time: {minutes:00}:{seconds:00}:{milliseconds:000}";
        }
    }

    // Detener el contador (puedes llamarlo en eventos como Game Over)
    public void StopTimer()
    {
        isGameActive = false;
    }

    // Reiniciar el contador (si es necesario para reiniciar el juego)
    public void ResetTimer()
    {
        elapsedTime = 0f;
        isGameActive = gameplayElements != null && gameplayElements.activeSelf;
    }
}
