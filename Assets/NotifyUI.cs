using System.Collections;
using TMPro;
using UnityEngine;

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

    internal void SendDamageTakenMessage(int damage)
    {
        GameObject canvasObject = GameObject.FindGameObjectWithTag("Canvas");
        var txtDmgTaken = canvasObject.transform.Find("TextDamageTaken");
        var componentTxtDamageTaken = txtDmgTaken.GetComponent<TextMeshProUGUI>();
        componentTxtDamageTaken.SetText($"{damage}");

        // Need to make this functional again
        this.StartCoroutine(FadeTextToZeroAlpha(.2f, componentTxtDamageTaken));
    }

    internal void SendRemainingHealthMessage (string input)
    {
        GameObject canvasObject = GameObject.FindGameObjectWithTag("Canvas");
        var txtRemainingHealth = canvasObject.transform.Find("TextRemainingHealth");
        var componentTxtRemainingHealth = txtRemainingHealth.GetComponent<TextMeshProUGUI>();
        componentTxtRemainingHealth.SetText(input);
    }
    
    internal void SendAttackStatusMessage(string weapon)
    {
        GameObject canvasObject = GameObject.FindGameObjectWithTag("Canvas");
        var textAttackStatus = canvasObject.transform.Find("TextAttackStatus");
        var componentTextAttackStatus = textAttackStatus.GetComponent<TextMeshProUGUI>();
        componentTextAttackStatus.SetText(weapon);
    }
}
