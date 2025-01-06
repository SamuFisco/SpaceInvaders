using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet; // Prefab del proyectil
    public GameObject SoundManager; // Objeto con el script de SoundManager
    private CharacterController playerController; // Componente CharacterController
    private Vector3 movement = Vector3.zero;

    void Start()
    {
        // Obtenemos el CharacterController del GameObject actual
        playerController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Movimiento horizontal del jugador
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        movement = transform.TransformDirection(movement);
        playerController.Move(movement * Time.deltaTime * 50);

        // Verificamos si se presiona la barra espaciadora para disparar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Llamamos al método de sonido desde el SoundManager
            if (SoundManager != null)
            {
                SoundManager.GetComponent<SoundManager>().PlaybulletSound();
            }
            else
            {
                Debug.LogError("SoundManager no está asignado.");
            }

            // Instanciamos y lanzamos el proyectil
            GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody>().AddForce(Vector3.up * 2000);
            Destroy(newBullet, 3); // Destruye el proyectil después de 3 segundos
        }
    }
}
