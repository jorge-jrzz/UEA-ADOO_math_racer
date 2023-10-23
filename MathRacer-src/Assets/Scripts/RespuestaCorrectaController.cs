using UnityEngine;
using TMPro;

public class RespuestaCorrectaController : MonoBehaviour
{
    public TMP_Text textoRespuestaCorrecta;

    public void MostrarRespuestaCorrecta()
    {
        PreguntaController preguntaController = FindObjectOfType<PreguntaController>();
        if (preguntaController != null)
        {
            int respuestaCorrecta = preguntaController.ObtenerRespuestaCorrecta();
            textoRespuestaCorrecta.text = respuestaCorrecta.ToString();
        }
    }
}


