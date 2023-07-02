using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace GameData
{
    public class PlayerData
    { 
        string playerName        = string.Empty;
        int    playerLevel       = 0;
        int    playerHp          = 0;
        int    playerCurrentHp   = 0;
        int    playerPow         = 0;
        int    playerDef         = 0;
        int    playerSpd         = 0;
        int    playerLck         = 0;
        int    playerSkl         = 0;
        int    playerSumExp      = 0;
        int    playerNextExp     = 0;
        int    playerGold        = 0;
        int    playerStatusPoint = 0;

        public string PlayerName        { get => playerName;        set => playerName        = value; }
        public int    PlayerLevel       { get => playerLevel;       set => playerLevel       = value; }
        public int    PlayerHp          { get => playerHp;          set => playerHp          = value; }
        public int    PlayerCurrentHp   { get => playerCurrentHp;   set => playerCurrentHp   = value; }
        public int    PlayerPow         { get => playerPow;         set => playerPow         = value; }
        public int    PlayerDef         { get => playerDef;         set => playerDef         = value; }
        public int    PlayerSpd         { get => playerSpd;         set => playerSpd         = value; }
        public int    PlayerLck         { get => playerLck;         set => playerLck         = value; }
        public int    PlayerSkl         { get => playerSkl;         set => playerSkl         = value; }
        public int    PlayerSumExp      { get => playerSumExp;      set => playerSumExp      = value; }
        public int    PlayerNextExp     { get => playerNextExp;     set => playerNextExp     = value; }
        public int    PlayerGold        { get => playerGold;        set => playerGold        = value; }
        public int    PlayerStatusPoint { get => playerStatusPoint; set => playerStatusPoint = value; }


        public PlayerData()
        {
            SaveManager.instance.LoadPlayerData(this);
        }

        public void SetPlayerData(SaveData saveData)
        {
            playerName        = saveData.PlayerName;
            playerLevel       = saveData.PlayerLevel;
            playerHp          = saveData.PlayerHp;
            playerCurrentHp   = saveData.PlayerCurrentHp;
            playerPow         = saveData.PlayerPow;
            playerDef         = saveData.PlayerDef;
            playerSpd         = saveData.PlayerSpd;
            playerLck         = saveData.PlayerLck;
            playerSkl         = saveData.PlayerSkl;
            playerSumExp      = saveData.PlayerSumExp;
            playerNextExp     = saveData.PlayerNextExp;
            playerGold        = saveData.PlayerGold;
            playerStatusPoint = saveData.PlayerStatusPoint;
        }

    }

    public class MapData
    {
        int  mapAmount          = 0;
        int  currentMapAmount   = 0;
        int  currentFieldAmount = 0;
        bool isLeftEnd          = false;
        bool isRightEnd         = false;

        public int  MapAmount          { get => mapAmount;          set => mapAmount          = value; }
        public int  CurrentMapAmount   { get => currentMapAmount;   set => currentMapAmount   = value; }
        public int  CurrentFieldAmount { get => currentFieldAmount; set => currentFieldAmount = value; }
        public bool IsLeftEnd          { get => isLeftEnd;          set => isLeftEnd          = value; }
        public bool IsRightEnd         { get => isRightEnd;         set => isRightEnd         = value; }
        
        public MapData()
        {
            SaveManager.instance.LoadMapData(this);
        }
        
        public void SetMapData(SaveData saveData)
        {
            mapAmount          = saveData.MapAmount;
            currentMapAmount   = saveData.CurrentMapAmount;
            currentFieldAmount = saveData.CurrentFieldAmount;
            isLeftEnd          = saveData.IsLeftEnd;
            isRightEnd         = saveData.IsRightEnd;
        }
    }

    public class ItemData
    {
        bool[] hadItems       = new bool[(int)ItemType.max];
        int    hasWeaponIndex = 0;
        int    hasArmorIndex  = 0;
        int    hasPetIndex    = 0;

        public bool[] HadItems       { get => hadItems;       set => hadItems       = value; }                // ƒAƒCƒeƒ€‚Ìæ“¾boolî•ñ
        public int    HasWeaponIndex { get => hasWeaponIndex; set => hasWeaponIndex = value; }                // Š‚µ‚Ä‚¢‚éWeapon‚ÌIndexî•ñ
        public int    HasArmorIndex  { get => hasArmorIndex;  set => hasArmorIndex  = value; }                // Š‚µ‚Ä‚¢‚éArmor‚ÌIndexî•ñ
        public int    HasPetIndex    { get => hasPetIndex;    set => hasPetIndex    = value; }                // Š‚µ‚Ä‚¢‚éPet‚ÌIndexî•ñ

        public ItemData() 
        {
            SaveManager.instance.LoadItemData(this);
        }

        public void SetItemData(SaveData saveData)
        {
            for (int i = 0; i < hadItems.Length; i++)
            {
                hadItems[i] = saveData.HadItems[i];
            }
            hasWeaponIndex = saveData.HasWeaponIndex;
            hasArmorIndex  = saveData.HasArmorIndex;
            hasPetIndex    = saveData.HasPetIndex;
        }
    }
}
