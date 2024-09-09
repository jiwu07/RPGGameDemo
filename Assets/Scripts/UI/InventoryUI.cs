using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting.ReorderableList;

using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance; 
    public GameObject inventoryUI;
    public GameObject content;
    public GameObject itemPreFab;

    private bool isShow = false;

    //details
    public GameObject detailUI;


    // Start is called before the first frame update
    void Start()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
        Hide();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (isShow)
            {
                Hide();
                isShow = false;
            }
            else
            {
                Show();
                isShow = true;
            }
        }
        
    }



    public void Show()
    {
        inventoryUI.SetActive(true);
    }

    public void Hide()
    {
        inventoryUI.SetActive(false);
        DetailUI.Instance.Hide();
    }

    public void AddItem(ItemSO itemSO)
    {
        GameObject item = Instantiate(itemPreFab);
        item.transform.parent = content.transform;

        item.GetComponent<ItemUI>().IniteItemUI(itemSO);

    }

    public void RemoveItem(ItemUI itemUI)
    {
        Destroy(itemUI.gameObject);
    }
    public void ShowItemDetails(ItemSO itemSO,ItemUI itemUI)
    {
        DetailUI.Instance.IniteDetail(itemSO, itemUI);
        DetailUI.Instance.Show();
    }
}
