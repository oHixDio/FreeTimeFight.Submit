using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="New Weapon", menuName ="Item/Create Weapon")]
public class Weapon : Item
{
    [SerializeField] int weaponPow;
    [SerializeField] Sprite icon;

    public int GetWeaponPow()
    {
        return weaponPow;
    }

    public Sprite GetIcon()
    {
        return icon;
    }
}
