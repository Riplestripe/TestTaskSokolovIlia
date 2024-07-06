using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interactble
{

    [SerializeField]
    private string itemname;

    [SerializeField]
    private int quantity;

    [SerializeField]
    private Sprite sprite;

 


    public InventoryManager inventoryManager;

    void Start()
    {
        inventoryManager = GameObject.FindGameObjectWithTag("InventoryCanvas").GetComponent<InventoryManager>();
    }

    protected override void Interact()
    {

        int leftOverItems = inventoryManager.AddItem(itemname, quantity, sprite);
        if (leftOverItems <= 0) Destroy(gameObject);
        else quantity = leftOverItems;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("1");
            Interact();
        }
           

        
    }
}
