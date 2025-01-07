using UnityEngine;
using TMPro;

public class MostrarResultados : MonoBehaviour
{
    public TextMeshProUGUI finalTimeText; // Referencia al texto del tiempo
    public TextMeshProUGUI finalScoreText; // Referencia al texto del puntaje

    void Start()
    {
        if (GameManager.Instance != null)
        {
            // Mostrar el tiempo formateado
            finalTimeText.text = $"Time: {GameManager.Instance.ElapsedTime:0.00}s";

            // Mostrar el puntaje
            finalScoreText.text = $"Score: {GameManager.Instance.Score}";
        }
        else
        {
            Debug.LogError("GameManager no encontrado. Asegúrate de que persista entre escenas.");
        }
    }
}
