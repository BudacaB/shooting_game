using Assets.Weaponry;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
    public Transform firePoint;
    public string weaponName;
    public int weaponDamage;
    //public Weapon currentWeapon;
    public Knife currentWeapon;


    private void Start()
    {
        //var ruby = new Augment("Ruby of Potence", AugmentType.Gem);
        //var stoneOfOrin = new Augment("Stone of Orin", AugmentType.Rune);
        //var pebbleOfGods = new Augment("Pebble of Gods", AugmentType.Rune);
        //var augmentList = new List<Augment>() { ruby, stoneOfOrin };
        //this.currentWeapon = new Weapon("Sword", WeaponRarity.Legendary);
        //this.currentWeapon.Augments.AddRange(augmentList);
        //this.weaponDamage = this.currentWeapon.Damage;

        currentWeapon = new Knife();

        weaponDamage = currentWeapon.CalculateDamage();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit2D hit2DInfo = Physics2D.Raycast(firePoint.position, firePoint.right);
           
        if(hit2DInfo)
        {
            TargetPractice targetPractice = hit2DInfo.transform.GetComponent<TargetPractice>();
            if (targetPractice != null)
                targetPractice.TakeDamage(this.weaponDamage, this.currentWeapon.ToString());
        }
    }
}
