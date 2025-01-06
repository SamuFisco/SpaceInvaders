using UnityEngine;

public class TitleAnimation : MonoBehaviour
{
    [Header("Configuraci�n de Animaci�n")]
    public Vector3 finalPosition = new Vector3(12f, 323f, 0f); // Posici�n final
    public Vector3 finalScale = new Vector3(11f, 7f, 0f); // Escala final
    public float animationTime = 1f; // Duraci�n de la animaci�n

    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        // Configurar la posici�n inicial (fuera de la pantalla, por encima del t�tulo)
        rectTransform.localPosition = new Vector3(finalPosition.x, 800f, finalPosition.z); // Ajusta seg�n el dise�o

        // Configurar la escala inicial (peque�a)
        rectTransform.localScale = Vector3.zero;

        // Animar el movimiento y el zoom
        LeanTween.moveLocal(gameObject, finalPosition, animationTime).setEaseOutBounce(); // Movimiento con efecto rebote
        LeanTween.scale(gameObject, finalScale, animationTime).setEaseOutBack(); // Zoom con efecto suave
    }
}
