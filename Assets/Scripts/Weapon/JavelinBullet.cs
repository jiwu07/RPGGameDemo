using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavelinBullet : MonoBehaviour
{
    private Rigidbody rgd;
    private Collider cld;
    public int damage = 20;
    // Start is called before the first frame update
    private void Start()
    {
        rgd = GetComponent<Rigidbody>();
        cld = GetComponent<Collider>();
        damage = PlayerProperty.Instance.GetAttackValue();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(transform.parent != null)
        {
            //if the bullet didn't shoot, there will be no damage
            return;
        }

        //bullet shooted
        string t = collision.gameObject.tag;
        if( t == Tag.PLAYER)
        {
            //for now, it can not hurt player
            return;
        }

        if(t == Tag.ENERMY)
        {
            transform.parent = collision.gameObject.transform;
            collision.gameObject.GetComponent<Enemy>().HPdecrease(damage);
        }

        //Bullet stop and not interactable
        rgd.velocity = Vector3.zero;
        rgd.isKinematic = false;
        cld.enabled = false;
        //disappear 
        Destroy(this.gameObject, 3.0f);


    }    

    public void Update()
    {
        if (transform.parent == null)
        {
            //shooted bullet will disappear after 3s if nothing happen
            Destroy(this.gameObject, 3.0f);
        }
    }
}
