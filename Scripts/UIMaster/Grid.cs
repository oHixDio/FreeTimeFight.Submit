using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] GameObject mainMap;
    [SerializeField] GameObject houseMap;
    [SerializeField] GameObject groundMap;

    void HideAllMap()
    {
        mainMap.SetActive(false);
        houseMap.SetActive(false);
        groundMap.SetActive(false);
    }

    public void ShowMainMap()
    {
        HideAllMap();
        mainMap.SetActive(true);
    }

    public void ShowHouseMap()
    {
        HideAllMap();
        houseMap.SetActive(true);
        groundMap.SetActive(true);
    }
}
