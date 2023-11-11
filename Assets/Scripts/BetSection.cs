using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BetSection : MonoBehaviour
{
    [SerializeField] TMP_Text allbets;
    [SerializeField] GameObject view1;
    [SerializeField] GameObject view2;
    [SerializeField] GameObject view3;
    [SerializeField] GameObject view4;
    [SerializeField] GameObject mybets;
    [SerializeField] GameObject toBets;

    void Start()
    {
        for (int i = 0; i <= 30; i++)
        {
            topbetplus();
        }
    }

    public void MybeatSection()
    {
        view1.SetActive(true);
        view2.SetActive(false);
        view3.SetActive(false);
        view4.SetActive(false);
    }

    public void Mylogs()
    {
        view1.SetActive(false);
        view2.SetActive(true);
        view3.SetActive(false);
        view4.SetActive(false);

    }

    public void Topbet()
    {
        view1.SetActive(false);
        view2.SetActive(false);
        view3.SetActive(true);
        view4.SetActive(false);
    }

    public void Previews()
    {
        view1.SetActive(false);
        view2.SetActive(false);
        view3.SetActive(false);
        view4.SetActive(true);
    }
    public void makemybets(float multi,float amount)
    {
        GameObject y = Instantiate(mybets, view2.transform);
        y.GetComponent<mybets>().Moneygotplus(multi,amount);
    }

    public void topbetplus()
    {
        Instantiate(toBets, view3.transform);
    }

    public void AllBetsUp()
    {
        System.Random numer = new System.Random();
        int number = numer.Next(100, 500);
        allbets.text = number.ToString();
    } 
}