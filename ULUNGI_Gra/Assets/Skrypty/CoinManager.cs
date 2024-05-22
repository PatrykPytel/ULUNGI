using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int CoinCount;
    public TMP_Text coinText;

    public void Score()
    {
        
        coinText.text = "Coin Count: " + CoinCount.ToString();
    }

}
