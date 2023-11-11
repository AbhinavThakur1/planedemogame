using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class AutoPlayOption : MonoBehaviour
{
   
    [SerializeField] Canvas AutoPlayoption;
    [SerializeField] TMP_Text autoleft;
    [SerializeField] Slider autocashouton;
    [SerializeField] Slider decrease;
    [SerializeField] Slider increase;
    [SerializeField] Slider exceeds;
    [SerializeField] TMP_InputField AutoCashOut;
    [SerializeField] TMP_InputField inputdecrease;
    [SerializeField] TMP_InputField inputincrease;
    [SerializeField] TMP_InputField inputexceeds;
    float amount;
    float decreaseamount;
    float increaseamount;
    float exceedamount;
    float decreaseamountbrick = 0f;
    float increaseamountbrick = 0f;
    float exceedamountbrick = 0f;
    static bool starT = false;
    int timestogo = 0;
    public static bool canloose;

    void Start()
    {
        AutoCashOut.text = "1.00";
        inputdecrease.text = "1.00";
        inputincrease.text = "1.00";
        inputexceeds.text = "1.00";
    }

    void Update()
    {
        autoleft.text = timestogo.ToString();
        amount = (float)float.Parse(AutoCashOut.text);
        if (float.Parse(inputdecrease.text) > 100f)
        {
            inputdecrease.text = "100.00";
        }
        if (float.Parse(inputdecrease.text) < 0f)
        {
            inputdecrease.text = "0";
        }
        if (float.Parse(inputincrease.text) > 100f)
        {
            inputincrease.text = "100.00";
        }
        if (float.Parse(inputincrease.text) < 0f)
        {
            inputincrease.text = "0";
        }
        if (float.Parse(inputexceeds.text) > 100f)
        {
            inputexceeds.text = "100.00";
        }
        if (float.Parse(inputexceeds.text) < 0f)
        {
            inputexceeds.text = "0";
        }
        if(increase.value == 1)
        {
            decreaseamount = float.Parse(Math.Round(float.Parse(inputdecrease.text), 2).ToString());
        }
        if (decrease.value == 1)
        {
            increaseamount = float.Parse(Math.Round(float.Parse(inputincrease.text), 2).ToString());
        }
        if (exceeds.value == 1)
        {
            exceedamount = float.Parse(Math.Round(float.Parse(inputexceeds.text), 2).ToString());
        }
        if (autocashouton.value == 1)
        {
            if (Math.Round(float.Parse(AutoCashOut.text),2) <= Math.Round(float.Parse(GetComponent<valuebuttonandinputfield>().inputamount.text) * Multiply.multiply, 2) && GetComponent<valuebuttonandinputfield>().cashOut.activeSelf)
            {
                GetComponent<valuebuttonandinputfield>().CashOut();
            }
            if (starT)
            {
                if (timestogo > 0)
                {
                    if (!GetComponent<valuebuttonandinputfield>().start && canloose)
                    {
                        GetComponent<valuebuttonandinputfield>().inputamount.text = Math.Round(amount,2).ToString();
                        GetComponent<valuebuttonandinputfield>().BetIn();
                        timestogo -= 1;
                        canloose = false;
                    }
                    if (decreaseamountbrick > 0f)
                    {
                        if (Multiply.amount <= decreaseamountbrick)
                        {
                            starT = false;
                            reset();
                        }
                    }
                    if (increaseamountbrick > 0f)
                    {
                        if (Multiply.amount >= increaseamountbrick)
                        {
                            starT = false;
                            reset();
                        }
                    }
                    if (exceedamountbrick > 0f)
                    {
                        if (exceedamountbrick <= GetComponent<valuebuttonandinputfield>().cashoutamountforautoplaystop)
                        {
                            starT = false;
                            reset();
                        }
                    }
                }
            }
        }
    }

    //Repeattime
    public void ten()
    {
        timestogo = 10;
    }

    public void twenty()
    {
        timestogo = 20;
    }

    public void fifty()
    {
        timestogo = 50;
    }

    public void hundred()
    {
        timestogo = 100;
    }

    public void active()
    {
        AutoPlayoption.enabled = true;
    }
    public void close()
    {
        if (!starT)
        {
            timestogo = 0;
        }
        AutoPlayoption.enabled = false;
    }

    public void reset()
    {
        starT = false;
        autocashouton.value = 0;
        decrease.value = 0;
        increase.value = 0;
        exceeds.value = 0;
        AutoCashOut.text = "1.00";
        inputdecrease.text = "1.00";
        inputincrease.text = "1.00";
        inputexceeds.text = "1.00";
        timestogo = 0;
        AutoPlayoption.enabled = false;
    }

    public void start()
    {
        starT = true;
        amount = (float)float.Parse(AutoCashOut.text);
        if(decrease.value == 1)
        {
            decreaseamountbrick =   Multiply.amount - decreaseamount;
        }
        if(increase.value == 1)
        {
            increaseamountbrick = Multiply.amount + increaseamount;
        }
        if(exceeds.value == 1)
        {
            exceedamountbrick = (float)exceedamount;
        }
        AutoPlayoption.enabled = false;
    }

    //valueincreasedecrease
    public void Plusdecrease()
    {
        if (float.Parse(inputdecrease.text) != 100f)
        {
            double v = double.Parse(inputdecrease.text) + double.Parse("0.1");
            double c = Math.Round(v, 2);
            inputdecrease.text = c.ToString();
        }
    }

    public void Minusdecrease()
    {
        if (float.Parse(inputdecrease.text) != 0f)
        {
            double v = double.Parse(inputdecrease.text) - double.Parse("0.1");
            double c = Math.Round(v, 2);
            inputdecrease.text = c.ToString();
        }
    }

    public void Plusincrease()
    {
        if (float.Parse(inputincrease.text) != 100f)
        {
            double v = double.Parse(inputincrease.text) + double.Parse("0.1");
            double c = Math.Round(v, 2);
            inputincrease.text = c.ToString();
        }
    }

    public void Minusincrease()
    {
        if (float.Parse(inputincrease.text) != 0f)
        {
            double v = double.Parse(inputincrease.text) - double.Parse("0.1");
            double c = Math.Round(v, 2);
            inputincrease.text = c.ToString();
        }
    }

    public void Plusexceeds()
    {
        if (float.Parse(inputexceeds.text) != 100f)
        {
            double v = double.Parse(inputexceeds.text) + double.Parse("0.1");
            double c = Math.Round(v, 2);
            inputexceeds.text = c.ToString();
        }
    }

    public void Minusexceeds()
    {
        if (float.Parse(inputexceeds.text) != 0f)
        {
            double v = double.Parse(inputexceeds.text) - double.Parse("0.1");
            double c = Math.Round(v, 2);
            inputexceeds.text = c.ToString();
        }
    }

}
