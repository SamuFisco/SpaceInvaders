using UnityEngine;

public class ProyectilEnemigo3D : MonoBehaviour
{
    [Header("Configuraci�n del proyectil")]
    public float velocidad = 10f; // Velocidad del proyectil

    void Update()
    {
        // Mueve el proyectil hacia abajo en el espacio 3D
        transform.Translate(Vector3.down * velocidad * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider colision)
    {
        if (colision.CompareTag("Jugador"))
        {
            // L�gica para da�ar al jugador
            Debug.Log("El jugador ha sido alcanzado.");
            Destroy(gameObject);
        }
        else if (colision.CompareTag("Bunker"))
        {
            // L�gica para da�ar o destruir el b�nker
            Debug.Log("El b�nker ha sido alcanzado.");
            Destroy(gameObject);
        }
        else if (colision.CompareTag("Limite"))
        {
            // Destruye el proyectil si alcanza el l�mite de la pantalla
            Destroy(gameObject);
        }
    }
}
