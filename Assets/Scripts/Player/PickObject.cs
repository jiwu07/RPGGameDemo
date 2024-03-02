using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickObject : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GameObject GO = collision.gameObject;
        if (GO.tag == Tag.INTERACTABLE)
        {
            PickableObject po = GO.GetComponent<PickableObject>();
            if (po != null && po.itemSO != null)
            {
                //At least is not an NPC xD
                //pick the Object from ground then remove the Object from Map
                InventoryManager.Instance.AddItem(po.itemSO);
                Destroy(GO);
            }
        }

        
    }
}
