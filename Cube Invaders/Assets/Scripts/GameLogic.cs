using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public void EnemyDestroyed(int points)
    {
        Debug.Log($"Intentando a�adir puntos: {points}");

        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddScore(points);
        }
        else
        {
            Debug.LogError("GameManager no est� disponible.");
        }
    }
}

