using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCenter : MonoBehaviour
{
    public static Action<Enemy> OnEnemyDied;
    public static Action<ItemSO> OnTaskObjectGet;


    public static void EnemyDied(Enemy enemy)
    {
        OnEnemyDied?.Invoke(enemy);
    }

    public static void TaskObjectGet(ItemSO itemSO)
    {
        OnTaskObjectGet?.Invoke(itemSO);
    }



}
