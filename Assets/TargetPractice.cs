using System;
using System.Collections.Generic;
using UnityEngine;

public class TargetPractice : MonoBehaviour
{
    public int Health { get; set; }
    public int ArmourPercent { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        this.Health = 99999999;
        this.ArmourPercent = 34;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override string ToString()
    {
        return $"Target has {this.Health} left";
    }

    internal void TakeDamage(int incomingDamage, string weaponDescription)
    {
        var calculatedDmg = GetIncomingDamageFrom(incomingDamage);
        Console.Write(calculatedDmg);
        this.Health = this.Health - calculatedDmg;

        var uiNotificator = new NotifyUI();

        uiNotificator.SendDamageTakenMessage(calculatedDmg);
        uiNotificator.SendRemainingHealthMessage(this.ToString());
        uiNotificator.SendAttackStatusMessage(weaponDescription);

    }

    private int GetIncomingDamageFrom(int incomingDamage)
    {
        decimal dmgCalculation = incomingDamage * ArmourPercent / 100;
        var totalDmg = incomingDamage - Math.Round(dmgCalculation);
        Debug.Log(totalDmg);
        return Convert.ToInt32(totalDmg);
    }    
}
