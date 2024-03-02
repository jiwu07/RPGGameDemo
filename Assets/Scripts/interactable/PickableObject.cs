using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : interactableObject
{

    public ItemSO itemSO;

    protected override void interact()
    {
        //pick the Object from ground then remove the Object from Map
        //InventoryManager.Instance.AddItem(itemSO);
        //Destroy(this);
    }
}
