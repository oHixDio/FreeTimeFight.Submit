using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Manager‚Ì‹@”\‰„’·”Å
public class MainFrameLeader : MonoBehaviour
{

    [SerializeField] EventUI eventUI;
    public EventUI EventUI { get { return eventUI; } }

    [SerializeField] InfoPanelUI infoPanelUI;
    public InfoPanelUI InfoPanelUI { get { return infoPanelUI; } }

    [Header("PlayerUI")]
    [SerializeField] PlayerUI playerUI;
    public PlayerUI PlayerUI { get { return playerUI; } }

    [SerializeField] PlayerInfoUI playerInfoUI;
    public PlayerInfoUI PlayerInfoUI { get { return playerInfoUI; } }

    [SerializeField] PlayerStatusUI playerStatusUI;
    public PlayerStatusUI PlayerStatusUI { get { return playerStatusUI; } }

    [SerializeField] EventButtonUI eventButtonUI;
    public EventButtonUI EventButtonUI { get { return eventButtonUI; } }

    [SerializeField] GoldUI goldUI;
    public GoldUI GoldUI { get { return goldUI; } }

    [Header("SystemUI")]
    [SerializeField] SystemButtonUI systemButtonUI;
    public SystemButtonUI SystemButtonUI { get { return systemButtonUI; } }

    [SerializeField] LevelupPanel levelupPanelUI;
    public LevelupPanel LevelupPanelUI { get { return levelupPanelUI; } }

    [SerializeField] AchievementUI achievementUI;
    public AchievementUI AchievementUI { get { return achievementUI; } }

    [Header("EnemyUI")]
    [SerializeField] EnemyUI enemyUI;
    public EnemyUI EnemyUI { get { return enemyUI; } }
}
