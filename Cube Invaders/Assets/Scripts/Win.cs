using UnityEngine;

public class Win : MonoBehaviour
{
    [Header("Configuración")]
    public RectTransform imagen; // Imagen a animar
    public Vector3 posicionInicial = new Vector3(127, 608, 0); // Posición inicial
    public Vector3 posicionFinal = new Vector3(127, 188, 0); // Posición final
    public float duracion = 1.5f; // Duración de la animación

    void Start()
    {
        // Establece la posición inicial de la imagen
        if (imagen != null)
        {
            imagen.localPosition = posicionInicial;

            // Realiza la animación de la imagen
            LeanTween.moveLocal(imagen.gameObject, posicionFinal, duracion)
                .setEase(LeanTweenType.easeInOutQuad);
        }
        else
        {
            Debug.LogError("No se ha asignado la imagen a animar.");
        }
    }
}
