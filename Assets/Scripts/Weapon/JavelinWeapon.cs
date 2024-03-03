using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavelinWeapon : Weapon
{
    public GameObject bulletPreFab;
    public float bulletSpeed = 20.0f;
    private GameObject bullet;


    private void Start()
    {
        SpawnBullet();
        attackValue = 20;
    }
   
    
    public override void attack()
    {
        if(bullet != null)
        {
            bullet.GetComponent<Collider>().enabled = true;
            bullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
            bullet.transform.parent = null;
            Invoke("SpawnBullet", 0.4f);
            bullet = null;
        }
        else
        {
            return;
        }
        
    }

    private void SpawnBullet()
    {
        bullet = GameObject.Instantiate(bulletPreFab, transform.position, transform.rotation);
        bullet.transform.parent = transform;
        bullet.GetComponent<Collider>().enabled = false;
        
    }

    
}
