using UnityEngine;

public class ProyectilEnemigo3D : MonoBehaviour
{
    [Header("Configuración del proyectil")]
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
            // Lógica para dañar al jugador
            Debug.Log("El jugador ha sido alcanzado.");
            Destroy(gameObject);
        }
        else if (colision.CompareTag("Bunker"))
        {
            // Lógica para dañar o destruir el búnker
            Debug.Log("El búnker ha sido alcanzado.");
            Destroy(gameObject);
        }
        else if (colision.CompareTag("Limite"))
        {
            // Destruye el proyectil si alcanza el límite de la pantalla
            Destroy(gameObject);
        }
    }
}
