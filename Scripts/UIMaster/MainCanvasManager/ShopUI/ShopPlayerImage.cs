using Cainos.CustomizablePixelCharacter;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShopPlayerImage : MonoBehaviour
{
    [SerializeField] Transform weaponSlot;

    [SerializeField] PixelCharacter character;


    public void SetWeaponSlot(GameObject obj)
    {

        foreach (Transform child in weaponSlot)
        {
            Destroy(child.gameObject);
        }
        Instantiate(obj, weaponSlot.position, Quaternion.identity, weaponSlot);
    }

}
