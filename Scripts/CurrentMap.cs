using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;
using GameData;

public class CurrentMap : MonoBehaviour
{
    [SerializeField] GameObject rightSpawnPoint;
    [SerializeField] GameObject leftSpawnPoint;
    [SerializeField] GameObject rightEndPoint;
    [SerializeField] GameObject leftEndPoint;

    MapData mapData;

    private void Awake()
    {
        mapData = new MapData();
    }
    void Update()
    {
        SetSpawnPoint();
    }

    public void MapFloorChange(int playerDirection)
    {
        if (playerDirection == 1)
        {
            mapData.MapAmount++;
            mapData.CurrentMapAmount++;

            if(mapData.CurrentMapAmount == 30)
            {
                AudioManager.instance.PlayBGM(AudioManager.instance.BossBGM);
            }

        }
        else if (playerDirection == -1)
        {
            if (mapData.MapAmount > 0)
            {
                mapData.MapAmount--;
                mapData.CurrentMapAmount--;
            }
            else
            {
                mapData.MapAmount = 0;
                mapData.CurrentMapAmount = 0;
            }
        }
        SaveMapData();
    }

    public void CurrentFieldAmountIncrement()
    {
        if(mapData.CurrentFieldAmount < 5)
        {
            mapData.CurrentFieldAmount++; 
        }
        else 
        {
            CurrentMapAmountMinus(); 
        }
        SaveMapData();
    }

    public void CurrentMapAmountMinus()
    {
        mapData.CurrentMapAmount -= mapData.MapAmount; 
    }

    public void ResetMapAmount()
    {
        CurrentMapAmountMinus();
        mapData.MapAmount = 0;
        SaveMapData();
    }

    public int GetMapAmount()
    {
        return mapData.MapAmount;
    }
    public int GetCurrentMapAmount()
    {
        return mapData.CurrentMapAmount;
    }
    public int GetCurrentFieldAmount()
    {
        return mapData.CurrentFieldAmount;
    }


    // ----------MapEnd---------- //
    void SetSpawnPoint()
    {
        rightEndPoint.SetActive(mapData.IsRightEnd);
        leftEndPoint.gameObject.SetActive(mapData.IsLeftEnd);
    }

    public void SetEndPoint()
    {

        mapData.IsLeftEnd = false;
        mapData.IsRightEnd = false;

        if (mapData.MapAmount == 0)
        {
            mapData.IsLeftEnd = true;
        }

        if (mapData.MapAmount == 30)
        {
            mapData.IsRightEnd = true;
        }
        SaveMapData();
    }
    

    public void SpawnPlayer(GameObject player, int num)
    {
        if (num == 1)
        {
            player.transform.position = leftSpawnPoint.transform.position;
        }
        else if (num == -1)
        {
            player.transform.position = rightSpawnPoint.transform.position;
        }
    }

    void SaveMapData()
    {
        SaveManager.instance.SaveMapData(mapData);
    }
    
}
