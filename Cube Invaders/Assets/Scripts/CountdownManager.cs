using System.Collections;
using UnityEngine;
using TMPro;

public class CountdownManager : MonoBehaviour
{
    public TextMeshProUGUI countdownText; // Referencia al objeto de texto en la UI
    public GameObject gameplayElements; // Elementos del juego que se activarán después del contador
    public float delayBetweenNumbers = 1f; // Tiempo entre cada número

    private void Start()
    {
        // Asegúrate de que el texto del contador esté visible
        countdownText.gameObject.SetActive(true);

        // Desactiva los elementos del juego al inicio
        if (gameplayElements != null)
        {
            gameplayElements.SetActive(false);
        }

        // Inicia la corrutina para el conteo regresivo
        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {
        // Cuenta regresiva del 3 al 1
        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(delayBetweenNumbers);
        }

        // Muestra "Ready"
        countdownText.text = "Ready!";
        yield return new WaitForSeconds(delayBetweenNumbers);

        // Oculta el texto del contador
        countdownText.gameObject.SetActive(false);

        // Activa los elementos del juego
        if (gameplayElements != null)
        {
            gameplayElements.SetActive(true);
        }
    }
}
