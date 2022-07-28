using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 15f;
    [SerializeField] private GameObject particleEffect; // TODO: usar Object Pooling

    private Rigidbody myRigidbody;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        myRigidbody.velocity = transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var enemy = collision.transform.gameObject.GetComponent<Enemy>();

        if (enemy != null)
        {
            Instantiate(particleEffect, transform.position, transform.rotation);
            //Destroy(enemy.gameObject, 0.15f);
            enemy.gameObject.SetActive(false);
        }

        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
}
