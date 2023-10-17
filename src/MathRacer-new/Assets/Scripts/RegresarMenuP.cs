using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDificultad : MonoBehaviour
{
    public void IrAMenuPrincipal()
    {
        // Este método se llama cuando se hace clic en el botón "Menú Principal".
        // Carga la escena del menú principal.
        SceneManager.LoadScene("MenuPrincipal");
    }
}
 
