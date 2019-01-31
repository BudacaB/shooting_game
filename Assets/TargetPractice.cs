using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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

        NotifyUI.SendDamageTakenMessage(calculatedDmg);
        NotifyUI.SendRemainingHealthMessage(this.ToString());
        NotifyUI.SendAttackStatusMessage(weaponDescription);

    }

    private int GetIncomingDamageFrom(int incomingDamage)
    {
        decimal dmgCalculation = incomingDamage * ArmourPercent / 100;
        var totalDmg = incomingDamage - Math.Round(dmgCalculation);
        Debug.Log(totalDmg);
        return Convert.ToInt32(totalDmg);
    }    
}

public class NotifyUI : MonoBehaviour   
{

    public IEnumerator FadeTextToZeroAlpha(float t, TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }

    internal static void SendDamageTakenMessage(int damage)
    {
        GameObject canvasObject = GameObject.FindGameObjectWithTag("Canvas");
        var txtDmgTaken = canvasObject.transform.Find("TextDamageTaken");
        var componentTxtDamageTaken = txtDmgTaken.GetComponent<TextMeshProUGUI>();
        componentTxtDamageTaken.SetText($"{damage}");

        // Need to make this functional again
        //StartCoroutine(FadeTextToZeroAlpha(.2f, componentTxtDamageTaken));
    }

    internal static void SendRemainingHealthMessage (string input)
    {
        GameObject canvasObject = GameObject.FindGameObjectWithTag("Canvas");
        var txtRemainingHealth = canvasObject.transform.Find("TextRemainingHealth");
        var componentTxtRemainingHealth = txtRemainingHealth.GetComponent<TextMeshProUGUI>();
        componentTxtRemainingHealth.SetText(input);
    }
    
    internal static void SendAttackStatusMessage(string weapon)
    {
        GameObject canvasObject = GameObject.FindGameObjectWithTag("Canvas");
        var textAttackStatus = canvasObject.transform.Find("TextAttackStatus");
        var componentTextAttackStatus = textAttackStatus.GetComponent<TextMeshProUGUI>();
        componentTextAttackStatus.SetText(weapon);
    }
}
