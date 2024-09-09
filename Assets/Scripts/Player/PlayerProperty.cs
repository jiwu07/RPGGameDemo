using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperty : MonoBehaviour
{
    public int hPValue;
    public int hPValueMax;

    public int energyVaule;
    public int mentalValue;

    public int level = 1;
    public int currentExp = 0;



    public Dictionary<PropertyType,List<Property>> propertyDict;

    // Start is called before the first frame update
    void Awake()
    {
        propertyDict = new Dictionary<PropertyType, List<Property>>();
        //propertyDict.Add(PropertyType.HP,new List<Property>());
        //propertyDict.Add(PropertyType.Energy, new List<Property>());
        //propertyDict.Add(PropertyType.Mental, new List<Property>());
        propertyDict.Add(PropertyType.Speed, new List<Property>());
        propertyDict.Add(PropertyType.Attack, new List<Property>());
        //propertyDict.Add(PropertyType.Experience, new List<Property>());

        InitialProperty();
        level = 1;
        EventCenter.OnEnemyDied += EnemyDie;

    }

    void InitialProperty()
    {
        hPValue = 100;
        energyVaule = 100;
        mentalValue = 100;

        //AddProperty(PropertyType.HP, 100);
        //AddProperty(PropertyType.Mental, 100);
        //AddPropertyddProperty(PropertyType.Energy, 100);

        AddProperty(PropertyType.Speed, 20);
        AddProperty(PropertyType.Attack, 10);
    }
    public void UseDrug(ItemSO item)
    {
        foreach(Property p in item.propertyList)
        {
            AddProperty(p.propertyType, p.value);
        }
    }

    public void UseWeapon(ItemSO item)
    {
        foreach (Property p in item.propertyList)
        {
            AddProperty(p.propertyType, p.value);
        }
    }

    void AddProperty(PropertyType type, int value)
    {
        switch (type)
        {
            case PropertyType.HP:
                hPValue += value;
                if(hPValue > hPValueMax)
                {
                    hPValue = hPValueMax;
                }
                return;
            case PropertyType.Mental:
                mentalValue += value;
                return;
            case PropertyType.Energy:
                energyVaule += value;
                return;
        }
        
        List<Property> list;
        propertyDict.TryGetValue(type, out list);
        list.Add(new Property(type,value));

    }

    void RemoveProperty(PropertyType type, int value)
    {
        switch (type)
        {
            case PropertyType.HP:
                hPValue -= value;
                return;
            case PropertyType.Mental:
                mentalValue -= value;
                return;
            case PropertyType.Energy:
                energyVaule -= value;
                return;
        }
        List<Property> list;
        propertyDict.TryGetValue(type, out list);
        list.Remove( list.Find(x => x.value == value ));

    }

    void EnemyDie(Enemy enemy)
    {
        currentExp += enemy.exp;

        if (currentExp >= level * 30)
        {
            //level up
            currentExp -= level * 30;
            level++;
           
            hPValueMax = level*level * 20 + 100;
            hPValue = hPValueMax;
        }
        PlayerPropertyUI.Instance.UpdatePlayerPropertyUI();

    }

    private void OnDestroy()
    {
        EventCenter.OnEnemyDied -= EnemyDie;

    }
}
