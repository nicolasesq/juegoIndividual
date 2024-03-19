using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class SaludPersonaje : MonoBehaviour
{
    public int saludMaxima = 5;
    public int saludActual;

    public Text textoSalud; 

    private void Start()
    {
        saludActual = saludMaxima;
        ActualizarTextoSalud(); 
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
        ActualizarTextoSalud(); 
        if (saludActual <= 0)
        {
            Debug.Log("El jugador ha perdido toda la salud. Reiniciando la escena...");
            SceneManager.LoadScene("Derrota");
        }
    }

    private void ReiniciarEscena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    
    private void ActualizarTextoSalud()
    {
        textoSalud.text = " " + saludActual.ToString();
    }
}
