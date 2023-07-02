using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TitleUI : MonoBehaviour
{
    [SerializeField] GameObject title;
    [SerializeField] GameObject player;

    [SerializeField] GameObject grid;
    [SerializeField] GameObject bgUI;
    [SerializeField] GameObject mainCanvas;
    [SerializeField] GameObject areaUI;
    [SerializeField] GameObject worldObjUI;

    void OnEnable()
    {
        Invoke("HideTitle", 2f);
    }
    void OnDisable()
    {
        ShowUI();
    }

    public void ShowTitle()
    {
        title.SetActive(true);
    }

    void HideTitle()
    {
        title.SetActive(false);
        player.SetActive(true);
    }

    void ShowUI()
    {
        grid.SetActive(true);
        bgUI.SetActive(true);
        mainCanvas.SetActive(true);
        areaUI.SetActive(true);
        worldObjUI.SetActive(true);

        AudioManager.instance.PlayBGM(AudioManager.instance.MainBGM);
    }
}
