using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ItemSlot : MonoBehaviour
{

    //=======ITEM DATA========//
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    [SerializeField]
    private int maxNumberOfItems;
    //=======ITEM SLOT========//
    [SerializeField]
    private TMP_Text quantityText;

    [SerializeField]
    private Image itemImage;


    public GameObject selectShader;
    public bool isThisItemSelected;

    private InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = GameObject.FindGameObjectWithTag("InventoryCanvas").GetComponent<InventoryManager>();
    }
    public int AddItem(string itemName, int quantity, Sprite itemSprite)
    {
        if (isFull) return quantity;
        

        
        this.itemName = itemName;
        this.itemSprite = itemSprite;
        itemImage.sprite = itemSprite;
        this.quantity += quantity;
       if( this.quantity >= maxNumberOfItems)
        {
            quantityText.text = maxNumberOfItems.ToString();
            quantityText.enabled = true;
            isFull = true;

            int extraItem = this.quantity - maxNumberOfItems;
            this.quantity = maxNumberOfItems;
            return extraItem;
        }

        quantityText.text = quantity.ToString();
        quantityText.enabled = true;
        return 0;

    }


    private void Update()
    {
        if(itemSprite != null)
        {
            itemImage.gameObject.SetActive(true);
            itemImage.sprite = itemSprite;
        }
        else itemImage.gameObject.SetActive(false);

        if (quantity > 0)
        {
            quantityText.text = quantity.ToString();
            quantityText.gameObject.SetActive(true);
        }
        else quantityText.gameObject.SetActive(false);

    }

    public void Select()
    {
        inventoryManager.DeSelectSlots();
        isThisItemSelected = !isThisItemSelected;
        selectShader.SetActive(isThisItemSelected);

    }

    public void DeleteItem()
    {
        if (isThisItemSelected)
        {
            if (quantity > 1)
            {
                quantity--;
            }
            else
            {
                this.itemName = null;
                this.itemSprite = null;
                itemImage.sprite = null;
                quantity = 0;
                isFull = false;
            }
        }
    }
}
