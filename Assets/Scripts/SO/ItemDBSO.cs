using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ItemDBSO : ScriptableObject
{
    public List<ItemSO> ItemSOList;

    //maybe split as Weapon List and consumable and taskobject list?
}
