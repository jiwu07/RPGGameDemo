using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    public static InventoryManager Instance { get; private set; }
    public List<ItemSO> itemList;

    public ItemSO defaultWeapon;

    //DEFAULT WEAPEN
    //IEnumerator Start()
    //{
    //    yield return new WaitForSeconds(1);
    //    AddItem(defaultWeapon);
    //}

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    public void AddItem(ItemSO item)
    {
        //hier need to optimize, when unload weapon putback
        //to inventory,shouldn't show anything


        if (item.type != ItemType.Weapon && item.type != ItemType.Consumable)
        {
            Debug.Log("taskobject get" + item.type);
            EventCenter.TaskObjectGet(item);

            return;
        }

        itemList.Add(item);
        InventoryUI.Instance.AddItem(item);

        MessageUI.Instance.Show("You get an new item " + item.itemName);
    }

    public void RemoveItem(ItemSO item, ItemUI itemUI)
    {
        //Remove from the list
        itemList.Remove(item);
        //remove from the UI
        InventoryUI.Instance.RemoveItem(itemUI);
    }
}
