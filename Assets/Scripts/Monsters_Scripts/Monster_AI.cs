using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_AI : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision != null && collision.CompareTag("Player"))
        {
            Vector2 playerPos = collision.transform.position - transform.position;
            rb.velocity = new Vector2(playerPos.x, playerPos.y).normalized * speed;

        }
    }
}
