using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class multiPreviews : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    public void newtext(string Text)
    {
        text.text = Text;
    }

}
