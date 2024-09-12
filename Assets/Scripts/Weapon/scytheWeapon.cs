using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class scytheWeapon : Weapon
{
    public const string ANIM_PARM_ISATTACK = "isAttack";

    private Animator anim;

     void Start()
    {
        anim = GetComponent<Animator>();
        //weaponProperty.Add(new Property(PropertyType.Attack, 50 ));
        //weaponProperty.Add(new Property(PropertyType.Speed, -5));
        //weaponProperty.Add(new Property(PropertyType.HP, 55));

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == Tag.ENERMY)
        {
            int attack = PlayerProperty.Instance.GetAttackValue();
            other.gameObject.GetComponent<Enemy>().HPdecrease(attack);
        }

    }

    public override void attack()
    {
        anim.SetTrigger(ANIM_PARM_ISATTACK);
    }

    

  
}
