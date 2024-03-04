using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ItemSO : ScriptableObject
{
    public int id;
    public string name;
    public ItemType type;
    public string description;
    public List<ItemProperty> propertyList;
    public Sprite icon;
    public GameObject prefab;
    public string positionName;
}

public enum ItemType
{
    Weapon,
    Consumable,
    TaskObject
}

[Serializable]
public class ItemProperty
{
    public ItemPropertyType propertyType;
    public int Value;
}

public enum ItemPropertyType
{
    HP,
    Energy,
    Mental,
    Speed,
    Attack,
    Experience
}
