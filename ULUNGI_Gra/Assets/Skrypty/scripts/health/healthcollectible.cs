using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthcollectible : MonoBehaviour
{
    public float healthvalue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="player")
        {
            collision.GetComponent<health>().AddHealth(healthvalue);
            gameObject.SetActive(false);
        }
    }
}
