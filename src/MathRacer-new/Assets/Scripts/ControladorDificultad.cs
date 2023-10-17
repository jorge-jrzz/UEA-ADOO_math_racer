using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorTransicion : MonoBehaviour
{
    public string MenuDificultad; // El nombre de la escena del menú de dificultad.

    public void CargarMenuDificultad()
    {
        SceneManager.LoadScene(MenuDificultad); // Carga la escena del menú de dificultad.
    }
}
