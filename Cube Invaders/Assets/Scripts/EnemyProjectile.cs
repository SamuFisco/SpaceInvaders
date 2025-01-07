using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float lifetime = 5f; // Tiempo antes de que el proyectil se destruya
    public int damage = 10; // Daño que causa el proyectil

    private bool hasHit = false; // Para evitar múltiples colisiones

    void Start()
    {
        // Destruir el proyectil después del tiempo especificado si no colisiona
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (hasHit) return; // Evitar múltiples colisiones
        hasHit = true;

        if (other.CompareTag("Player")) // Detecta colisión con el jugador
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                Debug.Log($"Jugador impactado. Daño infligido: {damage}");
            }

            Destroy(gameObject); // Destruir el proyectil tras impactar
        }
        else if (other.CompareTag("Shield")) // Colisión con escudos (opcional)
        {
            Destroy(gameObject); // El proyectil desaparece al chocar con un escudo
        }
    }
}
