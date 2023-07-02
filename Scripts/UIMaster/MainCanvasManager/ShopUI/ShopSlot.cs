using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    [SerializeField] InventorySlot inventorySlot;
    public InventorySlot InventorySlot { get { return inventorySlot; } }
    Weapon weapon = null;
    public Weapon Weapon { get { return weapon; } }
    Armor armor = null;
    public Armor Armor { get {  return armor; } }

    [SerializeField] Text nameText;
    [SerializeField] Text valueText;

    void Awake()
    {
        SetType();
    }
    void Update()
    {
        SetText();
    }

    void SetText()
    {
        if (inventorySlot.IsHad)
        {
            nameText.text = "- - -";
            valueText.text = "0";
        }
        else
        {
            nameText.text = inventorySlot.Item.GetName();
            valueText.text = inventorySlot.Item.GetValue().ToString();
        }
        
    }

    void SetType()
    {
        if (inventorySlot.Item is Weapon)
        {
            weapon = (Weapon)inventorySlot.Item;
        }
        if (inventorySlot.Item is Armor)
        {
            armor = (Armor)inventorySlot.Item;
        }
    }

    public void BoughtItem()
    {
        inventorySlot.IsHad = true;
    }
}
