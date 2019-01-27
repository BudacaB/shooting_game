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
        this.Health = this.Health - calculatedDmg;
        
        GameObject canvasObject = GameObject.FindGameObjectWithTag("Canvas");
        var txtDmgTaken = canvasObject.transform.Find("TextDamageTaken");
        var componentTxtDaamgetaken = txtDmgTaken.GetComponent<TextMeshProUGUI>();
        componentTxtDaamgetaken.SetText($"{calculatedDmg}");

        StartCoroutine(FadeTextToZeroAlpha(.2f, componentTxtDaamgetaken));

        var txtRemainingHealth = canvasObject.transform.Find("TextRemainingHealth");
        var componentTxtRemainingHealth = txtRemainingHealth.GetComponent<TextMeshProUGUI>();
        componentTxtRemainingHealth.SetText(this.ToString());

        var textAttackStatus = canvasObject.transform.Find("TextAttackStatus");
        var componentTextAttackStatus = textAttackStatus.GetComponent<TextMeshProUGUI>();
        componentTextAttackStatus.SetText(weaponDescription);

    }

    private int GetIncomingDamageFrom(int incomingDamage)
    {
        decimal dmgCalculation = incomingDamage * ArmourPercent / 100;
        var totalDmg = incomingDamage - Math.Round(dmgCalculation);
        Debug.Log(totalDmg);
        return Convert.ToInt32(totalDmg);
    }   

    public IEnumerator FadeTextToZeroAlpha(float t, TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
}
