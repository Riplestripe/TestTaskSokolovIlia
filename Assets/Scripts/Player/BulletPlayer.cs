using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    public Shoot inRange;
    private Rigidbody2D rb;
    public float force;
    public int damage;
    private void Start()
    {
        inRange = GameObject.FindGameObjectWithTag("Shoot").GetComponent<Shoot>();
        rb = GetComponent<Rigidbody2D>();
        
        Vector3 direction = inRange.currentEnemy.transform.position - transform.position;
        rb.velocity = new Vector2 (direction.x, direction.y).normalized * force;
    }

    private void Update()
    {
        Destroy (this.gameObject,1);
    }
}
