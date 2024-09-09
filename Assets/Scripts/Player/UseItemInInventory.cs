using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItemInInventory : MonoBehaviour
{
    public static UseItemInInventory Instance { get; private set; }
    private PlayerAttack playerAttack;
    private PlayerProperty playerProperty;

    void Start()
    {
        playerAttack = GetComponent<PlayerAttack>();
        playerProperty = GetComponent<PlayerProperty>();

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

    public void UseItem(ItemSO itemSO, ItemUI itemUI)
    {
        switch (itemSO.type)
        {
            case ItemType.Weapon:
                //load weapon
                playerAttack.LoadWeapon(itemSO);
                PlayerPropertyUI.Instance.UpdatePlayerPropertyUI();

                break;
            case ItemType.Consumable:
                //use consumable item
                playerProperty.UseDrug(itemSO);
                PlayerPropertyUI.Instance.UpdatePlayerPropertyUI();

                break;
            case ItemType.TaskObject:
                //todo:
                break;
            default:
                break;
        }
        

        //remove itemUI from inventoryManager
        InventoryManager.Instance.RemoveItem(itemSO,itemUI);
        
        //close the detail UI
        DetailUI.Instance.Hide();
    }

    
}
