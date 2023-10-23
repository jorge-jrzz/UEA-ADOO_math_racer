using UnityEngine;
using TMPro;

public class RespuestaIncorrectaController : MonoBehaviour
{
    public TMP_Text textoRespuestaIncorrecta;

    public void MostrarRespuestaIncorrecta()
    {
        PreguntaController preguntaController = FindObjectOfType<PreguntaController>();
        if (preguntaController != null)
        {
            int respuestaIncorrecta = preguntaController.ObtenerRespuestaIncorrecta();
            textoRespuestaIncorrecta.text = respuestaIncorrecta.ToString();
        }
    }
}



