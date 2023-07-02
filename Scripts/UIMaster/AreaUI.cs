using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaUI : MonoBehaviour
{
    [SerializeField] GameObject houseArea;
    [SerializeField] GameObject weaponArea;
    [SerializeField] GameObject armorArea;

    public void HideAnyArea()
    {
        houseArea.SetActive(false);
        weaponArea.SetActive(false);
        armorArea.SetActive(false);
    }

    public void ShowHouseArea()
    {
        houseArea.SetActive(true);
    }

    public void ShowWeaponArea()
    {
        weaponArea.SetActive(true);
    }

    public void ShowArmorArea()
    {
        armorArea.SetActive(true);
    }

    public void ShowAnyArea()
    {
        if (UIMaster.instance.Actor.BesideHouseArea)
        {
            houseArea.SetActive(true);
        }
        else if (UIMaster.instance.Actor.BesideWeaponArea)
        {
            weaponArea.SetActive(true);
        }
        else if (UIMaster.instance.Actor.BesideArmorArea)
        {
            armorArea.SetActive(true);
        }
    }
}
