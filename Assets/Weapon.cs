using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public int weaponDamage;

    private void Start()
    {
        this.weaponDamage = 50;    
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
                targetPractice.TakeDamage(this.weaponDamage);
        }
    }
}
