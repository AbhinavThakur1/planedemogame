using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class topbets : MonoBehaviour
{
    [SerializeField] TMP_Text Name;
    [SerializeField] TMP_Text MoneyGot;
    [SerializeField] TMP_Text Multiplay;
    [SerializeField] GameObject multibg;
    System.Random rnd = new System.Random();
    float value;

    void Start()
    {
        Name.text = "d***" + rnd.Next(100).ToString();
        value = UnityEngine.Random.Range(16f, 100f);
        Moneygotplus(value);
    }

    public void Moneygotplus(float multiplay)
    {
        multibg.SetActive(true);
        Multiplay.text = Math.Round(multiplay, 2).ToString() + "x";
        MoneyGot.text = (100 + (int)(100f * multiplay)).ToString();
    }
}
