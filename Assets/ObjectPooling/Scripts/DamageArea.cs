using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float cooldown;

    private bool canAttack;
    private float timeCounter;

    private void Update()
    {
        if (canAttack) return;

        RunCooldown();
    }

    private void OnTriggerStay(Collider collider)
    {
        var player = collider.gameObject.GetComponent<Player>();

        if (player != null && canAttack)
        {
            player.MakeDamage(damage);
            canAttack = false;
        }
    }

    private void RunCooldown()
    {
        timeCounter += Time.deltaTime;

        if (timeCounter >= cooldown)
        {
            timeCounter = 0f;
            canAttack = true;
        }
    }
}
