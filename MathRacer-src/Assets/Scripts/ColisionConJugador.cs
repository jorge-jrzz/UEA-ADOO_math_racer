using UnityEngine;
using System.Collections;

public class ColisionConJugador : MonoBehaviour
{
    public JuegoController juegoController;

    private bool colisionDetectada = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!colisionDetectada && (collision.gameObject.CompareTag("RespuestaObject") || collision.gameObject.CompareTag("RespuestaObject2")))
        {
            colisionDetectada = true;

            juegoController.OcultarPreguntaYRespuestasActuales();
            
            // Inicia una corrutina para reactivar los objetos después de un tiempo
            StartCoroutine(ReactivarDespuesDeTiempo());
        }
    }

    IEnumerator ReactivarDespuesDeTiempo()
    {
        // Espera un tiempo antes de reactivar
        yield return new WaitForSeconds(2f);  // Ajusta el tiempo como desees
        
        juegoController.MostrarNuevaPreguntaYRespuestas();
    }
}





