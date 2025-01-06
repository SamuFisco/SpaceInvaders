using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCollision : MonoBehaviour
{
    public GameObject gameBrain, explosion, soundManager;

    // Start is called before the first frame update
    void Start()
    {
       // gameBrain = GameObject.Find("GameBrain");
      //  soundManager = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void OnTriggerEnter (Collider colObj)
    {
        if (colObj.gameObject.tag == "Bullet")
        {
            soundManager.SendMessage("PlayExplosionSound");
            gameBrain.SendMessage("EnemyDownCounter");
            GameObject newExplosion=Instantiate (explosion,transform.position,Quaternion.identity);
            Destroy (newExplosion,2);
            Destroy(gameObject);
            Destroy(colObj.gameObject);
        }
        if (colObj.gameObject.name == "Player")
        {
            Destroy (colObj.gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }
}
