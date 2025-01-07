using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoEnemigos : MonoBehaviour
{
    public GameObject enemyProjectile; // Prefab del proyectil
    public float shootInterval = 3f; // Intervalo entre disparos
    public float projectileSpeed = 10f; // Velocidad del proyectil

    private bool isGameActive = true; // Controla si el juego está activo

    void Start()
    {
        // Comienza la lógica de disparo
        StartCoroutine(EnemyShootRoutine());
    }

    IEnumerator EnemyShootRoutine()
    {
        while (isGameActive)
        {
            // Espera un intervalo antes de disparar
            yield return new WaitForSeconds(shootInterval);

            // Obtén la fila activa más baja (cercana al jugador)
            List<Transform> activeRow = GetLowestActiveRow();

            if (activeRow.Count > 0)
            {
                // Selecciona un enemigo aleatorio de la fila más baja
                Transform randomEnemy = activeRow[Random.Range(0, activeRow.Count)];

                // Instancia el proyectil en la posición del enemigo
                GameObject projectile = Instantiate(enemyProjectile, randomEnemy.position, Quaternion.identity);

                // Asigna la dirección del proyectil hacia abajo
                Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
                if (projectileRb != null)
                {
                    projectileRb.velocity = Vector3.down * projectileSpeed;
                }

                Debug.Log($"Enemigo disparando desde fila {randomEnemy.GetComponent<Enemy>().fila}");
            }
        }
    }

    List<Transform> GetLowestActiveRow()
    {
        int lowestRow = -1; // Inicializamos con un valor bajo (más cerca del jugador)
        List<Transform> activeRow = new List<Transform>();

        foreach (Transform enemy in transform)
        {
            Enemy enemyScript = enemy.GetComponent<Enemy>();

            if (enemyScript != null && enemy.gameObject.activeSelf)
            {
                // Si encontramos enemigos activos en una fila más baja (cercana al jugador), actualizamos
                if (enemyScript.fila > lowestRow)
                {
                    lowestRow = enemyScript.fila;
                    activeRow.Clear(); // Reiniciamos la lista para incluir solo la nueva fila más baja
                }

                if (enemyScript.fila == lowestRow)
                {
                    activeRow.Add(enemy); // Agregamos el enemigo a la fila activa
                }
            }
        }

        return activeRow;
    }

    // Método para desactivar la lógica de disparo (por ejemplo, en Game Over)
    public void StopShooting()
    {
        isGameActive = false;
    }
}
