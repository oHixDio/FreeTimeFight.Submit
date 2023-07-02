using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventButtonUI : MonoBehaviour
{
    [SerializeField] Actor actor;
    [SerializeField] CurrentMap map;
    [SerializeField] EnemySpawn spn;
    [SerializeField] Text buttonText;

    public void ShowThis()
    {
        gameObject.SetActive(true);
        
    }

    public void HideThis()
    {
        gameObject.SetActive(false);
    }

    public void ShowAnyArea()
    {
        if (actor.BesideHouseArea)
        {
            UIMaster.instance.MainManager.ShopUI.ShowHealHouse();
        }
        if (actor.BesideArmorArea)
        {
            UIMaster.instance.MainManager.ShopUI.ShowArmorShop();
        }
        if (actor.BesideWeaponArea)
        {
            UIMaster.instance.MainManager.ShopUI.ShowWeaponShop();
        }
        if (actor.IsDied || actor.IsKilledBoss)
        {
            UIMaster.instance.MainManager.ComplateUI.HideComplateFrame();
            UIMaster.instance.MainManager.ShopUI.ShowHealHouse();
            actor.FullHelth();
            actor.Revive();
            map.ResetMapAmount();
            spn.CloneEnemyDestroy();
            map.SetEndPoint();
            actor.ResetActorPosition();
        }
        
    }

}
