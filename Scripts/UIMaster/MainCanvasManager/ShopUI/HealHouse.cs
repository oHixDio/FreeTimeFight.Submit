using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealHouse : MonoBehaviour
{
    [SerializeField] Text chatText;
    [SerializeField] Text mainText;
    [SerializeField] Text leftButtonText;
    [SerializeField] Text rightButtonText;

    [SerializeField] GameObject player;
    Actor actor;

    int randomSentence;
    
    string[] chatSentence = 
    {
        "ここは宿屋です\n休憩しますか？",
        "体力がないと\n何もできません。",
        "ひと休み\nいかがでしょうか。"   
    };

    string[] mainSentence =
    {
        "悪い魔物を倒してきて\n親玉がいるって聞いたよ\n安心して、進んだ先でも\n休憩できるよ",
        "いつでもステータスを\n変更できるよ。増やしたり\n減らしたり、自由に変えて\n好きなように調整しよう",
        "マップを進めば進むほど\n敵はどんどん強くなるよ\nレベルアップしたらステータスを\n増やして強くなろう",
        "実績を解除したら王冠が手に入るよ\n全部コンプリートするのは\n大変だけど、達成を目指して\n頑張ってみよう"
    };

    string leftSentence = "外に出る";
    string rightSentence = "体力を\n全回復";

    void Awake()
    {
        actor = player.GetComponent<Actor>();
    }
    void Start()
    {
        SetText();
    }
    void OnEnable()
    {
        ChangeChatText();
        ChangeMainText();
    }

    void SetText()
    {
        randomSentence = Random.Range(0, chatSentence.Length);
        chatText.text = chatSentence[randomSentence];

        randomSentence = Random.Range(0, mainSentence.Length);
        mainText.text = mainSentence[randomSentence];

        leftButtonText.text = leftSentence;
        rightButtonText.text = rightSentence;
    }

    void ChangeChatText()
    {
        randomSentence = Random.Range(0, chatSentence.Length);
        chatText.text = chatSentence[randomSentence];
    }

    public void ChangeMainText()
    {
        randomSentence = Random.Range(0, mainSentence.Length);
        mainText.text = mainSentence[randomSentence];
    }


    public void HealButton()
    {
        actor.FullHelth();
    }

    public void GoOutHouseButton()
    {
        UIMaster.instance.MainManager.ShopUI.ShowMainUI();
    }

    public void InTheHealHouse()
    {
        ChangeChatText();
        ChangeMainText();
    }
}
