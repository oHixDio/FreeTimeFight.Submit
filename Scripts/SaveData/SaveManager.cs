using GameData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Unity.VisualScripting;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
        JsonDataLoad();
    }

    [SerializeField] SaveData saveData;

    const string SAVE_KEY = "SAVE_KEY";

    void JsonDataSave()
    {
        string json = JsonUtility.ToJson(saveData);
        PlayerPrefs.SetString(SAVE_KEY, json);
        Debug.Log(json);
    }

    void JsonDataLoad()
    {
        saveData = new SaveData();
        if (PlayerPrefs.HasKey(SAVE_KEY) == true)
        {
            string json = PlayerPrefs.GetString(SAVE_KEY);
            saveData = JsonUtility.FromJson<SaveData>(json);
            Debug.Log(json);
        }

    }

    public void LoadPlayerData(GameData.PlayerData playerData)
    {
        playerData.SetPlayerData(saveData);
    }

    public void LoadMapData(GameData.MapData mapData)
    {
        mapData.SetMapData(saveData);
    }

    public void LoadItemData(GameData.ItemData itemData)
    {
        itemData.SetItemData(saveData);
    }

    public void SavePlayerData(GameData.PlayerData playerData)
    {
        saveData.SetPlayerData(playerData);
        JsonDataSave();
    }

    public void SaveMapData(GameData.MapData mapData)
    {
        saveData.SetMapData(mapData);
        JsonDataSave();
    }

    public void SaveItemData(GameData.ItemData itemData)
    {
        saveData.SetItemData(itemData);
        JsonDataSave();
    }
}


[Serializable]
public class SaveData
{
    public string playerName      = "Ç‰Ç§ÇµÇ·";
    public int playerLevel        = 20;
    public int playerHp           = 100;
    public int playerCurrentHp    = 100;
    public int playerPow          = 5;
    public int playerDef          = 5;
    public int playerSpd          = 5;
    public int playerLck          = 5;
    public int playerSkl          = 20;
    public int playerSumExp       = 0;
    public int playerNextExp      = 10;
    public int playerGold         = 0;
    public int playerStatusPoint  = 100;


    public int mapAmount          = 0;
    public int currentMapAmount   = 0;
    public int currentFieldAmount = 0;
    public bool isLeftEnd         = false;
    public bool isRightEnd        = false;
    public bool[] hadItems        = new bool[(int)ItemType.max];
    public int hasWeaponIndex     = 0;
    public int hasArmorIndex      = 0;
    public int hasPetIndex        = 0;

    public string PlayerName      { get => playerName        ; }
    public int PlayerLevel        { get => playerLevel       ; }
    public int PlayerHp           { get => playerHp          ; }
    public int PlayerCurrentHp    { get => playerCurrentHp   ; }
    public int PlayerPow          { get => playerPow         ; }
    public int PlayerDef          { get => playerDef         ; }
    public int PlayerSpd          { get => playerSpd         ; }
    public int PlayerLck          { get => playerLck         ; }
    public int PlayerSkl          { get => playerSkl         ; }
    public int PlayerSumExp       { get => playerSumExp      ; }
    public int PlayerNextExp      { get => playerNextExp     ; }
    public int PlayerGold         { get => playerGold        ; }
    public int PlayerStatusPoint  { get => playerStatusPoint ; }
    public int MapAmount          { get => mapAmount         ; }
    public int CurrentMapAmount   { get => currentMapAmount  ; }
    public int CurrentFieldAmount { get => currentFieldAmount; }
    public bool IsLeftEnd         { get => isLeftEnd         ; }
    public bool IsRightEnd        { get => isRightEnd        ; }
    public bool[] HadItems        { get => hadItems          ; }                // ÉAÉCÉeÉÄÇÃéÊìæboolèÓïÒ
    public int HasWeaponIndex     { get => hasWeaponIndex    ; }                // èäéùÇµÇƒÇ¢ÇÈWeaponÇÃIndexèÓïÒ
    public int HasArmorIndex      { get => hasArmorIndex     ; }                // èäéùÇµÇƒÇ¢ÇÈArmorÇÃIndexèÓïÒ
    public int HasPetIndex        { get => hasPetIndex       ; }                // èäéùÇµÇƒÇ¢ÇÈPetÇÃIndexèÓïÒ

    public void SetPlayerData(GameData.PlayerData playerData)
    {
        playerName        = playerData.PlayerName;
        playerLevel       = playerData.PlayerLevel;
        playerHp          = playerData.PlayerHp;
        playerCurrentHp   = playerData.PlayerCurrentHp;
        playerPow         = playerData.PlayerPow;
        playerDef         = playerData.PlayerDef;
        playerSpd         = playerData.PlayerSpd;
        playerLck         = playerData.PlayerLck;
        playerSkl         = playerData.PlayerSkl;
        playerSumExp      = playerData.PlayerSumExp;
        playerNextExp     = playerData.PlayerNextExp;
        playerGold        = playerData.PlayerGold;
        playerStatusPoint = playerData.PlayerStatusPoint;
    }

    public void SetMapData(GameData.MapData mapData)
    {
        mapAmount          = mapData.MapAmount;
        currentMapAmount   = mapData.CurrentMapAmount;
        currentFieldAmount = mapData.CurrentFieldAmount;
        isLeftEnd          = mapData.IsLeftEnd;
        isRightEnd         = mapData.IsRightEnd;
    }

    public void SetItemData(GameData.ItemData itemData)
    {
        for (int i = 0; i < hadItems.Length; i++)
        {
            hadItems[i] = itemData.HadItems[i];
        }
        hasWeaponIndex = itemData.HasWeaponIndex;
        hasArmorIndex  = itemData.HasArmorIndex;
        hasPetIndex    = itemData.HasPetIndex;
    }
}
