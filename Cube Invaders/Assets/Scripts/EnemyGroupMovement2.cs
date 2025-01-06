using System.Collections;
using UnityEngine;

public class EnemyGroupMovement2 : MonoBehaviour
{
    public Transform[] enemyRows; // Referencias a las filas de enemigos
    public float moveSpeed = 1f; // Velocidad de movimiento lateral
    public float moveDownDistance = 0.5f; // Distancia que los enemigos bajan al cambiar de direcci�n
    public float waitTime = 0.5f; // Tiempo entre cada movimiento
    public float speedIncrement = 0.2f; // Incremento de velocidad al destruir enemigos
    private Vector3 moveDirection = Vector3.right; // Direcci�n inicial de movimiento
    private bool moveDownNext = false; // Si deben bajar al siguiente movimiento
    private int enemiesDestroyed = 0; // Contador de enemigos destruidos

    private void Start()
    {
        StartCoroutine(MoveEnemies());
    }

    private IEnumerator MoveEnemies()
    {
        while (true)
        {
            if (moveDownNext)
            {
                // Baja a los enemigos
                transform.position += Vector3.down * moveDownDistance;
                moveDownNext = false; // Resetear el estado
            }
            else
            {
                // Mueve lateralmente
                transform.position += moveDirection * moveSpeed * Time.deltaTime;

                // Verifica si un enemigo alcanz� el l�mite
                if (ReachedEdge())
                {
                    moveDirection *= -1; // Cambia de direcci�n
                    moveDownNext = true; // Indica que deben bajar
                }
            }

            yield return new WaitForSeconds(waitTime); // Pausa entre movimientos
        }
    }

    private bool ReachedEdge()
    {
        foreach (Transform row in enemyRows)
        {
            foreach (Transform enemy in row)
            {
                if (enemy.gameObject.activeSelf)
                {
                    // Convertir posici�n del enemigo a coordenadas de la c�mara
                    Vector3 screenPosition = Camera.main.WorldToViewportPoint(enemy.position);

                    // Si est� fuera de los l�mites, retorna true
                    if (screenPosition.x <= 0 || screenPosition.x >= 1)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public void OnEnemyDestroyed()
    {
        enemiesDestroyed++;

        // Incrementa la velocidad cada 2 enemigos destruidos
        if (enemiesDestroyed % 2 == 0)
        {
            moveSpeed += speedIncrement;
            Debug.Log($"Velocidad incrementada: {moveSpeed}");
        }
    }
}
