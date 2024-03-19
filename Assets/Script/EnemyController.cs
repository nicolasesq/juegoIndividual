using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public float rangoDeteccion = 10f;
    public float velocidad = 3f;
    public int vidaMaxima = 5;
    private int vidaActual;
    private Transform jugador;
    private Animator animador;

    
    public static int enemigosRestantes;
    public int enemigosParaGanar = 10; 

    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        animador = GetComponent<Animator>();
        vidaActual = vidaMaxima;

        
        enemigosRestantes++;
    }

    void Update()
    {
        float distanciaAlJugador = Vector3.Distance(transform.position, jugador.position);

        if (distanciaAlJugador <= rangoDeteccion)
        {
            Vector3 direccion = (jugador.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direccion.x, 0, direccion.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
            transform.position += transform.forward * velocidad * Time.deltaTime;
            animador.SetBool("isWalking", true);
        }
        else
        {
            animador.SetBool("isWalking", false);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangoDeteccion);
    }

    public void RecibirDanio(int cantidadDanio)
    {
        vidaActual -= cantidadDanio;
        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        
        enemigosRestantes--;
        Destroy(gameObject);

        
        if (enemigosRestantes <= 0)
        {
            SceneManager.LoadScene("Ganaste");
        }
    }
}