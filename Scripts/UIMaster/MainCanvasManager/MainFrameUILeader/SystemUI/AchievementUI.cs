using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementUI : MonoBehaviour
{
    [SerializeField] List<Text> achievementTexts;
    [SerializeField] List<Text> valueAmountTexts;
    [SerializeField] List<Text> firstBreakAmountTexts;
    [SerializeField] List<Text> secondBreakAmountTexts;
    [SerializeField] List<Text> thirdBreakAmountTexts;
    [SerializeField] List<GameObject> firstClownIcons;
    [SerializeField] List<GameObject> secondClownIcons;
    [SerializeField] List<GameObject> thirdClownIcons;
    [SerializeField] List<Achievements> achievements;

    [SerializeField] int firstValueAmount = 0;
    [SerializeField] int secondValueAmount = 0;
    [SerializeField] int thirdValueAmount = 0;
    [SerializeField] int fourthValueAmount = 0;
    [SerializeField] int fifthValueAmount = 0;
    [SerializeField] int sixthValueAmount = 0;
    List<int> currentValueAmount = new List<int>();

    [SerializeField] GameObject player;
    Actor actor;

    void Awake()
    {
        SetCurrentvalueAmountList();
        actor = player.GetComponent<Actor>();
    }
    void Start()
    {
        SetAchievement();
    }
    void Update()
    {
        BreakAmountChacker();
    }

    void SetCurrentvalueAmountList()
    {
        currentValueAmount.Add(firstValueAmount);
        currentValueAmount.Add(secondValueAmount);
        currentValueAmount.Add(thirdValueAmount);
        currentValueAmount.Add(fourthValueAmount);
        currentValueAmount.Add(fifthValueAmount);
        currentValueAmount.Add(sixthValueAmount);
    }

    void SetAchievement()
    {
        for (int i = 0; i < achievements.Count; i++)
        {
            achievementTexts[i].text = achievements[i].GetAchievementTextLine();
            valueAmountTexts[i].text = currentValueAmount[i].ToString();
            firstBreakAmountTexts[i].text = achievements[i].GetFirstBreakValueAmount().ToString();
            secondBreakAmountTexts[i].text = achievements[i].GetSecondBreakValueAmount().ToString();
            thirdBreakAmountTexts[i].text = achievements[i].GetThirdBreakValueAmount().ToString();
            firstClownIcons[i].SetActive(false);
            secondClownIcons[i].SetActive(false);
            thirdClownIcons[i].SetActive(false);
        }
    } 

    void BreakAmountChacker()
    {

        for (int i = 0; i < achievements.Count; i++)
        {
            valueAmountTexts[i].text = currentValueAmount[i].ToString();

            if (achievements[i].GetFirstBreakValueAmount() <= currentValueAmount[i])
            {
                firstClownIcons[i].SetActive(true);
            }
            if (achievements[i].GetSecondBreakValueAmount() <= currentValueAmount[i])
            {
                secondClownIcons[i].SetActive(true);
            }
            if (achievements[i].GetThirdBreakValueAmount() <= currentValueAmount[i])
            {
                thirdClownIcons[i].SetActive(true);
            }
        }
    }

    void SetCurrentValueAmount()
    {
        // TODO actor‚©‚çƒLƒ‹”Žæ“¾‚·‚é
        //firstValueAmount = actor.
    }
}
