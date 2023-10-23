using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseMenuController : MonoBehaviour
{
    public GameObject lossPanel; // El panel de pérdida que debes asignar en el Inspector
    private AudioSource audioSource; // Referencia al componente AudioSource del objeto con la música de fondo

    private void Start()
    {
        // Busca el componente AudioSource en el objeto con la música de fondo por nombre
        audioSource = GameObject.Find("Audio").GetComponent<AudioSource>();
    }

    public void ShowLossPanel()
    {
        // Muestra el panel de pérdida
        lossPanel.SetActive(true);
        Time.timeScale = 0;

        // Detén la música de fondo
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }

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
