using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linerander : MonoBehaviour
{
    public LineRenderer line;
    public Transform pos1;
    public Transform pos2;
    void Start()
    {
        line.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (pos2.gameObject.activeSelf)
        {
            line.enabled = true;
            line.SetPosition(0, pos1.position);
            line.SetPosition(1, pos2.position);
        }
        else
        {
            line.enabled = false;
        }
    }
}
