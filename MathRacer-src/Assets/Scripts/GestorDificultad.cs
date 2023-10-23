using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestorDificultad : MonoBehaviour
{
     public void CargarNivelFacil()
    {
        SceneManager.LoadScene("Facil");
    }

    public void CargarNivelMedio()
    {
        SceneManager.LoadScene("Medio");
    }

    public void CargarNivelDificil()
    {
        SceneManager.LoadScene("Dificil");
    }
}
