using UnityEngine;

public class InstanciarNave : MonoBehaviour
{
    [Header("Prefabs de las Naves")]
    public GameObject nave1Prefab;
    public GameObject nave2Prefab;
    public GameObject nave3Prefab;

    [Header("Posición de Inicio")]
    public Vector3 spawnPosition;

    private void Start()
    {
        // Instancia la nave seleccionada
        switch (NaveSeleccionada.naveTag)
        {
            case "Nave1":
                Instantiate(nave1Prefab, spawnPosition, Quaternion.identity);
                break;
            case "Nave2":
                Instantiate(nave2Prefab, spawnPosition, Quaternion.identity);
                break;
            case "Nave3":
                Instantiate(nave3Prefab, spawnPosition, Quaternion.identity);
                break;
            default:
                Debug.LogError("Ninguna nave seleccionada.");
                break;
        }
    }
}
