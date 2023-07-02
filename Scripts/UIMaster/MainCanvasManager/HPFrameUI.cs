using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HPFrameUI : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] GameObject playerHPFrame;
    [SerializeField] Image playerHPBar;
    [SerializeField] Text playerHPText;
    [SerializeField] Text playerCurrentHPText;
    [SerializeField] Image playerAttackBar;

    [Header("Enemy")]
    [SerializeField] GameObject enemyHPFrame;
    [SerializeField] Image enemyHpBar;
    [SerializeField] Text enemyHpText;
    [SerializeField] Text enemyMaxHPText;
    [SerializeField] Image enemyAttackbar;

    // Actor‚ÅUpdate

    // PlayerHPFrame
    public void SetPlayerHPText(int hp, int currentHP)
    {
        playerHPText.text = hp.ToString();
        playerCurrentHPText.text = currentHP.ToString();
    }
    public void SetPlayerHPbar(int hp, int currentHp)
    {
        float hpAmount = (float)hp / (float)currentHp;
        playerHPBar.fillAmount = hpAmount;
    }
    public void SetPlayerAttackBar(float attackDeleyTime, float maxDeleyAmount)
    {
        if (UIMaster.instance.Actor.Enemy == null)
        {
            playerAttackBar.gameObject.SetActive(false);
        }
        else
        {
            float deleyAmount = attackDeleyTime / maxDeleyAmount;
            playerAttackBar.gameObject.SetActive(true);
            playerAttackBar.fillAmount = deleyAmount;
        }
    }

    public void ShowPlayerHPFrame()
    {
        playerHPFrame.SetActive(true);
    }
    public void HidePlayerHPFrame()
    {
        playerHPFrame.SetActive(false);
    }

    
    public void SetEnemyHPbar(Enemy e)
    {
        int hp = e.GetEnemyStatus("hp");
        int maxHp = e.GetEnemyStatus("maxhp");

        float hpAmount = (float)hp / (float)maxHp;
        enemyHpBar.fillAmount = hpAmount;
    }
    public void SetEnemyAttackBar(Enemy e)
    {
        float attackDeleyTime = e.GetAttackDelayAmount();
        float maxDeleyAmount = e.GetMaxDelayAmount();

        float deleyAmount = attackDeleyTime / maxDeleyAmount;
        enemyAttackbar.fillAmount = deleyAmount;
    }

    public void ShowEnemyHPFrame()
    {
        enemyHPFrame.SetActive(true);
    }
    public void HideEnemyHPFrame()
    {
        enemyHPFrame.SetActive(false);
    }
}
