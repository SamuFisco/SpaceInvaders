using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoEnemigos : MonoBehaviour
{
    public GameObject enemyProjectile; // Prefab del proyectil
    public float shootInterval = 3f; // Intervalo entre disparos
    public float projectileSpeed = 10f; // Velocidad del proyectil

    private bool isGameActive = true; // Controla si el juego est� activo

    void Start()
    {
        // Comienza la l�gica de disparo
        StartCoroutine(EnemyShootRoutine());
    }

    IEnumerator EnemyShootRoutine()
    {
        while (isGameActive)
        {
            // Espera un intervalo antes de disparar
            yield return new WaitForSeconds(shootInterval);

            // Obt�n la fila activa m�s baja (cercana al jugador)
            List<Transform> activeRow = GetLowestActiveRow();

            if (activeRow.Count > 0)
            {
                // Selecciona un enemigo aleatorio de la fila m�s baja
                Transform randomEnemy = activeRow[Random.Range(0, activeRow.Count)];

                // Instancia el proyectil en la posici�n del enemigo
                GameObject projectile = Instantiate(enemyProjectile, randomEnemy.position, Quaternion.identity);

                // Asigna la direcci�n del proyectil hacia abajo
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
        int lowestRow = -1; // Inicializamos con un valor bajo (m�s cerca del jugador)
        List<Transform> activeRow = new List<Transform>();

        foreach (Transform enemy in transform)
        {
            Enemy enemyScript = enemy.GetComponent<Enemy>();

            if (enemyScript != null && enemy.gameObject.activeSelf)
            {
                // Si encontramos enemigos activos en una fila m�s baja (cercana al jugador), actualizamos
                if (enemyScript.fila > lowestRow)
                {
                    lowestRow = enemyScript.fila;
                    activeRow.Clear(); // Reiniciamos la lista para incluir solo la nueva fila m�s baja
                }

                if (enemyScript.fila == lowestRow)
                {
                    activeRow.Add(enemy); // Agregamos el enemigo a la fila activa
                }
            }
        }

        return activeRow;
    }

    // M�todo para desactivar la l�gica de disparo (por ejemplo, en Game Over)
    public void StopShooting()
    {
        isGameActive = false;
    }
}
