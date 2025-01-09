using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Configuración de Salud")]
    public int maxHealth = 100; // Salud máxima del jugador
    private int currentHealth; // Salud actual
    private Image barraDeVida; // Referencia a la barra de vida

    [Header("Configuración de Escena")]
    public string gameOverScene = "GameOver"; // Nombre de la escena de Game Over

    void Start()
    {
        currentHealth = maxHealth; // Inicia con salud máxima

        // Encuentra la barra de vida dinámicamente
        barraDeVida = GameObject.Find("barraDeVida")?.GetComponent<Image>();

        if (barraDeVida == null)
        {
            Debug.LogError("No se encontró la barra de vida. Verifica que esté en la escena y tenga un componente Image.");
        }
        else
        {
            UpdateHealthBar();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Limita la salud entre 0 y máxima
        Debug.Log($"Daño recibido: {damage}, Salud restante: {currentHealth}");

        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void UpdateHealthBar()
    {
        if (barraDeVida != null)
        {
            barraDeVida.fillAmount = (float)currentHealth / maxHealth;
        }
    }

    private void Die()
    {
        Debug.Log("El jugador ha muerto. Cargando escena de Game Over...");
        SceneManager.LoadScene(gameOverScene);
    }
}
