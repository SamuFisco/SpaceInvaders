using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Mantener entre escenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int Score { get; private set; } // Puntaje
    public float ElapsedTime { get; private set; } // Tiempo transcurrido

    // Métodos para actualizar puntaje y tiempo
    public void AddScore(int points)
    {
        Score += points;
    }

    public void SetFinalTime(float time)
    {
        ElapsedTime = time; // Actualizar tiempo final
    }
}
