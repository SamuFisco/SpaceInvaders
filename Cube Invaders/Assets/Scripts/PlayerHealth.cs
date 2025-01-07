using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Salud m�xima del jugador
    private int currentHealth; // Salud actual

    void Start()
    {
        currentHealth = maxHealth; // Inicializa la salud al m�ximo
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Resta el da�o recibido
        Debug.Log($"Salud del jugador: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die(); // Llama a la funci�n para manejar la muerte del jugador
        }
    }

    private void Die()
    {
        Debug.Log("El jugador ha muerto.");
        // Aqu� puedes manejar la l�gica de Game Over o reinicio del nivel
    }
}
