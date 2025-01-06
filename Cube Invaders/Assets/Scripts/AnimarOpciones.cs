using UnityEngine;

public class AnimarOpcionesAlClick : MonoBehaviour
{
    [Header("Configuraci�n")]
    public RectTransform imagenOpciones; // Imagen a animar
    public Vector3 posicionInicial = new Vector3(6, 805, 0); // Posici�n inicial
    public Vector3 posicionFinal = new Vector3(6, 80, 0); // Posici�n final
    public float duracion = 1.5f; // Duraci�n de la animaci�n

    private bool estaAnimando = false;

    void Start()
    {
        // Establecer la posici�n inicial al inicio
        if (imagenOpciones != null)
        {
            imagenOpciones.localPosition = posicionInicial;
        }
        else
        {
            Debug.LogError("No se ha asignado la imagen a animar.");
        }
    }

    public void AnimarOpciones()
    {
        // Prevenir m�ltiples animaciones simult�neas
        if (estaAnimando || imagenOpciones == null) return;

        estaAnimando = true;

        // Animar hacia la posici�n final
        LeanTween.moveLocal(imagenOpciones.gameObject, posicionFinal, duracion)
            .setEase(LeanTweenType.easeInOutQuad)
            .setOnComplete(() =>
            {
                estaAnimando = false; // Permitir otra animaci�n tras completar
            });
    }

    public void RegresarOpciones()
    {
        // Prevenir m�ltiples animaciones simult�neas
        if (estaAnimando || imagenOpciones == null) return;

        estaAnimando = true;

        // Animar hacia la posici�n inicial
        LeanTween.moveLocal(imagenOpciones.gameObject, posicionInicial, duracion)
            .setEase(LeanTweenType.easeInOutQuad)
            .setOnComplete(() =>
            {
                estaAnimando = false; // Permitir otra animaci�n tras completar
            });
    }
}
