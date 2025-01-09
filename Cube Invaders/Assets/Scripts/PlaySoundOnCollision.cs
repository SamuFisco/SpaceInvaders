using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // Obt�n el AudioSource del objeto
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogWarning("No se encontr� un AudioSource en el GameObject.");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Comprueba si el objeto colisionado tiene la etiqueta "Base"
        if (collision.gameObject.CompareTag("Base"))
        {
            Debug.Log("base");

            // Reproduce el audio
            if (audioSource != null)
            {
                audioSource.Play();
                Debug.Log("Sonido reproducido.");
            }
        }
    }
}
