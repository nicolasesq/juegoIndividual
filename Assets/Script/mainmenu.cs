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
        BloquearCursor(); 
    }

    public void EscenaInstrucciones()
    {
        SceneManager.LoadScene("Instrucciones");
        DesbloquearCursor(); 
    }

    public void devolver()
    {
        SceneManager.LoadScene("hudInicial");
        DesbloquearCursor(); 
    }

    public void Salir()
    {
        Application.Quit();
    }
}