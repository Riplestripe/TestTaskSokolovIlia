using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventory;
    bool isMenuActive;
    public ItemSlot[] itemSlot;
    [SerializeField] private GameObject deleteBtn;
    void Start()
    {
        inventory = transform.GetChild(0).gameObject;
        inventory.SetActive(false);
        deleteBtn.SetActive(false);
        DontDestroyOnLoad(transform.parent);
    }

    public int AddItem(string itemName, int quantity, Sprite itemSprite)
    {

        for (int i = 0; i < itemSlot.Length; i++) 
        {
            if (itemSlot[i].isFull == false && itemSlot[i].itemName == itemName || itemSlot[i].quantity == 0)
            {
                int leftOverItems = itemSlot[i].AddItem(itemName, quantity, itemSprite);
                if (leftOverItems > 0) leftOverItems = AddItem(itemName, leftOverItems, itemSprite);
      
                return leftOverItems;
                
            }
        }
        return quantity;
    }

    public void DeSelectSlots()
    {
        for(int i = 0;i < itemSlot.Length; i++)
        {
            itemSlot[i].selectShader.SetActive(false);
            itemSlot[i].isThisItemSelected = false;
        }
    }

    public void InventoryButton()
    {
        isMenuActive = !isMenuActive;
        inventory.SetActive(isMenuActive);
        deleteBtn.SetActive(isMenuActive);
    }

    
}
