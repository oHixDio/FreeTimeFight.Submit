using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Item
{
    [SerializeField] int defAmount;

    public int GetDefAmount()
    {
        return defAmount;
    }
}
