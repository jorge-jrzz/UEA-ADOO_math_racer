using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Answer"))
        {
            // Llama al método Answer en el GameController
            GameController gameController = FindObjectOfType<GameController>();
            if (gameController != null)
            {
                // Busca el componente TextMeshPro en el objeto con la etiqueta 'Answer'
                TMPro.TextMeshProUGUI textMeshPro = other.GetComponentInChildren<TMPro.TextMeshProUGUI>();

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




