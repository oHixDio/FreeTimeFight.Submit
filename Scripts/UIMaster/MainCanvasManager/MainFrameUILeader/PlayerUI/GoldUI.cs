using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldUI : MonoBehaviour
{
    [SerializeField] Text goldAmountText;

    const int MAX_AMOUNT = 99999999;

    // Actor‚ÅUpdate
    public void SetText(int gold)
    {
        if(gold > MAX_AMOUNT)
        {
            gold = MAX_AMOUNT;
        }

        goldAmountText.text = gold.ToString();
    }

}
