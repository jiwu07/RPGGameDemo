using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    private ItemSO itemSO;
    public Image icon;

    public void IniteItemUI(ItemSO itemSO)
    {
       this.itemSO = itemSO;
       this.icon.sprite = itemSO.icon;
    }

    public void OnClick()
    {
        InventoryUI.Instance.ShowItemDetails(itemSO, this);
        
    }
}
