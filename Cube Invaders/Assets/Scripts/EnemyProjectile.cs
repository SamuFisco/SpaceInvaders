using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public int damage = 10; // Da�o que inflige el proyectil

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage); // Inflige da�o al jugador
            }
            Destroy(gameObject); // Destruye el proyectil
        }
        else if (other.CompareTag("Shield"))
        {
            Destroy(gameObject); // Destruye el proyectil si choca con un escudo
        }
    }
}
