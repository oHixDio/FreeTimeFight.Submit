using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] GameObject playerInfoPanel;
    [SerializeField] GameObject weaponInventory;
    [SerializeField] GameObject armorInventory;
    [SerializeField] GameObject petInventory;

    // Button Methods
    public void ShowWeaponInventory()
    {
        playerInfoPanel.SetActive(false);
        weaponInventory.SetActive(true);
    }

    public void ShowArmorInventory()
    {
        playerInfoPanel.SetActive(false);
        armorInventory.SetActive(true);
    }

    public void ShowPetInventory()
    {
        playerInfoPanel.SetActive(false);
        petInventory.SetActive(true);
    }

    public void HideInventory()
    {
        playerInfoPanel.SetActive(true);
        weaponInventory.SetActive(false);
        armorInventory.SetActive(false);
        petInventory.SetActive(true);
    }
}
