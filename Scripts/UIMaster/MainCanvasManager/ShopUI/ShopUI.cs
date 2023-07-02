using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShopUI : MonoBehaviour
{
    [SerializeField] GameObject weaponShop;
    [SerializeField] GameObject armorShop;
    [SerializeField] GameObject healHouse;
    [SerializeField] GameObject player;
    [SerializeField] GameObject mapPoint;
    CurrentMap currentMap;
    EnemySpawn enemySpawn;

    void Awake()
    {
        currentMap = mapPoint.GetComponent<CurrentMap>();
        enemySpawn = mapPoint.GetComponent<EnemySpawn>();
    }

    public void HideShopUI()
    {
        weaponShop.SetActive(false);
        armorShop.SetActive(false);
        healHouse.SetActive(false);
    }

    public void ShowHealHouse()
    {
        UIMaster.instance.AreaUI.ShowHouseArea();
        UIMaster.instance.MainManager.HealHouseUI.InTheHealHouse();



        HideMainUI();
        enemySpawn.HideCloneEnemy();
        healHouse.SetActive(true);
        AudioManager.instance.StopBGM();
    }

    public void ShowWeaponShop()
    {
        UIMaster.instance.AreaUI.ShowWeaponArea();

        HideMainUI();
        enemySpawn.HideCloneEnemy();
        weaponShop.SetActive(true);
        AudioManager.instance.StopBGM();
    }

    public void ShowArmorShop()
    {
        UIMaster.instance.AreaUI.ShowArmorArea();

        HideMainUI();
        enemySpawn.HideCloneEnemy();
        armorShop.SetActive(true);
        AudioManager.instance.StopBGM();
    }

    public void ShowMainUI()
    {
        HideShopUI();
        UIMaster.instance.AreaUI.HideAnyArea();
        UIMaster.instance.GridUI.ShowMainMap();
        UIMaster.instance.BackgroundUI.ShowCorrectBG(currentMap);
        UIMaster.instance.WorldObjUI.ShowWorldObj(currentMap);
        enemySpawn.ShowCloneEnemy();
        UIMaster.instance.MainManager.MainFrameLeader.PlayerUI.ShowMainPanel();
        UIMaster.instance.MainManager.MainFrameLeader.SystemButtonUI.HideSystems();

        UIMaster.instance.MainManager.HPFrameUI.gameObject.SetActive(true);
        UIMaster.instance.MainManager.MainFrameLeader.gameObject.SetActive(true);
        UIMaster.instance.MainManager.SystemButtonUI.gameObject.SetActive(true);
        player.SetActive(true);

        AudioManager.instance.PlayBGM(AudioManager.instance.MainBGM);
    }

    void HideMainUI()
    {
        UIMaster.instance.GridUI.ShowHouseMap();
        UIMaster.instance.BackgroundUI.HideAllBG();
        UIMaster.instance.WorldObjUI.HideWorldObj();


        UIMaster.instance.MainManager.HPFrameUI.gameObject.SetActive(false);
        UIMaster.instance.MainManager.MainFrameLeader.gameObject.SetActive(false);
        UIMaster.instance.MainManager.SystemButtonUI.gameObject.SetActive(false);
        player.SetActive(false);
        
    }

}
