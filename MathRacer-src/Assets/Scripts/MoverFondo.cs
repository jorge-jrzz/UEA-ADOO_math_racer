using UnityEngine;

public class MoverFondo : MonoBehaviour
{
    public float velocidad = 10.0f; // Ajusta la velocidad de movimiento en el Inspector.

    void Update()
    {
        // Mueve el fondo hacia abajo.
        transform.Translate(Vector3.down * velocidad * Time.deltaTime);

        // Verifica si el fondo ha bajado lo suficiente para reposicionarlo en la parte superior de la pantalla.
        if (transform.position.y <= -Screen.height / 2)
        {
            RepositionFondo();
        }
    }

    // Función para reposicionar el fondo en la parte superior de la pantalla.
    void RepositionFondo()
    {
        Vector3 newPosition = new Vector3(transform.position.x, Screen.height / 2, transform.position.z);
        transform.position = newPosition;
    }
}