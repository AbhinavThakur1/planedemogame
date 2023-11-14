using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMove : MonoBehaviour
{
    public Vector3 startposition = new Vector3(-20f, 25f, 95f);
    bool up;

    void Update()
    {
        if (transform.position.x <= 20f)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(20f, 40f, 95f), 0.3f * Time.deltaTime);
        }
        else if (transform.position.x >= 19)
        {
            if (transform.position.y >= 39f)
            {
                up = false;
            }
            else if (transform.position.y <= 25f)
            {
                up = true;
            }
            if (up)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(20f, 40f, 95f), 0.5f * Time.deltaTime);
            }
            else if (!up)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(20f, 30f, 95f), 0.5f * Time.deltaTime);
            }
        }
    }
}
