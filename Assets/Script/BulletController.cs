using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float power = 100f;
    public float lifetime = 5f;
    float deltaTime = 0f;
    Rigidbody bulletRb;
    public int damage =1; 

    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();
        bulletRb.velocity = transform.forward * power;
    }

    void FixedUpdate()
    {
        deltaTime += Time.deltaTime;

        if (deltaTime >= lifetime)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemi"))
        {
            Debug.Log("Enemigo dañado");
            EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.RecibirDanio(damage);
            }
            Destroy(gameObject);
        }
    }
}