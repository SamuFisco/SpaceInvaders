using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCounter : MonoBehaviour
{
    public int enemyCount; // Contador de enemigos eliminados

    public void EnemyDownCounter()
    {
        enemyCount++;
        if (enemyCount == 24)
        {
            // Inicia la corrutina para cargar la escena después de 2 segundos
            StartCoroutine(LoadWinSceneAfterDelay(2f));
        }
    }

    private IEnumerator LoadWinSceneAfterDelay(float delay)
    {
        // Espera la cantidad de segundos especificados
        yield return new WaitForSeconds(delay);

        // Carga la escena de victoria
        SceneManager.LoadScene("Win");
    }
}
