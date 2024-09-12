using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class PlayerProperty : MonoBehaviour
{
    public static PlayerProperty Instance { get; private set; }
    public int hPValue;
    public int hPValueMax;

    public int energyVaule;
    public int mentalValue;

    public int level = 1;
    public int currentExp = 0;



    public Dictionary<PropertyType,List<Property>> propertyDict;

    private void Start()
    {
        if(Instance != null && this != Instance)
        {
            Destroy(this);
            return;
        }
        Instance = this;

    }

    void Awake()
    {
        propertyDict = new Dictionary<PropertyType, List<Property>>();
        //propertyDict.Add(PropertyType.HP,new List<Property>());
        //propertyDict.Add(PropertyType.Energy, new List<Property>());
        //propertyDict.Add(PropertyType.Mental, new List<Property>());
        propertyDict.Add(PropertyType.Speed, new List<Property>());
        propertyDict.Add(PropertyType.Attack, new List<Property>());
        propertyDict.Add(PropertyType.HPMax, new List<Property>());

        InitialProperty();
        level = 1;
        EventCenter.OnEnemyDied += EnemyDie;

    }

    void InitialProperty()
    {
        hPValue = 100;
        energyVaule = 100;
        mentalValue = 100;

        hPValueMax = 100;
        //AddProperty(PropertyType.Mental, 100);
        //AddPropertyddProperty(PropertyType.Energy, 100);

        AddProperty(PropertyType.Speed, 20);
        AddProperty(PropertyType.Attack, 10);
    }
    public void UseDrug(ItemSO item)
    {
        AddPropertyList(item.propertyList);
       
    }

    public void UseWeapon(ItemSO item)
    {
        foreach (Property p in item.propertyList)
        {
            AddProperty(p.propertyType, p.value);
        }
    }
    public void AddPropertyList(List<Property> list)
    {
        foreach(Property p in list)
        {
            AddProperty(p.propertyType, p.value);
        }
    }

        public void AddProperty(PropertyType type, int value)
    {
        switch (type)
        {
            case PropertyType.HP:
                hPValue += value;
                if(hPValue > GetHPMaxValue())
                {
                    hPValue = GetHPMaxValue();
                }
                return;
            case PropertyType.HPMax:
                hPValue += value;
                List<Property> list2;
                propertyDict.TryGetValue(type, out list2);
                list2.Add(new Property(type, value));
                if (hPValue > GetHPMaxValue())
                {
                    hPValue = GetHPMaxValue();
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
    public void RemovePropertyList(List<Property> list)
    {
        foreach (Property p in list)
        {
            RemoveProperty(p.propertyType, p.value);
        }
    }

    void RemoveProperty(PropertyType type, int value)
    {
        switch (type)
        {
            case PropertyType.HP:
                hPValue -= value;
                if (hPValue < 0)
                {
                    hPValue = 0;
                }
                return;
            case PropertyType.HPMax:
                List<Property> list2;
                propertyDict.TryGetValue(type, out list2);
                list2.Remove(list2.Find(x => x.value == value));
                if (hPValue > GetHPMaxValue())
                {
                    hPValue = GetHPMaxValue();
                }
                return;
            case PropertyType.Mental:
                mentalValue -= value;
                if (mentalValue < 0)
                {
                    mentalValue = 0;
                }
                
                return;
            case PropertyType.Energy:
                energyVaule -= value;
                if (energyVaule < 0)
                {
                    energyVaule = 0;
                }
                return;
        }
        List<Property> list;
        propertyDict.TryGetValue(type, out list);
        list.Remove( list.Find(x => x.value == value ));

    }
    public int GetHPMaxValue()
    {
        List<Property> list;
        propertyDict.TryGetValue(PropertyType.HPMax, out list);
        int sum = 0;
        foreach (var item1 in list)
        {
            sum += item1.value;
        }
        return sum + hPValueMax;
    }
    public int GetAttackValue()
    {
        List<Property> list;
        propertyDict.TryGetValue(PropertyType.Attack, out list);
        int sum = 0;
        foreach (var item1 in list)
        {
            sum += item1.value;
        }
        return sum;
    }

    public int GetSpeedValue()
    {
        List<Property> list;
        propertyDict.TryGetValue(PropertyType.Speed, out list);
        int sum = 0;
        foreach (var item1 in list)
        {
            sum += item1.value;
        }
        return sum;
    }

    void EnemyDie(Enemy enemy)
    {
        currentExp += enemy.exp;

        if (currentExp >= level * 30)
        {
            //level up
            currentExp -= level * 30;
            level++;

            hPValueMax =(int) 1.2f * level * hPValueMax;
            hPValue = GetHPMaxValue();
        }
        PlayerPropertyUI.Instance.UpdatePlayerPropertyUI();

    }

    private void OnDestroy()
    {
        EventCenter.OnEnemyDied -= EnemyDie;

    }
}
