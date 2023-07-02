using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    // Weapon
    TreeBranch,
    WoodenSword,
    PirateSword,
    Axe,
    SilverSword,
    GoldenSword,
    // Armor
    GreenArmor,
    LeatherArmor,
    PirateArmor,
    VikingArmor,
    SilverArmor,
    GordenArmor,
    // Pet
    Slime,
    Spider,
    Zombie,
    Skeleton,

    max
}


public class Item : ScriptableObject
{
    [SerializeField] GameObject objPrefab;
    [SerializeField] string itemName;
    [SerializeField] int itemValue;
    [SerializeField] int itemSklAmount;
    bool isHad;

    public GameObject GetPrefab()
    {
        return objPrefab;
    }

    public string GetName()
    {
        return itemName;
    }

    public int GetValue()
    {
        return itemValue;
    }

    public int GetSklAmount()
    {
        return itemSklAmount;
    }

}
