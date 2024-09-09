using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    
    public bool hasWeapon = false;
    private ItemSO itemSO;
    public GameObject weapon;
    //public Sprite weaponIcon;

   
    // Update is called once per frame
    void Update()
    {
        if(hasWeapon && Input.GetKeyDown(KeyCode.Space) )
        {
            weapon.GetComponent<Weapon>().attack();
        }
    }



    public void LoadWeapon(ItemSO itemSO)
    {
        if (hasWeapon)
        {
            //if already has wepon the unload the old and put the new
            UnLoadWeapon();
            
        }

        //put the current ItemSO
        this.itemSO = itemSO;
        //create the weapon
        weapon = Instantiate(itemSO.prefab);
        string weaponName =itemSO.positionName;
        //put the weapon under the correct position
        weapon.transform.SetParent( this.transform.Find("WeaponList/" + weaponName));

        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.localRotation = Quaternion.identity;
        weapon.transform.GetComponent<Weapon>().weaponIcon = itemSO.icon;
        hasWeapon = true;
       // weaponIcon = itemSO.icon;
        PlayerPropertyUI.Instance.UpdatePlayerPropertyUI();


    }

    public void UnLoadWeapon()
    {
        //put the old weapon back to inventory
        InventoryManager.Instance.AddItem(this.itemSO);
        Destroy(this.weapon);

        this.weapon = null;
    }
}
