using UnityEngine;

public class TitleAnimation : MonoBehaviour
{
    [Header("Configuración de Animación")]
    public Vector3 finalPosition = new Vector3(12f, 323f, 0f); // Posición final
    public Vector3 finalScale = new Vector3(11f, 7f, 0f); // Escala final
    public float animationTime = 1f; // Duración de la animación

    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        // Configurar la posición inicial (fuera de la pantalla, por encima del título)
        rectTransform.localPosition = new Vector3(finalPosition.x, 800f, finalPosition.z); // Ajusta según el diseño

        // Configurar la escala inicial (pequeña)
        rectTransform.localScale = Vector3.zero;

        // Animar el movimiento y el zoom
        LeanTween.moveLocal(gameObject, finalPosition, animationTime).setEaseOutBounce(); // Movimiento con efecto rebote
        LeanTween.scale(gameObject, finalScale, animationTime).setEaseOutBack(); // Zoom con efecto suave
    }
}
