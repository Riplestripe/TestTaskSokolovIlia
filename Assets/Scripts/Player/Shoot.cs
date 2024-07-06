using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject[] enemys;
    public GameObject currentEnemy;
    public GameObject bullet;
    public GameObject bulletPos;
    public TMP_Text ammoCount;
    public int currentAmmo;
    [SerializeField] private int maxAmmo;
    public int damage = 20;
    public void Shooting()
    {
        if (currentAmmo > 0 && currentEnemy != null)
        {
            Instantiate(bullet, bulletPos.transform.position, Quaternion.identity);
            currentEnemy.GetComponent<Health>().TakeDamage(damage);
            
            --currentAmmo;
        }
       
    }
    private void Update()
    {
        ammoCount.text = currentAmmo.ToString() + "/" + maxAmmo.ToString();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemys = GameObject.FindGameObjectsWithTag("Enemy");
            currentEnemy = enemys[0];
        }
        else enemys = null;
    }
}
