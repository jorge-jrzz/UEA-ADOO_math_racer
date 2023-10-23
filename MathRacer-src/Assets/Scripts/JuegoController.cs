using UnityEngine;
using TMPro;

public class JuegoController : MonoBehaviour
{
    public PreguntaController preguntaController;
    public RespuestaCorrectaController respuestaCorrectaController;
    public RespuestaIncorrectaController respuestaIncorrectaController;

    public GameObject preguntaObjeto;
    public GameObject respuestaCorrectaObjeto;
    public GameObject respuestaIncorrectaObjeto;

    private int respuestasCorrectas = 0;
    private int respuestasIncorrectas = 0;

    private void Start()
    {
        MostrarNuevaPreguntaYRespuestas();
    }

    public void MostrarNuevaPreguntaYRespuestas()
    {
        GenerarNuevaPreguntaYRespuestas();
        preguntaController.MostrarPregunta();
        respuestaCorrectaController.MostrarRespuestaCorrecta();
        respuestaIncorrectaController.MostrarRespuestaIncorrecta();
    }

    public void OcultarPreguntaYRespuestasActuales()
    {
        preguntaObjeto.SetActive(false);
        respuestaCorrectaObjeto.SetActive(false);
        respuestaIncorrectaObjeto.SetActive(false);
    }

    public void IncrementarRespuestaCorrecta()
    {
        respuestasCorrectas++;
        // Aquí puedes realizar acciones relacionadas con respuestas correctas si es necesario.
    }

    public void IncrementarRespuestaIncorrecta()
    {
        respuestasIncorrectas++;
        // Aquí puedes realizar acciones relacionadas con respuestas incorrectas si es necesario.
    }

    private void GenerarNuevaPreguntaYRespuestas()
    {
        // Genera nuevas preguntas y respuestas aquí según tu lógica.
    }
}


