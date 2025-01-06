using UnityEngine;

public class Win : MonoBehaviour
{
    [Header("Configuraci�n")]
    public RectTransform imagen; // Imagen a animar
    public Vector3 posicionInicial = new Vector3(127, 608, 0); // Posici�n inicial
    public Vector3 posicionFinal = new Vector3(127, 188, 0); // Posici�n final
    public float duracion = 1.5f; // Duraci�n de la animaci�n

    void Start()
    {
        // Establece la posici�n inicial de la imagen
        if (imagen != null)
        {
            imagen.localPosition = posicionInicial;

            // Realiza la animaci�n de la imagen
            LeanTween.moveLocal(imagen.gameObject, posicionFinal, duracion)
                .setEase(LeanTweenType.easeInOutQuad);
        }
        else
        {
            Debug.LogError("No se ha asignado la imagen a animar.");
        }
    }
}
