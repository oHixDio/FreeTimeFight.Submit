using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemButtonUI : MonoBehaviour
{

    [SerializeField] GameObject systemPanel;
    [SerializeField] GameObject levelupPanel;
    [SerializeField] GameObject achievementPanel;

    bool showSystemPanel = false;
    bool showLevelupPanel = false;
    bool showAchievementPanel = false;

    void Update()
    {
        ActiveControll();
    }

    void ActiveControll()
    {
        systemPanel.SetActive(showSystemPanel);
        levelupPanel.SetActive(showLevelupPanel);
        achievementPanel.SetActive(showAchievementPanel);
    }

    // SystemButtonPanel‚ÅŽg‚¤
    public void HideSystems()
    {
        showSystemPanel = false;
        showLevelupPanel = false;
        showAchievementPanel = false;

    }

    public void ShowSystemPanel()
    {
        if (showSystemPanel) 
        {
            HideSystemPanel();
            return;
        }

        HideSystems();

        showSystemPanel = true;

        HideMainUI();
    }
    void HideSystemPanel()
    {
        showSystemPanel = false;

        ShowMainUI();
    }

    public void ShowLevelupPanel()
    {
        if (showLevelupPanel) 
        {
            HideLevelupPanel();
            return ;
        }

        HideSystems();

        showLevelupPanel = true;

        HideMainUI();
    }
    void HideLevelupPanel()
    {
        showLevelupPanel = false;

        ShowMainUI();
    }

    public void ShowAchievementPanel()
    {
        if (showAchievementPanel)
        {
            HideShowAchievementPanel();
            return ;
        }

        HideSystems();

        showAchievementPanel = true;

        HideMainUI();
    }
    void HideShowAchievementPanel()
    {
        showAchievementPanel = false;

        ShowMainUI();
    }

    public void ShowMainUI()
    {

        UIMaster.instance.MainManager.MainFrameLeader.PlayerUI.ShowMainPanel();

        if (UIMaster.instance.Actor.BesideArmorArea ||
           UIMaster.instance.Actor.BesideWeaponArea ||
           UIMaster.instance.Actor.BesideHouseArea)
        {
            UIMaster.instance.MainManager.MainFrameLeader.PlayerUI.ShowEventPanel();
        }

        if (UIMaster.instance.Actor.Enemy != null)
        {
            UIMaster.instance.MainManager.MainFrameLeader.EnemyUI.ShowUI();
            UIMaster.instance.MainManager.HPFrameUI.ShowEnemyHPFrame();
            UIMaster.instance.MainManager.MainFrameLeader.PlayerUI.HideStatusPanel();
        }   
    }
    void HideMainUI()
    {
        UIMaster.instance.MainManager.MainFrameLeader.PlayerUI.HidePlayerUI();
        if (UIMaster.instance.Actor.Enemy != null)
        {
            UIMaster.instance.MainManager.MainFrameLeader.EnemyUI.HideUI();
        }
    }

}
