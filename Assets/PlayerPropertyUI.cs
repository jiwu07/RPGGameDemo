using System.Collections;
using System.Collections.Generic;

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPropertyUI : MonoBehaviour
{
    public static PlayerPropertyUI Instance { get; private set; }

    private GameObject UI;
    private Image hpImage;
    private TextMeshProUGUI hpText;

    private Image expImage;
    private TextMeshProUGUI levelText;

    public GameObject PropertyItem;
    private GameObject gridList;

    private Image weaponIcon;
    private PlayerProperty pp;
    private PlayerAttack pa;


    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;

        UI = transform.Find("UI").gameObject;
        hpImage = transform.Find("UI/HP/HP").GetComponent<Image>();
        expImage = transform.Find("UI/EXP/EXP").GetComponent<Image>();

        hpText = transform.Find("UI/HP/HPValue").GetComponent<TextMeshProUGUI>();
        levelText = transform.Find("UI/EXP/LevelValue").GetComponent<TextMeshProUGUI>();

        gridList = transform.Find("UI/PropertyGrid").gameObject;
        weaponIcon = transform.Find("UI/WeaponIcon").GetComponent<Image>(); ;
        

        GameObject player = GameObject.Find("Player").gameObject;
        pp = player.GetComponent<PlayerProperty>();
        pa = player.GetComponent<PlayerAttack>();
        UpdatePlayerPropertyUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (UI.activeSelf)
            {
                Hide();
            }
            else
            {
                Show();
            }
        }
    }

    public void UpdatePlayerPropertyUI()
    {
        if(pa.weapon != null)
        {
            //weaponIcon.sprite = pa.weaponIcon;
            weaponIcon.sprite = pa.weapon.GetComponent<Weapon>().weaponIcon;

        }
        else
        {
            weaponIcon.sprite = null;
        }

        hpText.text = pp.hPValue.ToString() + "/" + pp.GetHPMaxValue().ToString();
        hpImage.fillAmount = pp.hPValue / pp.GetHPMaxValue();

        levelText.text = pp.level.ToString();
        expImage.fillAmount = pp.currentExp / (pp.level * 30.0f);

        //update text grid
        ClearText();

        AddToPropertyList(PropertyType.Energy.ToString() + ": " + pp.energyVaule);
        AddToPropertyList(PropertyType.Mental.ToString() + ": " + pp.mentalValue);
        AddToPropertyList(PropertyType.Attack .ToString() + ": " + pp.GetAttackValue());
        AddToPropertyList(PropertyType.Speed.ToString() + ": " + pp.GetSpeedValue());


    }

    private void ClearText()
    {
        //delete old features Content if have
        foreach (Transform child in gridList.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void AddToPropertyList(string property)
    {
        GameObject GO = Instantiate(PropertyItem);
        GO.SetActive(true);
        GO.transform.SetParent(gridList.transform);
        GO.transform.Find("Property").GetComponent<TextMeshProUGUI>().enabled = true;
        GO.transform.Find("Property").GetComponent<TextMeshProUGUI>().text = property;
    }

    private void Show() 
    {
        UI.SetActive(true);
    }
    private void Hide()
    {
        UI.SetActive(false);
    }
}
