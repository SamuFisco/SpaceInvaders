using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Configuración del enemigo")]
    public int fila = 1; // Fila a la que pertenece el enemigo (1 a 4)

    void OnDestroy()
    {
        // Agrega los puntos al ScoreManager
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager != null)
        {
            scoreManager.AddPoints(fila);
        }
    }
}
