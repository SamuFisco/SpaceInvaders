using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    public Image barraDeVida;

    public float vidaActual;
    public float vidaMaxima;

    void Update()
    {
        barraDeVida.fillAmount = vidaActual / vidaMaxima;
    }
    void Start()
    {
        if (barraDeVida == null)
        {
            barraDeVida = GetComponent<Image>();
            if (barraDeVida == null)
            {
                Debug.LogError("No se encontró el componente Image en el GameObject actual.");
            }
        }
    }

}
