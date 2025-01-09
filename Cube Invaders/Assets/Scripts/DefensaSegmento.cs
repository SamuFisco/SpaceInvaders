using UnityEngine;

public class DefensaSegmento : MonoBehaviour
{
    [Header("Configuraci�n de la Defensa")]
    public int saludMaxima = 1; // Salud m�xima del segmento
    public Material[] estadosVisuales; // Array de materiales para representar los estados de da�o

    private int saludActual;
    private Renderer rendererDefensa;

    void Start()
    {
        saludActual = saludMaxima; // Inicializamos la salud al m�ximo
        rendererDefensa = GetComponent<Renderer>();

        if (rendererDefensa != null && estadosVisuales.Length > 0)
        {
            ActualizarApariencia();
        }
        else
        {
            Debug.LogWarning("Faltan materiales para los estados visuales o el Renderer no est� asignado.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Detectar colisi�n con el proyectil enemigo
        if (other.CompareTag("ProyectilEnemigo"))
        {
            RecibirDa�o(1);
            Destroy(other.gameObject); // Destruir el proyectil tras la colisi�n
        }
    }

    void RecibirDa�o(int da�o)
    {
        saludActual -= da�o;

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
