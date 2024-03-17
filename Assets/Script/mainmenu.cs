using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    void Start()
    {
        DesbloquearCursor();
    }

    public void BloquearCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void DesbloquearCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void EscenaJuego()
    {
        SceneManager.LoadScene("juego");
        BloquearCursor(); // Desbloquear el cursor al cargar la escena del juego
    }

    public void EscenaInstrucciones()
    {
        SceneManager.LoadScene("Instrucciones");
        DesbloquearCursor(); // Desbloquear el cursor al cargar la escena de instrucciones
    }

    public void devolver()
    {
        SceneManager.LoadScene("hudInicial");
        DesbloquearCursor(); // Desbloquear el cursor al cargar la escena del HUD inicial
    }

    public void Salir()
    {
        Application.Quit();
    }
}