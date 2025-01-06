// Efecto Parallax para objetos del menú en Unity
// Adjunta este script a un GameObject vacío en tu escena de Unity

using UnityEngine;

public class MenuParallax : MonoBehaviour
{
    public Transform object1; // Asigna este objeto en el Inspector
    public Transform object2; // Asigna este objeto en el Inspector
    public Transform object3; // Asigna este objeto en el Inspector

    public float parallaxFactor1 = 0.02f; // Factor de movimiento para el objeto 1
    public float parallaxFactor2 = 0.04f; // Factor de movimiento para el objeto 2
    public float parallaxFactor3 = 0.06f; // Factor de movimiento para el objeto 3

    private Vector3 screenCenter; // Centro de la pantalla en coordenadas de pantalla
    private Vector3 initialPosObject2; // Posición inicial del objeto 2
    private Vector3 initialPosObject3; // Posición inicial del objeto 3

    void Start()
    {
        // Calcula el centro de la pantalla en coordenadas de pantalla
        screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);

        // Asigna las posiciones iniciales de los objetos 2 y 3
        if (object2 != null)
        {
            initialPosObject2 = new Vector3(-878f, 164f, object2.localPosition.z);
            object2.localPosition = initialPosObject2;
        }

        if (object3 != null)
        {
            initialPosObject3 = new Vector3(425f, 238f, object3.localPosition.z);
            object3.localPosition = initialPosObject3;
        }
    }

    void Update()
    {
        // Obtén la posición del ratón en coordenadas de pantalla
        Vector3 mousePosition = Input.mousePosition;

        // Calcula el desplazamiento desde el centro de la pantalla
        Vector3 offset = mousePosition - screenCenter;

        // Aplica el efecto parallax al objeto 1 (centrado en la pantalla)
        if (object1 != null)
        {
            object1.localPosition = new Vector3(offset.x * parallaxFactor1, offset.y * parallaxFactor1, object1.localPosition.z);
        }

        // Aplica el efecto parallax al objeto 2 (posición inicial ajustada)
        if (object2 != null)
        {
            object2.localPosition = initialPosObject2 + new Vector3(offset.x * parallaxFactor2, offset.y * parallaxFactor2, 0f);
        }

        // Aplica el efecto parallax al objeto 3 (posición inicial ajustada)
        if (object3 != null)
        {
            object3.localPosition = initialPosObject3 + new Vector3(offset.x * parallaxFactor3, offset.y * parallaxFactor3, 0f);
        }
    }
}
