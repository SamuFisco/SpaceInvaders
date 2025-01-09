using UnityEngine;
using UnityEngine.UI;

public class AnimarYouLose : MonoBehaviour
{
    [Header("Configuración del Texto")]
    public RectTransform textoYouLose; // Texto a animar
    public Vector3 posicionInicial = new Vector3(-5, 387, 0); // Posición inicial
    public Vector3 posicionFinal = new Vector3(-5, -32, 0); // Posición final
    public float duracion = 1.5f; // Duración de la animación

    private bool estaAnimando = false;

    void Start()
    {
        // Configurar la posición inicial
        if (textoYouLose != null)
        {
            textoYouLose.localPosition = posicionInicial;
        }
        else
        {
            Debug.LogError("No se ha asignado el texto para animar.");
        }
    }

    public void AnimarTexto()
    {
        // Prevenir múltiples animaciones simultáneas
        if (estaAnimando || textoYouLose == null) return;

        estaAnimando = true;

        // Animar desde la posición inicial a la posición final con un efecto suave
        LeanTween.moveLocal(textoYouLose.gameObject, posicionFinal, duracion)
            .setEase(LeanTweenType.easeOutElastic) // Efecto dinámico al final
            .setOnComplete(() => estaAnimando = false); // Permitir nuevas animaciones
    }
}
