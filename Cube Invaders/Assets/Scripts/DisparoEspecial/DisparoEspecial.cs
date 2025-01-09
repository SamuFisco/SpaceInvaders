using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoEspecial : MonoBehaviour
{
    public GameObject bullet; // Prefab del proyectil
    public GameObject SoundManager; // Objeto con el script de SoundManager
    private CharacterController playerController; // Componente CharacterController
    private Vector3 movement = Vector3.zero;

    public float fireCooldown = 5f; // Tiempo de espera entre disparos
    private float lastFireTime; // Última vez que se disparó

    void Start()
    {
        // Obtenemos el CharacterController del GameObject actual
        playerController = GetComponent<CharacterController>();
        lastFireTime = -fireCooldown; // Permitir disparar inmediatamente al inicio
    }

    void Update()
    {
        // Movimiento horizontal del jugador
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        movement = transform.TransformDirection(movement);
        playerController.Move(movement * Time.deltaTime * 50);

        // Verificamos si se presiona la tecla E o el botón de disparo en el mando
        if ((Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("Fire1")) && Time.time >= lastFireTime + fireCooldown)
        {
            // Actualizamos el tiempo del último disparo
            lastFireTime = Time.time;

            // Llamamos al método de sonido desde el SoundManager
            if (SoundManager != null)
            {
                SoundManager.GetComponent<SoundManager>().PlaybulletSound();
            }
            else
            {
                Debug.Log("SoundManager no está asignado.");
            }

            // Instanciamos y lanzamos el proyectil
            GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody>().AddForce(Vector3.up * 2000);
            Destroy(newBullet, 3); // Destruye el proyectil después de 3 segundos
        }
    }
}
