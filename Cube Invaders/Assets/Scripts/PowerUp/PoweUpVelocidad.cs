using UnityEngine;

public class PowerUpVelocidad : MonoBehaviour
{
    public GameObject gameplayElements; // Objeto GameplayElements
    public float speedBoost = 2f; // Factor de aumento de velocidad
    public float duration = 5f; // Duración del efecto

    void Start()
    {
        // Si GameplayElements no está asignado, lo busca por nombre en la jerarquía
        if (gameplayElements == null)
        {
            gameplayElements = GameObject.Find("GameplayElements");
            if (gameplayElements == null)
            {
                Debug.LogError("GameplayElements no encontrado. Asegúrate de que existe en la jerarquía.");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Verifica si GameplayElements está activo
        if (gameplayElements != null && gameplayElements.activeSelf)
        {
            if (other.CompareTag("Player")) // Verifica si el objeto es el jugador
            {
                PlayerSpeed playerSpeed = other.GetComponent<PlayerSpeed>();
                if (playerSpeed != null)
                {
                    playerSpeed.ApplySpeedBoost(speedBoost, duration);
                }

                Destroy(gameObject); // Destruye el power-up tras recogerlo
            }
        }
    }
}
