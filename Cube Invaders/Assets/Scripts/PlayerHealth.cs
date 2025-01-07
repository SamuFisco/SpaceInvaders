using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Salud máxima del jugador
    private int currentHealth; // Salud actual

    void Start()
    {
        currentHealth = maxHealth; // Inicializa la salud al máximo
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Resta el daño recibido
        Debug.Log($"Salud del jugador: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die(); // Llama a la función para manejar la muerte del jugador
        }
    }

    private void Die()
    {
        Debug.Log("El jugador ha muerto.");
        // Aquí puedes manejar la lógica de Game Over o reinicio del nivel
    }
}
