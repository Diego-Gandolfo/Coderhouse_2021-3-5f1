using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    //[SerializeField] private GameObject bulletPrefab; // TODO: usar ObjectPooling
    [SerializeField] private Transform spawnpoint;
    [SerializeField] private float impulse = 10.0f;
    [SerializeField] private float cooldown = 0.5f;

    private float timeCounter;

    private void Start()
    {
        timeCounter = cooldown;
    }

    private void Update()
    {
        Timer();
    }

    private void Timer()
    {
        timeCounter -= Time.deltaTime;

        if (timeCounter <= 0f)
        {
            Shoot();
            timeCounter = cooldown;
        }
    }

    private void Shoot()
    {
        //GameObject clone = Instantiate(bulletPrefab);
        GameObject clone = PoolManager.Instance.bulletPool.GetInstance();
        clone.transform.position = spawnpoint.position;
        clone.transform.rotation = spawnpoint.rotation;
        Rigidbody rb = clone.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.AddForce(impulse * spawnpoint.TransformDirection(Vector3.up), ForceMode.Impulse);
    }
}
