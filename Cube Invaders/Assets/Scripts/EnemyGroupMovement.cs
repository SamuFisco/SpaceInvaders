using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroupMovement : MonoBehaviour
{
    public float moveSpeed = 1f; // Velocidad inicial de movimiento lateral
    public float moveDownDistance = 0.5f; // Distancia que bajan al cambiar de direcci�n
    public float speedIncrement = 0.5f; // Incremento de velocidad al destruir enemigos

    public float leftLimit = -12f; // L�mite izquierdo
    public float rightLimit = 13f; // L�mite derecho

    private Vector3 moveDirection = Vector3.right; // Direcci�n inicial
    private int enemiesDestroyed = 0; // Contador de enemigos destruidos

    void Update()
    {
        // Movimiento lateral
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // Verificar si se alcanzan los l�mites
        if (ReachedEdge())
        {
            ChangeDirection();
        }
    }

    // Detecta si el grupo alcanz� los l�mites definidos
    bool ReachedEdge()
    {
        foreach (Transform enemy in transform)
        {
            if (enemy.CompareTag("Enemy") && enemy.gameObject.activeSelf)
            {
                float enemyX = enemy.position.x;
                if (enemyX <= leftLimit || enemyX >= rightLimit)
                {
                    Debug.Log("Un enemigo alcanz� el borde.");
                    return true;
                }
            }
        }
        return false;
    }

    // Cambia la direcci�n de movimiento y baja al grupo
    void ChangeDirection()
    {
        moveDirection *= -1; // Invertir la direcci�n lateral
        transform.position += Vector3.down * moveDownDistance; // Mover hacia abajo
    }

    // M�todo llamado al destruir un enemigo
    public void OnEnemyDestroyed()
    {
        enemiesDestroyed++;
        Debug.Log($"Enemigos destruidos: {enemiesDestroyed}");

        // Aumenta la velocidad cada 2 enemigos destruidos
        if (enemiesDestroyed % 2 == 0)
        {
            moveSpeed += speedIncrement;
            Debug.Log($"Velocidad incrementada a: {moveSpeed}");
        }
    }
}
