using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class mybets : MonoBehaviour
{
    [SerializeField] TMP_Text Name;
    [SerializeField] TMP_Text MoneyGot;
    [SerializeField] TMP_Text Multiplay;
    [SerializeField] GameObject multibg;
    [SerializeField] TMP_Text money;

    void Start()
    {
        Name.text = "d***1";
    }

    public void Moneygotplus(float multiplay,float amount)
    {
        multibg.SetActive(true);
        money.text = Math.Round(amount,2).ToString();
        Multiplay.text = Math.Round(multiplay, 2).ToString() + "x";
        MoneyGot.text = (Math.Round(amount * multiplay,2)).ToString();
    }
}
