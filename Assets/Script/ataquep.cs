using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ataquep : MonoBehaviour
{
    public Animator JugadorAnim;
    public MovimientoPersonaje jugadorScript;
    public Transform Zonadedisparo;
    public Transform BulletPrefab;
    public float tiempoEntreDisparos = 0.5f;
    private float tiempoUltimoDisparo;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && jugadorScript.estaEnElSuelo && Time.time > tiempoUltimoDisparo + tiempoEntreDisparos)
        {
            JugadorAnim.SetTrigger("Ataque");
            tiempoUltimoDisparo = Time.time;
        }
    }

    public void Ataca()
    {
        jugadorScript.canMove = false;
        Instantiate(BulletPrefab, Zonadedisparo.position, Zonadedisparo.rotation);
    }

    public void DejaDeatar()
    {
        jugadorScript.canMove = true;
    }
}