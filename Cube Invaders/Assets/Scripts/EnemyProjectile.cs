using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float lifetime = 5f; // Tiempo antes de que el proyectil se destruya
    public int damage = 10; // Da�o que causa el proyectil

    private bool hasHit = false; // Para evitar m�ltiples colisiones

    void Start()
    {
        // Destruir el proyectil despu�s del tiempo especificado si no colisiona
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (hasHit) return; // Evitar m�ltiples colisiones
        hasHit = true;

        if (other.CompareTag("Player")) // Detecta colisi�n con el jugador
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                Debug.Log($"Jugador impactado. Da�o infligido: {damage}");
            }

            Destroy(gameObject); // Destruir el proyectil tras impactar
        }
        else if (other.CompareTag("Shield")) // Colisi�n con escudos (opcional)
        {
            Destroy(gameObject); // El proyectil desaparece al chocar con un escudo
        }
    }
}
