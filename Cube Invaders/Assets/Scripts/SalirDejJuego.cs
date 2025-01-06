using UnityEngine;

public class SalirDelJuego : MonoBehaviour
{
    public void Salir()
    {
        Debug.Log("Saliendo del juego...");

#if UNITY_EDITOR
        // Si est�s en el Editor de Unity, solo det�n el juego
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Si es una compilaci�n, cierra la aplicaci�n
        Application.Quit();
#endif
    }
}
