using UnityEngine;
using UnityEngine.UI;

public class Brillo : MonoBehaviour
{
    public Slider slider; // Referencia al slider de brillo
    public float sliderValue; // Valor actual del slider
    public Image panelBrillo; // Panel para ajustar el brillo

    void Start()
    {
        // Inicializa el valor del slider con el valor guardado en PlayerPrefs
        sliderValue = PlayerPrefs.GetFloat("brillo", 0.5f);
        slider.value = sliderValue;

        // Actualiza el color del panel con el valor del slider
        UpdateBrillo(sliderValue);
    }

    public void ChangeSlider(float valor)
    {
        // Actualiza el valor del slider y guarda el valor en PlayerPrefs
        sliderValue = valor;
        PlayerPrefs.SetFloat("brillo", sliderValue);

        // Actualiza el color del panel con el valor del slider
        UpdateBrillo(sliderValue);
    }

    private void UpdateBrillo(float valor)
    {
        // Cambia la transparencia del panel con el valor del slider
        if (panelBrillo != null)
        {
            panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, valor);
        }
        else
        {
            Debug.Log("PanelBrillo no asignado en el Inspector.");
        }
    }
}
