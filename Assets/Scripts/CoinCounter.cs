using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{

    public TextMeshProUGUI counter;

    private void Update()
    {
        counter.text = ResourceTracker.Gold.ToString();
    }
}
