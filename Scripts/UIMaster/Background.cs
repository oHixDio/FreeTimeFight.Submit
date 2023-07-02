using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] GameObject forestBG;
    [SerializeField] GameObject desertBG;
    [SerializeField] GameObject graveyardBG;
    [SerializeField] GameObject showBG;

    int amount;

    public void HideAllBG()
    {
        forestBG.SetActive(false);
        desertBG.SetActive(false);
        graveyardBG.SetActive(false);
        showBG.SetActive(false);
    }

    public void ShowForestBG()
    {
        HideAllBG();
        forestBG.SetActive(true);
    }

    public void ShowDesertBG()
    {
        HideAllBG();
        desertBG.SetActive(true);
    }

    public void ShowGraveyardBG()
    {
        HideAllBG();
        graveyardBG.SetActive(true);
    }

    public void ShowShowBG()
    {
        HideAllBG();
        showBG.SetActive(true);
    }

    public void ShowCorrectBG(CurrentMap currentMap)
    {
        amount = currentMap.GetCurrentFieldAmount();

        if (amount <= 5)
        {
            ShowForestBG();
        }
        else if (amount <= 10)
        {
            ShowDesertBG();
        }
        else if (amount <= 15)
        {
            ShowGraveyardBG();
        }
        else
        {
            ShowShowBG();
        }
    }
}
