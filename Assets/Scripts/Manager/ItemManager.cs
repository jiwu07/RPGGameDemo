using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{

    public static ItemManager Instance{ get; private set; }
    public ItemDBSO itemDBSO;

    // Start is called before the first frame update
    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    public (ItemSO,ItemSO) GetRandomWeapon()
    {
        int index = Random.Range(0, itemDBSO.weaponSOFallingList.Count);
        return (itemDBSO.weaponSOFallingList[index], itemDBSO.weaponSOList[index]);
    }

    public ItemSO GetRandomConsumable()
    {
        int index = Random.Range(0, itemDBSO.consumableSOList.Count);
        return itemDBSO.consumableSOList[index];
    }
}
