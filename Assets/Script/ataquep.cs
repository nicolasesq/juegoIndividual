using UnityEngine;

public class AtaqueP : MonoBehaviour
{
    public GameObject proyectilPrefab;
    public Transform puntoDisparo;
    public float fuerzaDisparo = 1000f;
    public float cadenciaDisparo = 0.5f;

    private float tiempoUltimoDisparo;
    private Animator animator; // Referencia al componente Animator

    void Start()
    {
        animator = GetComponent<Animator>(); // Obtiene la referencia al componente Animator
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > tiempoUltimoDisparo + cadenciaDisparo)
        {
            Disparar();
            tiempoUltimoDisparo = Time.time;
        }
    }

    void Disparar()
    {
        animator.SetTrigger("Ataque"); // Activa la condición de animación "Ataque"

        GameObject proyectil = Instantiate(proyectilPrefab, puntoDisparo.position, puntoDisparo.rotation);
        Rigidbody rb = proyectil.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddForce(puntoDisparo.forward * fuerzaDisparo);
        }
    }
}