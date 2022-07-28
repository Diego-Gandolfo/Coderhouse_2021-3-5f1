using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab; // TODO: usar Object Pooling
    [SerializeField] private float startCooldown;
    [SerializeField] private float reduceCooldownTime;
    [SerializeField] private float reduceCooldownAmount;
    [SerializeField] private float minCooldown;

    private bool canSpawn;
    private bool reachedMinCooldown;
    private float cooldownCounter;
    private float reduceCounter;
    private float currentCooldown;

    private void Start()
    {
        currentCooldown = startCooldown;
    }

    private void Update()
    {
        if (canSpawn)
        {
            Instantiate(enemyPrefab, GetRandomPosition(), GetRandomRotation());
            canSpawn = false;
        }
        else
        {
            RunCooldown();
        }

        if (!reachedMinCooldown)
        {
            RunReduceCooldown();
        }
    }

    private Vector3 GetRandomPosition()
    {
        var x = Random.Range(-25f, 25f);
        var z = Random.Range(-25f, 25f);
        return new Vector3(x, 0f, z);
    }

    private Quaternion GetRandomRotation()
    {
        var y = Random.Range(0f, 360f);
        return Quaternion.Euler(0f, y, 0f);
    }

    private void RunCooldown()
    {
        cooldownCounter += Time.deltaTime;

        if (cooldownCounter >= currentCooldown)
        {
            cooldownCounter = 0f;
            canSpawn = true;
        }
    }
    private void RunReduceCooldown()
    {
        reduceCounter += Time.deltaTime;

        if (reduceCounter >= reduceCooldownTime)
        {
            reduceCounter = 0f;
            currentCooldown -= reduceCooldownAmount;

            if (currentCooldown <= minCooldown)
            {
                currentCooldown = minCooldown;
                reachedMinCooldown = true;
            }
        }
    }
}
