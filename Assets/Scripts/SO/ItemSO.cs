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
    public int Value;
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
