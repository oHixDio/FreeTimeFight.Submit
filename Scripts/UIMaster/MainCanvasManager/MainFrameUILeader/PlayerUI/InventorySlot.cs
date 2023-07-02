using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] Item item;
    public Item Item{ get { return item; } }

    bool isHad = false;
    public bool IsHad
    {
        get { return isHad; }
        set { isHad = value; }
    }

    Text slotName;

    private void Awake()
    {
        slotName = GetComponentInChildren<Text>();
    }
    private void Update()
    {
        SetName();
    }

    public void SetName()
    {
        if (isHad)
        {
            slotName.text = item.GetName();
        }
        else
        {
            slotName.text = "- - -";
        }
        
    }
    
    
    public GameObject GetItemPrefab()
    {
        return item.GetPrefab();
    }
   
}
