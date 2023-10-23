using UnityEngine;

public class MoverPersonaje : MonoBehaviour
{
    public float velocidad = 5.0f; // Ajusta la velocidad de movimiento en el Inspector.
    public float limiteIzquierdo; // Establece el límite izquierdo en el Inspector.
    public float limiteDerecho;  // Establece el límite derecho en el Inspector.

    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");

        // Calcula el desplazamiento en el eje X.
        float desplazamientoX = movimientoHorizontal * velocidad * Time.deltaTime;

        // Calcula la nueva posición en X.
        float nuevaPosicionX = transform.position.x + desplazamientoX;

        // Limita la posición a los límites del canvas.
        nuevaPosicionX = Mathf.Clamp(nuevaPosicionX, limiteIzquierdo, limiteDerecho);

        // Aplica el movimiento al personaje.
        transform.position = new Vector3(nuevaPosicionX, transform.position.y, transform.position.z);
    }
}