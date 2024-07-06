using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerData
{
   public float[] position;
   public float health;
   public int Ammo;
}

[System.Serializable]
public class Inventory
{
    public string nameItem;
    public int quantity;
}
