using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenuController : MonoBehaviour
{
    public void RestartGame()
    {
    // Reiniciar el juego (cargar la escena actual nuevamente)
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    
    // Restablecer la escala de tiempo
    Time.timeScale = 1f;
    }
    public void MainMenu()
    {
        // Volver al menú principal (cargar una escena que represente el menú principal)
        SceneManager.LoadScene("MenuPrincipal"); // Reemplaza "MenuPrincipal" con el nombre de tu escena del menú principal
    }

    public void LoadNextLevel()
    {
        // Carga la escena del siguiente nivel o la escena que desees.
        SceneManager.LoadScene("MenuDificultad"); // Reemplaza "MenuDificultad" con el nombre de tu escena de dificultad
    }
}
