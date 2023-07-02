using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplateUI : MonoBehaviour
{
    [SerializeField] GameObject complateFrame;

    public void ShowComplateFrame()
    {
        complateFrame.SetActive(true);
        AudioManager.instance.PlayBGM(AudioManager.instance.CompleteBGM);
    }
    public void HideComplateFrame()
    {
        complateFrame.SetActive(false);
    }
}
