using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    public float speed = 150f; // Velocidad de movimiento de la nave.

    [Header("Configuración de Disparo")]
    public GameObject projectilePrefab; // Prefab del proyectil.
    public RectTransform shootPoint; // Punto desde donde se disparará el proyectil.
    public RectTransform playerRectTransform; // RectTransform de la nave.

    private void Update()
    {
        HandleMovement();
        HandleShooting();

        // Debug para verificar la posición del Shoot Point
        Debug.Log($"Shoot Point posición final: {shootPoint.position}");
    }

    private void HandleMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput, 0) * speed * Time.deltaTime;

        playerRectTransform.anchoredPosition += movement;

        float halfWidth = playerRectTransform.rect.width / 2;
        float clampedX = Mathf.Clamp(
            playerRectTransform.anchoredPosition.x,
            -Screen.width / 2 + halfWidth,
            Screen.width / 2 - halfWidth
        );

        playerRectTransform.anchoredPosition = new Vector2(clampedX, playerRectTransform.anchoredPosition.y);
    }

    private void HandleShooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootProjectile();
        }
    }

    private void ShootProjectile()
    {
        if (projectilePrefab != null && shootPoint != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity, shootPoint.parent);

            RectTransform projectileRect = projectile.GetComponent<RectTransform>();
            if (projectileRect != null)
            {
                // Ajustar la posición inicial del proyectil
                projectileRect.anchoredPosition = shootPoint.anchoredPosition + new Vector2(0, 30f); // Ajuste vertical

                // Agregar movimiento hacia arriba.
                projectile.AddComponent<ProjectileMover>().Initialize(Vector2.up * 500f);
            }
        }
        else
        {
            Debug.LogError("Prefab del proyectil o punto de disparo no asignado.");
        }
    }
}


