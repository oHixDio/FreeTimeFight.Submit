using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelupPanel : MonoBehaviour
{
    [SerializeField] Text systemPowText;
    [SerializeField] Text systemDefText;
    [SerializeField] Text systemSpdText;
    [SerializeField] Text systemLckText;
    [SerializeField] Text systemSklText;
    [SerializeField] Text systemcurrentHpText;
    [SerializeField] Text systemStatusAddPointText;

    const int MAX_NORMAL = 250;
    const int MAX_EXTRA = 1270;
    const int MAX_ADDPOINT = 99999;
    

    // "s"ystem
    int sPow = 0;
    int sDef = 0;
    int sSpd = 0;
    int sLck = 0;
    int sSkl = 0;
    int sCurrentHp = 0;
    int sAddPoint = 0;

    List<int> normalStatusList = new List<int>();
    List<int> extraStatusList = new List<int>();


    private void Start()
    {
        SetList();
    }
    void Update()
    {
        SetText();
    }

    void SetList()
    {
        normalStatusList.Add(sPow);
        normalStatusList.Add(sDef);
        normalStatusList.Add(sSpd);
        normalStatusList.Add(sLck);
        extraStatusList.Add(sSkl);
        extraStatusList.Add(sCurrentHp);
    }

    public void SetAmount(int pow,int def,int spd,int lck,int skl,int currentHp,int addPoint)
    {
        sPow = pow;
        sDef = def;
        sSpd = spd;
        sLck = lck;
        sSkl = skl;
        sCurrentHp = currentHp;
        sAddPoint = addPoint;

        //CheckAmount();
    }

    void SetText()
    {
        systemPowText.text = sPow.ToString();
        systemDefText.text = sDef.ToString();
        systemSpdText.text = sSpd.ToString();
        systemLckText.text = sLck.ToString();
        systemSklText.text = sSkl.ToString();
        systemcurrentHpText.text = sCurrentHp.ToString();
        systemStatusAddPointText.text = sAddPoint.ToString();
    }

    void CheckAmount()
    {
        for (int i = 0; i < normalStatusList.Count; i++)
        {
            if (normalStatusList[i] > MAX_NORMAL)
            {
                normalStatusList[i] = MAX_NORMAL;
            }
        }

        for (int i = 0; i < extraStatusList.Count; i++)
        {
            if (extraStatusList[i] > MAX_EXTRA)
            {
                extraStatusList[i] = MAX_EXTRA;
            }
        }

        if(sAddPoint > MAX_ADDPOINT)
        {
            sAddPoint = MAX_ADDPOINT;
        }

    }

    public void MinusButton(string status)
    {
        
        UIMaster.instance.Actor.DownStatus(status);
    }

    public void PlusButton(string status)
    {
        UIMaster.instance.Actor.UpStatus(status);
    }
}
