using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Multiply : MonoBehaviour
{
    [SerializeField] GameObject mutliplaybarobject;
    [SerializeField] GameObject secondbarobject;
    [SerializeField] Transform mutliplaybarlocation;
    [SerializeField] Transform secondbarlocation;
    public float mutliplyvalueobj = 1.80f;
    public int seconds = 5;
    public static float amount = 30000;
    public static float multiply=0;
    [SerializeField] TMP_Text amounttext;
    float value;
    bool next = true;
    [SerializeField] GameObject bets;
    [SerializeField] GameObject previews;
    [SerializeField] Transform locationscroll;
    [SerializeField] Transform locationpreviews;
    [SerializeField] TMP_Text MultitextPlane;
    public static bool betonoff = false;
    [SerializeField] Transform multiscroll;
    [SerializeField] GameObject multi;
    [SerializeField] GameObject plane;
    float elapsedtime;
    public static bool countit = false;
    float change = 0f;
    float multitime = 0;
    float j = 0;
    float k = 1.00f;
    public static bool beting;
    float secondcount;
    int thesecondcount;

    void Start()
    {
        Application.targetFrameRate = 90;
    }

    void Update()
    {
        secondcount += Time.deltaTime;
        amounttext.text = amount.ToString() + " USD";
        if (multiply >= k)
        {
            k += 0.20f;
            mutliplyvalueobj = float.Parse(Math.Round(mutliplyvalueobj + float.Parse("0.20"), 2).ToString());
            GameObject i = Instantiate(mutliplaybarobject, mutliplaybarlocation);
            i.GetComponent<multivalue>().set();
        }
        if (next)
        {
            change = 0;
            foreach (GameObject i in GameObject.FindGameObjectsWithTag("Multi"))
            {
                Destroy(i);
            }
            foreach (GameObject i in GameObject.FindGameObjectsWithTag("Seconds"))
            {
                Destroy(i);
            }
            j = 0;
            beting = true;
            plane.SetActive(true);
            System.Random va = new System.Random();
            int num = va.Next(0, 3);
            if (num == 0)
            {
                value = UnityEngine.Random.Range(10f, 20f);
                multitime = 0.02f;
            }
            if (num == 1)
            {
                value = UnityEngine.Random.Range(5f, 15f);
                multitime = 0.04f;
            }
            if (num == 2)
            {
                value = UnityEngine.Random.Range(0f, 10f);
                multitime = 0.04f;
            }
            if (num == 3)
            {
                value = UnityEngine.Random.Range(0f, 1f);
                multitime = 0.7f;
            }
            
            next = false;
            for(int i = 0; i<= 30; i++)
            {
                Instantiate(bets, locationscroll);
                Instantiate(previews, locationpreviews);
            }
        }
        else if(!next && multiply <= value)
        {
            thesecondcount = Mathf.FloorToInt(secondcount % 60);
            if (thesecondcount == j)
            {
                j++;
                seconds += 1;
                GameObject i = Instantiate(secondbarobject, secondbarlocation);
                i.GetComponent<Seconds>().set();
            }
            betonoff = true;
            multiply += Mathf.Lerp(0f, value, multitime * Time.deltaTime);
            MultitextPlane.text = Math.Round(multiply, 2).ToString() + "x";
        }
        if (countit)
        {
            if (change != value)
            {
                GameObject multiplymulti = Instantiate(multi, multiscroll);
                multiplymulti.GetComponent<multiPreviews>().newtext(Math.Round(value, 2).ToString() + "x");
                change = value;
            }
            elapsedtime -= Time.deltaTime;
            int time = Mathf.FloorToInt(elapsedtime % 60);
            if (time >= 0 && time < 10)
            {
                MultitextPlane.text = "Starting in " + time.ToString();
            }else if (time > 10)
            {
                MultitextPlane.text = "Flew away";
            }
            if (elapsedtime <= 0)
            {
                foreach (valuebuttonandinputfield i in GameObject.FindObjectsByType<valuebuttonandinputfield>(FindObjectsSortMode.None))
                {
                    if (!i.checkbeintime)
                    {
                        i.loose();
                    }
                    else
                    {
                        i.cashOut.SetActive(true);
                        i.cancelWaiting.SetActive(false);
                        i.betIn.SetActive(false);
                        i.checkbeintime = false;
                    }
                }
                secondcount = 0;
                countit = false;
                elapsedtime = 0f;
                setnextture();
            }
        }
        if (multiply >= value)
        {
            plane.transform.position = plane.GetComponent<PlaneMove>().startposition;
            AutoPlayOption.canloose = true;
            beting = false;
            foreach (valuebuttonandinputfield i in GameObject.FindObjectsByType<valuebuttonandinputfield>(FindObjectsSortMode.None))
            {
                if (i.cashout)
                {
                    i.loose();
                }
            }
            countit = true;
            plane.SetActive(false);
        }
        else
        {
            countit = false;
            elapsedtime = 15f;
        }
    }

    void setnextture()
    {
        FindAnyObjectByType<BetSection>().AllBetsUp();
        foreach (valuebuttonandinputfield i in GameObject.FindObjectsByType<valuebuttonandinputfield>(FindObjectsSortMode.None))
        {
            i.cancelWaiting.SetActive(false);
        }
        next = true;
        multiply = 0f;
        foreach (GameObject bet in GameObject.FindGameObjectsWithTag("bets"))
        {
            Destroy(bet);
        }
    }
}