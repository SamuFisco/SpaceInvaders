using UnityEngine;
using UnityEngine.SceneManagement;

public class ProjectileMover : MonoBehaviour
{
    private Vector2 movementVelocity; // Renombrado para evitar ambigüedad

    public void Initialize(Vector2 initialVelocity)
    {
        movementVelocity = initialVelocity;
    }

    private void Update()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            rectTransform.anchoredPosition += movementVelocity * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el proyectil colisiona con alguna de las naves
        if (other.CompareTag("Nave1") || other.CompareTag("Nave2") || other.CompareTag("Nave3"))
        {
            // Guarda el tag de la nave seleccionada
            NaveSeleccionada.naveTag = other.tag;

            // Cambia a la escena "Invaders"
            SceneManager.LoadScene("Invaders");

            // Destruye el proyectil tras la colisión
            Destroy(gameObject);
        }
    }
}
