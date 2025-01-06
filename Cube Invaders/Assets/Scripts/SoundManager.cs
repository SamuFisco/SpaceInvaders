using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip explosionSound; // Clip de sonido para explosiones
    public AudioClip bulletSound; // Clip de sonido para disparos

    // Reproduce el sonido de explosión
    public void PlayExplosionSound()
    {
        if (explosionSound != null)
        {
            GetComponent<AudioSource>().PlayOneShot(explosionSound);
        }
        else
        {
            Debug.LogError("No se ha asignado un clip de sonido para explosiones.");
        }
    }

    // Reproduce el sonido del disparo
    public void PlaybulletSound()
    {
        if (bulletSound != null)
        {
            GetComponent<AudioSource>().PlayOneShot(bulletSound);
        }
        else
        {
            Debug.LogError("No se ha asignado un clip de sonido para disparos.");
        }
    }
}
