using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToHouse : MonoBehaviour
{
    [SerializeField] GameObject backToHouseFrame;
    [SerializeField] GameObject pressedBackToHouseFrame;

    [SerializeField] GameObject mapPoint;

    CurrentMap currentMap;
    EnemySpawn enemySpawn;

    bool isNonePressedFrame = false;
    bool isPressedFrame = false;

    void Awake()
    {
        currentMap = mapPoint.GetComponent<CurrentMap>();
        enemySpawn = mapPoint.GetComponent<EnemySpawn>();
    }
    void Start()
    {
        isNonePressedFrame = true;
        isPressedFrame = false;
    }
    void Update()
    {
        ShowBackToHouseButton();
    }

    void ShowBackToHouseButton()
    {
        backToHouseFrame.SetActive(isNonePressedFrame);
        pressedBackToHouseFrame.SetActive(isPressedFrame);
    }

    public void BackToHouseButton()
    {
        isNonePressedFrame = false;
        isPressedFrame = true;
        // uiAudio.SystemButtonSE();
    }

    public void NoBackToHouse()
    {
        isNonePressedFrame = true;
        isPressedFrame = false;
        // uiAudio.SystemButtonSE();
    }

    public void YesBackToHouse()
    {
        if (UIMaster.instance.Actor.IsDied || UIMaster.instance.Actor.IsKilledBoss)
        {
            // uiAudio.SystemErrorSE();
            return;
        }

        isNonePressedFrame = true;
        isPressedFrame = false;

        currentMap.ResetMapAmount();
        enemySpawn.CloneEnemyDestroy();

        UIMaster.instance.Actor.ResetActorPosition();

        UIMaster.instance.MainManager.ShopUI.ShowHealHouse();
        // ‰¹Šy
        //uiAudio.StopBGM();
        //uiAudio.SystemButtonSE();
    }

    

    
}
