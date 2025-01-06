using UnityEngine;

public class AnimarOpcionesAlClick : MonoBehaviour
{
    [Header("Configuración")]
    public RectTransform imagenOpciones; // Imagen a animar
    public Vector3 posicionInicial = new Vector3(6, 805, 0); // Posición inicial
    public Vector3 posicionFinal = new Vector3(6, 80, 0); // Posición final
    public float duracion = 1.5f; // Duración de la animación

    private bool estaAnimando = false;

    void Start()
    {
        // Establecer la posición inicial al inicio
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
        // Prevenir múltiples animaciones simultáneas
        if (estaAnimando || imagenOpciones == null) return;

        estaAnimando = true;

        // Animar hacia la posición final
        LeanTween.moveLocal(imagenOpciones.gameObject, posicionFinal, duracion)
            .setEase(LeanTweenType.easeInOutQuad)
            .setOnComplete(() =>
            {
                estaAnimando = false; // Permitir otra animación tras completar
            });
    }

    public void RegresarOpciones()
    {
        // Prevenir múltiples animaciones simultáneas
        if (estaAnimando || imagenOpciones == null) return;

        estaAnimando = true;

        // Animar hacia la posición inicial
        LeanTween.moveLocal(imagenOpciones.gameObject, posicionInicial, duracion)
            .setEase(LeanTweenType.easeInOutQuad)
            .setOnComplete(() =>
            {
                estaAnimando = false; // Permitir otra animación tras completar
            });
    }
}
