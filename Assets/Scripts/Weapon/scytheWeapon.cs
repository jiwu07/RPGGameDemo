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
        attackValue = 50;
    }


    public override void attack()
    {
        anim.SetTrigger(ANIM_PARM_ISATTACK);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == Tag.ENERMY)
        {
            other.gameObject.GetComponent<Enemy>().HPdecrease(attackValue);
        }

    }

  
}
