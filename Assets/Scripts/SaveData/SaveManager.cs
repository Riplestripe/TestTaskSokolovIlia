using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    public Transform playerTransform;
    public float health;
    public int Ammo;

    public string nameItem;
    public int quantity;

    public Sprite Ammo_Rifle;
    private void Awake()
    {
        LoadGame();
    }
    private void Update()
    {
        
    }
    public void SaveGame()
    {
        PlayerData playerData  = new PlayerData();
        playerData.health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().currentHealth;
        playerData.Ammo = GameObject.FindGameObjectWithTag("Shoot").GetComponent<Shoot>().currentAmmo;
        playerData.position = new float[] { playerTransform.position.x, playerTransform.position.y };

        string json = JsonUtility.ToJson(playerData);
        string path = Application.persistentDataPath + "/PlayerData.json";
        System.IO.File.WriteAllText(path, json);

        Inventory inventory = new Inventory();
        InventoryManager invetoryManager = GameObject.FindGameObjectWithTag("InventoryCanvas").GetComponent<InventoryManager>();



        inventory.nameItem = invetoryManager.itemSlot[0].itemName;
        inventory.quantity = invetoryManager.itemSlot[0].quantity;
         
        string json1 = JsonUtility.ToJson(inventory);
        string path1 = Application.persistentDataPath + "/InventoryData.json";
        System.IO.File.WriteAllText(path1, json1);

    }

   public void LoadGame()
    {
        string path = Application.persistentDataPath + "/PlayerData.json";
        string path1 = Application.persistentDataPath + "/InventoryData.json";

        if (File.Exists(path))
        {
            string json = System.IO.File.ReadAllText(path);
            PlayerData loadedData = JsonUtility.FromJson<PlayerData>(json);

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            GameObject attackRange = GameObject.FindGameObjectWithTag("Shoot").GetComponent<Shoot>().gameObject;
            playerTransform.transform.position = new Vector3(loadedData.position[0], loadedData.position[1]);
            player.gameObject.GetComponent<Health>().currentHealth = loadedData.health;
            attackRange.gameObject.GetComponent<Shoot>().currentAmmo = loadedData.Ammo;
        }
        else Debug.LogWarning("Not file founded!");

        if (File.Exists(path1)) { 
            string json1 = System.IO.File.ReadAllText(path1);
            Inventory loadedInv = JsonUtility.FromJson<Inventory>(json1);

            InventoryManager invetoryManager = GameObject.FindGameObjectWithTag("InventoryCanvas").GetComponent<InventoryManager>();
            
            invetoryManager.itemSlot[0].itemName = loadedInv.nameItem;
            invetoryManager.itemSlot[0].quantity = loadedInv.quantity;
            invetoryManager.itemSlot[0].itemSprite = Ammo_Rifle;
        }
        else Debug.LogWarning("Not file founded!");
    }

    private void OnApplicationQuit()
    {
        SaveGame();

    }

}
