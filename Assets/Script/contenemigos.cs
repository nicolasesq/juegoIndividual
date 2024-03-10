
using UnityEngine;
using UnityEngine.UI;

public class contenemigos : MonoBehaviour
{
    public static int enemigosRestantes { get; private set; }

    public Text enemigosRestantesText;
    public int enemigosIniciales = 8;

    void Start()
    {
        enemigosRestantes = enemigosIniciales;
        ActualizarHUD();
    }

    public static void DecrementarEnemigosRestantes()
    {
        enemigosRestantes--;
        ActualizarHUD();
    }

    static void ActualizarHUD()
    {
        
    }
}