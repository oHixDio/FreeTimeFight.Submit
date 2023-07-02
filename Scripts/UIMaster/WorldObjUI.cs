using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObjUI : MonoBehaviour
{
    [SerializeField] GameObject firstMapHouse;
    [SerializeField] GameObject weaponShop;
    [SerializeField] GameObject armorShop;
    [SerializeField] GameObject firstWorldObj;
    [SerializeField] GameObject secondWorldObj;
    [SerializeField] GameObject thirdWorldObj;
    [SerializeField] GameObject bossWorldObj;


    int mapAmount;

    public void HideWorldObj()
    {
        firstMapHouse.SetActive(false);
        weaponShop.SetActive(false);
        armorShop.SetActive(false);
        firstWorldObj.SetActive(false);
        secondWorldObj.SetActive(false);
        thirdWorldObj.SetActive(false);
        bossWorldObj.SetActive(false);
    }

    public void ShowWorldObj(CurrentMap map)
    {
        HideWorldObj();

        mapAmount = map.GetMapAmount();

        // ifï∂ÇÃé¿çsèáíçà”

        if (mapAmount == 0 || mapAmount % 10 == 0 && !(mapAmount % 30 == 0))
        {
            firstMapHouse.gameObject.SetActive(true);
            return;
        }
        if (mapAmount % 30 == 0)
        {
            bossWorldObj.gameObject.SetActive(true);
            return;
        }
        else if (mapAmount == 2)
        {
            armorShop.gameObject.SetActive(true);
            return;
        }
        else if (mapAmount == 1)
        {
            weaponShop.gameObject.SetActive(true);
            return;
        }
        else if (mapAmount % 2 == 0 && !(mapAmount == 2))
        {
            secondWorldObj.gameObject.SetActive(true);
            return;
        }
        else if (mapAmount % 3 == 0)
        {
            thirdWorldObj.gameObject.SetActive(true);
            return;
        }
        else
        {
            firstWorldObj.gameObject.SetActive(true);
            return;
        }

    }
}
