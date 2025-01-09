using UnityEngine;

public class DefensaSegmento : MonoBehaviour
{
    [Header("Configuración de la Defensa")]
    public int saludMaxima = 1; // Salud máxima del segmento
    public Material[] estadosVisuales; // Array de materiales para representar los estados de daño

    private int saludActual;
    private Renderer rendererDefensa;

    void Start()
    {
        saludActual = saludMaxima; // Inicializamos la salud al máximo
        rendererDefensa = GetComponent<Renderer>();

        if (rendererDefensa != null && estadosVisuales.Length > 0)
        {
            ActualizarApariencia();
        }
        else
        {
            Debug.LogWarning("Faltan materiales para los estados visuales o el Renderer no está asignado.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Detectar colisión con el proyectil enemigo
        if (other.CompareTag("ProyectilEnemigo"))
        {
            RecibirDaño(1);
            Destroy(other.gameObject); // Destruir el proyectil tras la colisión
        }
    }

    void RecibirDaño(int daño)
    {
        saludActual -= daño;

        if (saludActual <= 0)
        {
            DestruirSegmento();
        }
        else
        {
            ActualizarApariencia();
        }
    }

    void ActualizarApariencia()
    {
        // Cambiar el material basado en la salud actual
        int indiceMaterial = Mathf.Clamp(saludMaxima - saludActual, 0, estadosVisuales.Length - 1);
        rendererDefensa.material = estadosVisuales[indiceMaterial];
    }

    void DestruirSegmento()
    {
        // Destruye este segmento de defensa
        Destroy(gameObject);
    }
}
