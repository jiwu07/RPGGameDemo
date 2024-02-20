using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scytheWeapon : Weapon
{
    public  const string ANIM_PARM_ISATTACK = "isAttack";

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public override void attack()
    {
        anim.SetTrigger(ANIM_PARM_ISATTACK);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Enemy")
        {
            print(other.name);
        }

    }
}
