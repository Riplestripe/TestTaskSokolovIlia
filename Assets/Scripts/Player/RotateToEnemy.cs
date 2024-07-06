using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToEnemy : MonoBehaviour
{
    public Shoot enemy;
    public float lookSpeed;

    private void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Shoot").GetComponent<Shoot>();
    }
    void Update()
    {
        if (enemy.currentEnemy != null)
        {
            Vector3 direction = enemy.currentEnemy.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, Time.deltaTime * lookSpeed);
        }
        
    }
}
