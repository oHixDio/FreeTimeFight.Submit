using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// プレイヤーステータスを反映する
public class PlayerStatusUI : MonoBehaviour
{
    [SerializeField] Text playerPowText;
    [SerializeField] Text playerDefText;
    [SerializeField] Text playerSpdText;
    [SerializeField] Text playerLckText;
    [SerializeField] Text playerSklText;
    [SerializeField] Text playerSumEXPText;
    [SerializeField] Text playerNextEXPText;

    // "v" => virtual
    int vPow = 0;
    int vDef = 0;
    int vSpd = 0;
    int vLck = 0;
    int vSkl = 0;
    int vSumEXP = 0;
    int vNextEXP = 0;

    const int MAX_STATUS = 99999999;

    List<int> statusList = new List<int>();

    void Start()
    {
        AddList();
    }

    void Update()
    {
        SetText();
    }

    void AddList()
    {
        statusList.Add(vPow);
        statusList.Add(vDef);
        statusList.Add(vSpd);
        statusList.Add(vLck);
        statusList.Add(vSkl);
        statusList.Add(vSumEXP);
        statusList.Add(vNextEXP);
    }

    // ActorでUpdate
    public void SetAmount(int pow, int def, int spd, int lck, int skl, int sum, int next)
    {
        this.vPow = pow;
        this.vDef = def;
        this.vSpd = spd;
        this.vLck = lck;
        this.vSkl = skl;
        this.vSumEXP = sum;
        this.vNextEXP = next;

        CheckAmount();
    }

    void SetText()
    {
        playerPowText.text = vPow.ToString();
        playerDefText.text = vDef.ToString();
        playerSpdText.text = vSpd.ToString();
        playerLckText.text = vLck.ToString();
        playerSklText.text = vSkl.ToString();
        playerSumEXPText.text = vSumEXP.ToString();
        playerNextEXPText.text= vNextEXP.ToString();
    }

    void CheckAmount()
    {
        for (int i = 0; i < statusList.Count; i++)
        {
            if (statusList[i] > MAX_STATUS)
            {
                statusList[i] = MAX_STATUS;
            }
        }
    }
}
