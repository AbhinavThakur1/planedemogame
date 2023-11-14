using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartUpDown : MonoBehaviour
{
    [SerializeField] Transform rocket;
    
    void Update()
    {
        if (rocket.gameObject.activeSelf)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, rocket.position.y, transform.position.z), 0.2f * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, 20f, transform.position.z);
        }
    }
}
