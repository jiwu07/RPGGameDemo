using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    public static InventoryManager Instance { get; private set; }
    public List<ItemSO> itemList;

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
        itemList.Add(item);
        InventoryUI.Instance.AddItem(item);
    }

    public void RemoveItem(ItemSO item, ItemUI itemUI)
    {
        //Remove from the list
        itemList.Remove(item);
        //remove from the UI
        InventoryUI.Instance.RemoveItem(itemUI);
    }
}
