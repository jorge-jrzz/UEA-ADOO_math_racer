using UnityEngine;
using TMPro;

public class PreguntaController : MonoBehaviour
{
    public TMP_Text textoPregunta;
    public RespuestaCorrectaController respuestaCorrectaController;
    public RespuestaIncorrectaController respuestaIncorrectaController;

    private int numero1;
    private int numero2;
    private int respuestaCorrecta;

    private void Start()
    {
        SiguientePregunta();
    }

    public void SiguientePregunta()
    {
        GenerarPregunta();
        MostrarPregunta();
        respuestaCorrectaController.MostrarRespuestaCorrecta();
        respuestaIncorrectaController.MostrarRespuestaIncorrecta();
    }

    private void GenerarPregunta()
    {
        numero1 = Random.Range(1, 101);
        numero2 = Random.Range(1, 101);
        respuestaCorrecta = numero1 + numero2; // Calculamos y almacenamos la respuesta correcta.
    }

    public void MostrarPregunta()
    {
        if (textoPregunta != null)
        {
            textoPregunta.text = $"¿{numero1} + {numero2} = ?";
        }
        else
        {
            Debug.LogError("El componente TMP_Text no está asignado en el Inspector.");
        }
    }

    public int ObtenerRespuestaCorrecta()
    {
        return respuestaCorrecta; // Devolvemos la respuesta correcta.
    }
    public int ObtenerRespuestaIncorrecta()
{
    // Calcula una respuesta incorrecta basada en tu lógica.
    // Aquí, puedes generar una respuesta incorrecta de alguna manera.
    int respuestaIncorrecta = respuestaCorrecta + Random.Range(1, 10); // Por ejemplo, suma un número aleatorio.
    return respuestaIncorrecta;
}
    
}








