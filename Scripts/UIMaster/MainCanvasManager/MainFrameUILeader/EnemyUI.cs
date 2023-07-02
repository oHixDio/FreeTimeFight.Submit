using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    [SerializeField] GameObject mainFrame;

    [SerializeField] Image faceIcon;
    [SerializeField] Text nameText;
    [SerializeField] Text levelText;
    [SerializeField] Text powText;
    [SerializeField] Text defText;
    [SerializeField] Text spdText;
    [SerializeField] Text lckText;
    [SerializeField] Text hpText;
    [SerializeField] Text maxHPText;



    public void SetUI(Enemy enemy)
    {
        faceIcon.sprite = enemy.GetFaceIcon();
        nameText.text = enemy.GetName();
        hpText.text = enemy.GetEnemyStatus("hp").ToString();
        maxHPText.text = enemy.GetEnemyStatus("maxHp").ToString();
        levelText.text = enemy.GetEnemyStatus("level").ToString();
        powText.text = enemy.GetEnemyStatus("pow").ToString();
        defText.text = enemy.GetEnemyStatus("def").ToString();
        spdText.text = enemy.GetEnemyStatus("spd").ToString();
        lckText.text = enemy.GetEnemyStatus("lck").ToString();
    }


    public void ShowUI()
    {
        mainFrame.SetActive(true);
    }

    public void HideUI()
    {
        mainFrame.SetActive(false);
    }
}
