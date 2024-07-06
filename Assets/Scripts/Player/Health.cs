using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public Image healthBar;
    public Loot_OnDeath loot;
    private void Start()
    {
        if (CompareTag("Enemy")) currentHealth = maxHealth;

        loot = GetComponent<Loot_OnDeath>();
        DontDestroyOnLoad(gameObject);
    }

    public void Update() 
    {
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
            if (CompareTag("Enemy"))
            {
                loot.Loot_Monster();
            }
          
        }

        healthBar.fillAmount = currentHealth / 100f;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

   
}
