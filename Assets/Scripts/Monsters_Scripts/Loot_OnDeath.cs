using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot_OnDeath : MonoBehaviour
{
    public GameObject loot;

    public void Loot_Monster()
    {
        Instantiate(loot, this.transform.position, Quaternion.identity);
    }
    
   
}
