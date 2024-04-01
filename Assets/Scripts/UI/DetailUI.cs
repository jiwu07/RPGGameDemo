using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DetailUI : MonoBehaviour
{
    public static DetailUI Instance;
    public Image icon;
    public GameObject detailUI;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI DescriptionText;
    public TextMeshProUGUI typeText;
    public GameObject featuresContent;
    public GameObject featuresPreFab;

    private ItemSO itemSO;
    private ItemUI itemUI;

    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
        Hide();
    }


    public void Show()
    {
        detailUI.SetActive(true);
    }

    public void Hide()
    {
        detailUI.SetActive(false);
    }

    public void IniteDetail(ItemSO itemSO, ItemUI itemUI)
    {
        this.itemSO = itemSO;
        this.itemUI = itemUI;

        //delete old features Content if have
        foreach (Transform child in featuresContent.transform)
        {
            Destroy(child.gameObject);
        }
        

        

        //create new Details 
        string type = "";
        this.icon.sprite = itemSO.icon;

        switch (itemSO.type)
        {
            case ItemType.Weapon:
                type = "Weapon";
                break;
            case ItemType.Consumable:
                type = "Consumable";
                break;
            case ItemType.TaskObject:
                type = "TaskObject";
                break;
        }
        typeText.text = type;
        nameText.text = itemSO.name;
        DescriptionText.text = itemSO.description;

        //inite features
        foreach (Property property in itemSO.propertyList)
        {
            string ProText = "";

            switch (property.propertyType)
            {
                case PropertyType.HP:
                    ProText = "HP: ";
                    break;
                case PropertyType.Attack:
                    ProText = "Attack: ";
                    break;
                case PropertyType.Energy:
                    ProText = "Energy: ";
                    break;
                case PropertyType.Mental:
                    ProText = "Mental: ";
                    break;
                case PropertyType.Speed:
                    ProText = "Speed: ";
                    break;
                case PropertyType.Experience:
                    ProText = "Experience: ";
                    break;
                default:
                    break;
            }

            ProText += property.Value;
            GameObject GO = GameObject.Instantiate(featuresPreFab);
            GO.transform.parent = featuresContent.transform;
            GO.transform.Find("Feature").GetComponent<TextMeshProUGUI>().text = ProText;

        }
    }

    public void OnClickUse()
    {
        UseItemInInventory.Instance.UseItem(itemSO, itemUI);
    }

    
}
