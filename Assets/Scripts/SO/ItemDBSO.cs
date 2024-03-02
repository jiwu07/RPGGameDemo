using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ItemDBSO : ScriptableObject
{
    //public List<ItemSO> allItemList;
    public List<ItemSO> weaponSOList;
    public List<ItemSO> weaponSOFallingList;

    public List<ItemSO> consumableSOList;
    public List<ItemSO> taskObjectSOList;

    


    //maybe split as Weapon List and consumable and taskobject list?
}
