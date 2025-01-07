using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public void EnemyDestroyed(int points)
    {
        Debug.Log($"Intentando añadir puntos: {points}");

        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddScore(points);
        }
        else
        {
            Debug.LogError("GameManager no está disponible.");
        }
    }
}

