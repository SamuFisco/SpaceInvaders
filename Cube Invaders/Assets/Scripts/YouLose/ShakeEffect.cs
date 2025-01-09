using UnityEngine;

public class ShakeEffect : MonoBehaviour
{
    public float intensity = 10f; // Intensidad del temblor
    public float duration = 0.5f; // Duración total del temblor
    public GameObject fallingText; // El objeto de texto que caerá
    public float dropDelay = 1f; // Tiempo de espera antes de que caiga el texto

    private Vector3 originalPosition;
    private RectTransform textRectTransform;

    void Start()
    {
        // Almacena la posición inicial del objeto
        originalPosition = transform.localPosition;

        // Inicia el efecto de temblor automáticamente al iniciar la escena
        StartShake();

        // Configura el RectTransform del texto
        if (fallingText != null)
        {
            textRectTransform = fallingText.GetComponent<RectTransform>();
            if (textRectTransform == null)
            {
                Debug.LogError("El texto asignado no tiene un RectTransform.");
                return;
            }

            // Programa la caída del texto
            Invoke(nameof(DropText), dropDelay);
        }
        else
        {
            Debug.LogWarning("FallingText no asignado en el inspector.");
        }
    }

    public void StartShake()
    {
        // Inicia el efecto de temblor
        LeanTween.value(gameObject, 0, 1, duration)
            .setOnUpdate((float val) => {
                Vector3 shakeOffset = new Vector3(
                    Random.Range(-intensity, intensity),
                    Random.Range(-intensity, intensity),
                    0f // Solo en 2D, Z permanece igual
                );
                transform.localPosition = originalPosition + shakeOffset;
            })
            .setOnComplete(() => {
                // Restaura la posición original
                transform.localPosition = originalPosition;
            });
    }

    public void DropText()
    {
        if (textRectTransform != null)
        {
            // Mueve el texto al centro de la pantalla
            LeanTween.move(textRectTransform, Vector3.zero, 1f).setEase(LeanTweenType.easeInOutQuad);
        }
    }
}
