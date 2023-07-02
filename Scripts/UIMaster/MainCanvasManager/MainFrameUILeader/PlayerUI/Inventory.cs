using GameData;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    InventorySlot[] slots;

    [SerializeField] Transform weaponSlot;

    ItemData itemDate;

    void Awake()
    {
        slots = this.gameObject.GetComponentsInChildren<InventorySlot>();
    }
    void Start()
    {
        itemDate = new ItemData();
        SetSlot();
        
    }

    public void SetSlot()
    {
        for(int i = 0;i< slots.Length;i++)
        {
            slots[i].IsHad = itemDate.HadItems[i];
        }
        slots[0].IsHad = true;
    }

    public void SetWeaponSlots(int num)
    {
        if (!slots[num].IsHad) { return; }

        foreach (Transform child in weaponSlot)
        {
            Destroy(child.gameObject);
        }
        Instantiate(slots[num].GetItemPrefab(), weaponSlot.position, Quaternion.identity, weaponSlot);
    }

    
}

