using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cargar escenas

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // El panel del menú de pausa

    public void Resume()
    {
        // Continuar el juego
        Time.timeScale = 1f; // Reanuda la escala de tiempo para que el juego avance
        pauseMenuUI.SetActive(false); // Oculta el panel del menú de pausa
    }

    public void RestartGame()
{
    // Restablece la escala de tiempo a 1 antes de cargar la escena
    Time.timeScale = 1f;

    // Reiniciar el juego (cargar la escena actual nuevamente)
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}

    public void MainMenu()
    {
        // Volver al menú principal (cargar una escena que represente el menú principal)
        SceneManager.LoadScene("MenuPrincipal"); // Reemplaza "MainMenu" con el nombre de tu escena del menú principal
    }

    public void OpenPauseMenu()
    {
        Time.timeScale = 0f; // Pausa el juego al establecer la escala de tiempo en 0
        pauseMenuUI.SetActive(true); // Muestra el panel del menú de pausa
    }
}

