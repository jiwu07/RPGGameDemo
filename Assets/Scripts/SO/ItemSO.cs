using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ItemSO : ScriptableObject
{
    public int id;
    public string itemName;
    public ItemType type;
    public string description;
    public List<Property> propertyList;
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
public class Property
{
    public PropertyType propertyType;
    public int value;

    public Property()
    {

    }
    public Property(PropertyType type, int value)
    {
        propertyType = type;
        this.value = value;
    }
}

public enum PropertyType
{
    HP,
    Energy,
    Mental,
    Speed,
    Attack,
    Experience
}
