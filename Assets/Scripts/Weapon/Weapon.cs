using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int attackValue;
    public Sprite weaponIcon;

    public virtual void attack()
    {
       // print("attack");
    }
}
