using UnityEngine;

public class DebugPrefabFall : MonoBehaviour
{
    public GameObject powerUpPrefab; // Arrastra tu prefab aquí

    void Start()
    {
        if (powerUpPrefab != null)
        {
            Vector3 spawnPosition = new Vector3(0, 5, 0); // Ajusta la posición inicial
            GameObject powerUp = Instantiate(powerUpPrefab, spawnPosition, Quaternion.identity);
            Debug.Log($"Power-up instanciado en: {spawnPosition}");
        }
        else
        {
            Debug.LogError("No se asignó el prefab del power-up.");
        }
    }
}
