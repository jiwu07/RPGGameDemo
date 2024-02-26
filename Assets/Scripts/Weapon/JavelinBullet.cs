using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavelinBullet : MonoBehaviour
{
    private Rigidbody rgd;
    private Collider cld; 
    // Start is called before the first frame update
    private void Start()
    {
        rgd = GetComponent<Rigidbody>();
        cld = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.collider.tag == Tag.PLAYER)
        {
            return;
        }
        rgd.velocity = Vector3.zero;
        rgd.isKinematic = false;
        cld.enabled = false;

        Destroy(this.gameObject, 1.0f);


    }    
    
}
