using UnityEngine;

public class PersonajeController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("RespuestaObject") || collision.gameObject.CompareTag("RespuestaObject2"))
        {
            JuegoController juegoController = FindObjectOfType<JuegoController>();
            juegoController.MostrarNuevaPreguntaYRespuestas();
            juegoController.OcultarPreguntaYRespuestasActuales();
            Destroy(collision.gameObject); // Destruye la respuesta con la que colisionó.
        }
    }
}


