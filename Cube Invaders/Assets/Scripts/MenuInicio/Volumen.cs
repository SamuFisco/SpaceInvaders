using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Volumen : MonoBehaviour
    

{
    public Slider slider;
    public float sliderValue;
    public Image imagenMute;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slider.value;
        RevisarSiEstoyMute();
    }

    // Update is called once per frame
    public void ChageSilider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume=slider.value;
        RevisarSiEstoyMute();

    }
    public void RevisarSiEstoyMute()
    {
        if (sliderValue == 0)
        {
            imagenMute.enabled = true;
        }
        else
        {
            imagenMute.enabled = false;
        }
     
    }
}
