using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton

    public int Score { get; private set; } // Puntaje
    public float ElapsedTime { get; private set; } // Tiempo transcurrido

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persiste entre escenas
        }
        else
        {
            Destroy(gameObject); // Evitar duplicados
        }
    }

    private void Update()
    {
        // Actualizar el tiempo solo si es necesario
        ElapsedTime += Time.deltaTime;
    }

    // Método público para añadir puntaje
    public void AddScore(int points)
    {
        Score += points;
        Debug.Log($"Puntaje actualizado: {Score}");
    }

    // Método para reiniciar datos (opcional)
    public void ResetGame()
    {
        Score = 0;
        ElapsedTime = 0;
    }
}
