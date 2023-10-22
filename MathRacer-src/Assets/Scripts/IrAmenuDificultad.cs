using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void IrAMenuDifi()
    {
        // Este método se llama cuando se hace clic en el botón "Jugar".
        // Carga la escena del menú de dificultad.
        SceneManager.LoadScene("MenuDificultad");
    }
}