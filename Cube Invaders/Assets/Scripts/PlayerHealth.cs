using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Configuraci�n de Salud")]
    public int maxHealth = 100; // Salud m�xima del jugador
    private int currentHealth; // Salud actual
    private Image barraDeVida; // Referencia a la barra de vida

    [Header("Configuraci�n de Escena")]
    public string gameOverScene = "GameOver"; // Nombre de la escena de Game Over

    void Start()
    {
        currentHealth = maxHealth; // Inicia con salud m�xima

        // Encuentra la barra de vida din�micamente
        barraDeVida = GameObject.Find("barraDeVida")?.GetComponent<Image>();

        if (barraDeVida == null)
        {
            Debug.LogError("No se encontr� la barra de vida. Verifica que est� en la escena y tenga un componente Image.");
        }
        else
        {
            UpdateHealthBar();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Limita la salud entre 0 y m�xima
        Debug.Log($"Da�o recibido: {damage}, Salud restante: {currentHealth}");

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
