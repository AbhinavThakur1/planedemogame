using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Seconds : MonoBehaviour
{
    [SerializeField] TMP_Text Second;

    public void set()
    {
        Second.text = "|\n " + FindAnyObjectByType<Multiply>().seconds.ToString() + "s";
    }
}
