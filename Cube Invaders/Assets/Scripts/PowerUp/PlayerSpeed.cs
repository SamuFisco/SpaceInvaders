using System.Collections;
using UnityEngine;

public class PlayerSpeed : MonoBehaviour
{
    public float normalSpeed = 10f; // Velocidad normal
    private float currentSpeed; // Velocidad actual

    void Start()
    {
        currentSpeed = normalSpeed; // Inicializa la velocidad actual
    }

    void Update()
    {
        // Lógica de movimiento usando currentSpeed
        float moveHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * moveHorizontal * currentSpeed * Time.deltaTime);
    }

    public void ApplySpeedBoost(float boostAmount, float boostDuration)
    {
        StartCoroutine(SpeedBoostRoutine(boostAmount, boostDuration));
    }

    private IEnumerator SpeedBoostRoutine(float boostAmount, float boostDuration)
    {
        currentSpeed += boostAmount; // Aumenta la velocidad
        yield return new WaitForSeconds(boostDuration); // Espera la duración del efecto
        currentSpeed = normalSpeed; // Restaura la velocidad normal
    }
}
