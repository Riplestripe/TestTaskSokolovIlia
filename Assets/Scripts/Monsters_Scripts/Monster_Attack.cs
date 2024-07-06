using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Attack : MonoBehaviour
{
    public float attackSpeed;
    public float timer;
    public int damage = 20;
    private void Start()
    {
        timer = attackSpeed;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("Player"))
        {
            timer -= Time.deltaTime;
            Health health = collision.GetComponent<Health>();
            if (health != null)
            {
                if (timer <= 0.1f)
                {
                    health.TakeDamage(damage);
                    timer = attackSpeed;
                }

            }
        }
    }
}
