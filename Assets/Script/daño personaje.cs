using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Importa este namespace para usar Text

public class SaludPersonaje : MonoBehaviour
{
    public int saludMaxima = 5;
    public int saludActual;

    public Text textoSalud; // Referencia al objeto de texto en el HUD

    private void Start()
    {
        saludActual = saludMaxima;
        ActualizarTextoSalud(); // Llama a esta función al inicio para inicializar el texto
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemi"))
        {
            Debug.Log("Jugador dañado");
            PerderSalud(1);
        }

        if (other.CompareTag("agua"))
        {
            Debug.Log("Jugador dañado");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void PerderSalud(int cantidad)
    {
        saludActual -= cantidad;
        ActualizarTextoSalud(); // Actualiza el texto cada vez que se pierde salud
        if (saludActual <= 0)
        {
            Debug.Log("El jugador ha perdido toda la salud. Reiniciando la escena...");
            ReiniciarEscena();
        }
    }

    private void ReiniciarEscena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Función para actualizar el texto de la salud en el HUD
    private void ActualizarTextoSalud()
    {
        textoSalud.text = " " + saludActual.ToString();
    }
}
