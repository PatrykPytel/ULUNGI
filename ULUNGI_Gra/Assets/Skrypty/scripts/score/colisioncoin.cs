using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisioncoin : MonoBehaviour
{
    public CoinManager cm;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            Destroy(other.gameObject);
            cm.CoinCount ++;
        }
    }
}
