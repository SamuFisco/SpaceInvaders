using UnityEngine;

public class SalirDelJuego : MonoBehaviour
{
    public void Salir()
    {
        Debug.Log("Saliendo del juego...");

#if UNITY_EDITOR
        // Si estás en el Editor de Unity, solo detén el juego
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Si es una compilación, cierra la aplicación
        Application.Quit();
#endif
    }
}
