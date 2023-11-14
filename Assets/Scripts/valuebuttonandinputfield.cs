using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class valuebuttonandinputfield : MonoBehaviour
{
    [SerializeField] public TMP_InputField inputamount;
    [SerializeField] public GameObject betIn;
    [SerializeField] public GameObject cashOut;
    [SerializeField] public GameObject cancelWaiting;
    [SerializeField] public TMP_Text betinAmount;
    [SerializeField] public TMP_Text CashoutMulti;
    [SerializeField] GameObject Auto;
    public static ArrayList list = new ArrayList();
    public static ArrayList amountlist = new ArrayList();
    float stopmulti;
    public float amount;
    bool betin;
    bool cancelbet;
    public bool cashout;
    public int alreadyclicked = 1;
    public bool checkbeintime;
    public bool start = false;
    bool pressed;
    public float cashoutamountforautoplaystop;
    public float decoyloose;
    public float acmountwithmuli;

    void Start()
    {
        inputamount.text = "1.00";
    }
     
    void Update()
    {
        cashout = cashOut.activeSelf;
        betinAmount.text = float.Parse(inputamount.text).ToString() + " USD";
        CashoutMulti.text = Math.Round(double.Parse((float.Parse(inputamount.text)*Multiply.multiply).ToString()),2) + " USD";
        acmountwithmuli = float.Parse(Math.Round(double.Parse((float.Parse(inputamount.text) * Multiply.multiply).ToString()), 2).ToString());
        if (float.Parse(inputamount.text) > 100f)
        {
            inputamount.text = "100.00";
        }
        if (float.Parse(inputamount.text)  < 0f)
        {
            inputamount.text = "0";
        }
    }

    public void One()
    {
        if (float.Parse(inputamount.text) != 100f)
        {
            double v = double.Parse(inputamount.text) + double.Parse("1.00");
            double c = Math.Round(v,2);
            inputamount.text = c.ToString();
        }
    }

    public void Two()
    {
        if (float.Parse(inputamount.text) != 100f)
        {
            double v = double.Parse(inputamount.text) + double.Parse("2.00");
            double c = Math.Round(v, 2);
            inputamount.text = c.ToString();
        }
    }

    public void Five()
    {
        if (float.Parse(inputamount.text) != 100f)
        {
            double v = double.Parse(inputamount.text) + double.Parse("5.00");
            double c = Math.Round(v, 2);
            inputamount.text = c.ToString();
        }
    }

    public void Ten()
    {
        if (float.Parse(inputamount.text) != 100f)
        {
            double v = double.Parse(inputamount.text) + double.Parse("10.00");
            double c = Math.Round(v, 2);
            inputamount.text = c.ToString();
        }
    }

    public void Plus()
    {
        if (float.Parse(inputamount.text) != 100f)
        {
            double v = double.Parse(inputamount.text) + double.Parse("0.1");
            double c = Math.Round(v, 2);
            inputamount.text = c.ToString();
        }
    }

    public void Minus()
    {
        if (float.Parse(inputamount.text) != 0f)
        {
            double v = double.Parse(inputamount.text) - double.Parse("0.1");
            double c = Math.Round(v, 2);
            inputamount.text = c.ToString();
        }
    }

    public void bet()
    {
        Auto.SetActive(false);

    }

    public void onoffauto()
    {
        Auto.SetActive(true);
    }

    public void BetIn()
    {
        start = true;
        pressed = true;
        Multiply.amount -= float.Parse(inputamount.text);
        betin = true;
        amount = float.Parse(inputamount.text);
        if (alreadyclicked == 0)
        {
            decoyloose = amount;
            alreadyclicked = 1;
        }
        if (Multiply.betonoff)
        {
            betIn.SetActive(false);
            cashOut.SetActive(false);
            cancelWaiting.SetActive(true);
            checkbeintime = true;
        }
        else
        {
            betIn.SetActive(false);
            cashOut.SetActive(true);
            cancelWaiting.SetActive(false);
            checkbeintime = false;
        }
    }

    public void CashOut()
    {
        AutoPlayOption.canloose = true;
        start = false;
        stopmulti = Multiply.multiply;
        Multiply.amount += amount * stopmulti;
        cashoutamountforautoplaystop = amount * stopmulti;
        FindAnyObjectByType<BetSection>().makemybets(stopmulti,float.Parse(Math.Round(float.Parse(inputamount.text),2).ToString()));
        cashout = true;
        cancelWaiting.SetActive(false);
        cashOut.SetActive(false);
        pressed = false;
        amount = 0;
        betIn.SetActive(true);
        cashOut.SetActive(false);
        cancelWaiting.SetActive(false);
        decoyloose = 0;
        AutoPlayOption.canloose = false;
    }


    public void Cancel()
    {
        betIn.SetActive(true);
        cashOut.SetActive(false);
        cancelWaiting.SetActive(false);
        AutoPlayOption.canloose = true;
        alreadyclicked = 0;
        pressed = false;
        start = false;
        Multiply.amount += amount;
        cancelbet = true;
        Invoke("cancelfalse", 2f);
        cancelWaiting.SetActive(false);
        amount = 0;
        decoyloose = 0;
        AutoPlayOption.canloose = false;
    }

    public void loose()
    {
        start = false;
        if (pressed)
        {
            FindAnyObjectByType<BetSection>().makemybets(0,0);
        }
        betIn.SetActive(true);
        cashOut.SetActive(false);
        cancelWaiting.SetActive(false);
        amount = 0;
        decoyloose = 0;
        cashOut.SetActive(false);
    }
}
