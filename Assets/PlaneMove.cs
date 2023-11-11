using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMove : MonoBehaviour
{

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(50, -50, 0), 0.6f * Time.deltaTime);
    }
}
