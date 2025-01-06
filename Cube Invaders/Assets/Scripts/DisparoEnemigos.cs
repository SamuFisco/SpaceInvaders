using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject enemyProjectile; // Prefab del proyectil
    public float shootInterval = 2f; // Intervalo entre disparos
    public Transform enemyGroup; // Referencia al grupo de enemigos
    public LayerMask enemyLayer; // Capa de los enemigos

    void Start()
    {
        StartCoroutine(ShootFromBottomRow());
    }

    IEnumerator ShootFromBottomRow()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootInterval);

            // Obtener enemigos en la fila inferior usando Raycast
            List<Transform> bottomRowEnemies = GetBottomRowEnemies();

            if (bottomRowEnemies.Count > 0)
            {
                // Elegir un enemigo aleatorio de la fila inferior
                Transform shootingEnemy = bottomRowEnemies[Random.Range(0, bottomRowEnemies.Count)];

                // Instanciar proyectil
                Instantiate(enemyProjectile, shootingEnemy.position, Quaternion.identity);
            }
        }
    }

    List<Transform> GetBottomRowEnemies()
    {
        List<Transform> bottomRowEnemies = new List<Transform>();

        foreach (Transform enemy in enemyGroup)
        {
            if (enemy.gameObject.activeSelf)
            {
                // Realizar Raycast hacia abajo desde la posición del enemigo
                RaycastHit hit;
                if (!Physics.Raycast(enemy.position, Vector3.down, out hit, Mathf.Infinity, enemyLayer))
                {
                    // Si no hay nada debajo, agregar a la lista de disparo
                    bottomRowEnemies.Add(enemy);
                }
            }
        }

        return bottomRowEnemies;
    }
}
