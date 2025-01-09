using UnityEngine;
using UnityEngine.UI;

public class AnimarYouLose : MonoBehaviour
{
    [Header("Configuraci�n del Texto")]
    public RectTransform textoYouLose; // Texto a animar
    public Vector3 posicionInicial = new Vector3(-5, 387, 0); // Posici�n inicial
    public Vector3 posicionFinal = new Vector3(-5, -32, 0); // Posici�n final
    public float duracion = 1.5f; // Duraci�n de la animaci�n

    private bool estaAnimando = false;

    void Start()
    {
        // Configurar la posici�n inicial
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
        // Prevenir m�ltiples animaciones simult�neas
        if (estaAnimando || textoYouLose == null) return;

        estaAnimando = true;

        // Animar desde la posici�n inicial a la posici�n final con un efecto suave
        LeanTween.moveLocal(textoYouLose.gameObject, posicionFinal, duracion)
            .setEase(LeanTweenType.easeOutElastic) // Efecto din�mico al final
            .setOnComplete(() => estaAnimando = false); // Permitir nuevas animaciones
    }
}
