using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCollision2 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Answer"))
        {
            // Llama al método Answer en el GameController2
            GameController2 gameController = FindObjectOfType<GameController2>();
            if (gameController != null)
            {
                // Busca el componente TextMeshPro en el objeto con la etiqueta 'Answer'
                TextMeshProUGUI textMeshPro = other.GetComponentInChildren<TextMeshProUGUI>();

                if (textMeshPro != null)
                {
                    // Convierte el texto del TextMeshPro a un número
                    if (int.TryParse(textMeshPro.text, out int answerValue))
                    {
                        gameController.Answer(answerValue);
                    }
                    else
                    {
                        Debug.LogError("No se pudo convertir el texto del TextMeshPro a un número.");
                    }
                }
                else
                {
                    Debug.LogError("No se encontró un componente TextMeshPro en el objeto con la etiqueta 'Answer'.");
                }
            }
        }
    }
}
