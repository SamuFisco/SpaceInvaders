using UnityEngine;

public class EnemyPoweUp : MonoBehaviour
{
    [Header("Configuración del enemigo")]
    public GameObject powerUpPrefab; // Prefab del power-up
    public float powerUpChance = 0.2f; // Probabilidad de generar un power-up (20%)

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet")) // Verifica que fue impactado por una bala
        {
            Debug.Log("Enemigo impactado por bala.");

            // Generar el power-up con probabilidad
            if (Random.value <= powerUpChance)
            {
                Vector3 spawnPosition = transform.position + Vector3.up * 1f; // Eleva la posición inicial
                GameObject powerUp = Instantiate(powerUpPrefab, spawnPosition, Quaternion.identity);

                if (powerUp != null)
                {
                    Debug.Log($"Power-up generado: {powerUp.name} en posición {spawnPosition}");
                }
                else
                {
                    Debug.LogError("El prefab del power-up no se generó correctamente.");
                }
            }
            else
            {
                Debug.Log("No se generó un power-up. Probabilidad fallida.");
            }

            // Destruye el enemigo y la bala
            Destroy(gameObject); // Destruye al enemigo
            Destroy(other.gameObject); // Destruye la bala
        }
    }
}
