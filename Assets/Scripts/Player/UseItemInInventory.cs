using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItemInInventory : MonoBehaviour
{
    public static UseItemInInventory Instance;
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

    public void UseItem(ItemSO itemSO, ItemUI itemUI)
    {
        //load weapon

        //use consumable item



        //remove itemUI from inventoryManager
        InventoryManager.Instance.RemoveItem(itemSO,itemUI);
        
        //close the detail UI
        DetailUI.Instance.Hide();
    }

    
}
