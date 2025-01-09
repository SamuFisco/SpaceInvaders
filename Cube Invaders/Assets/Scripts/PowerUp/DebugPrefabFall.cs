using UnityEngine;

public class DebugPrefabFall : MonoBehaviour
{
    public GameObject powerUpPrefab; // Arrastra tu prefab aqu�

    void Start()
    {
        if (powerUpPrefab != null)
        {
            Vector3 spawnPosition = new Vector3(0, 5, 0); // Ajusta la posici�n inicial
            GameObject powerUp = Instantiate(powerUpPrefab, spawnPosition, Quaternion.identity);
            Debug.Log($"Power-up instanciado en: {spawnPosition}");
        }
        else
        {
            Debug.LogError("No se asign� el prefab del power-up.");
        }
    }
}
