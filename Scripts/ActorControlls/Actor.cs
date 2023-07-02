using Cainos.CustomizablePixelCharacter;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using GameData;

public class Actor : MonoBehaviour
{
    

    [Header("Status")]
    [SerializeField] Sprite faceIcon;

    PlayerData playerData;

    int maxLevel  = 1250;
    int maxHp     = 2000;
    int maxPow    = 250;
    int maxDef    = 250;
    int maxSpd    = 250;
    int maxLck    = 250;
    int maxskl    = 1250;

    int         weaponPow         = 3;
    int         damageAmount      = 0;
    int         criticalDamage    = 0;
    int         DefenseAmount     = 0;
    float       maxMobility       = 4f;
    float       Mobility          = 0f;
    float       attackDelayAmount = 0f;
    const float minDelayTime      = 0.3f;
    float       maxDelayAmount    = 5f;
    
    // ahievement Amount
    int slimeKillAmount = 0;
    int bossKillAmount  = 0;

    [Header("Other")]
    [SerializeField] GameObject uiMasterObj;
    [SerializeField] GameObject mapPoint;

    // component
    PixelCharacter pixcelCharactor = null;
    UIMaster       uiMaster        = null;
    CurrentMap     currentMap      = null;
    EnemySpawn     enemySpawn      = null;
    Enemy          enemy           = null;
    public Enemy Enemy { get => enemy; }

    // collisionで使用
    const int right = 1;
    const int left  = -1;

    
    #region ---プロパティ
    bool isMove           = false;
    bool isRight          = false;
    bool isLeft           = false;
    bool besideEnemy      = false;
    bool besideHouseArea  = false;
    bool besideWeaponArea = false;
    bool besideArmorArea  = false;
    bool isDied           = false;
    bool isKilledBoss     = false;
    
    public bool IsMove           { get => isMove;           set => isMove           = value; }
    public bool IsRight          { get => isRight;          set => isRight          = value; }
    public bool IsLeft           { get => isLeft;           set => isLeft           = value; }
    public bool BesideEnemy      {                          set => besideEnemy      = value; }
    public bool BesideHouseArea  { get => besideHouseArea;  set => besideHouseArea  = value; }
    public bool BesideWeaponArea { get => besideWeaponArea; set => besideWeaponArea = value; }
    public bool BesideArmorArea  { get => besideArmorArea;  set => besideArmorArea  = value; }
    public bool IsDied           { get => isDied;           set => isDied           = value; }
    public bool IsKilledBoss     { get => isKilledBoss;     set => isKilledBoss     = value; }
    #endregion
    

    void Awake()
    {
        playerData      = new PlayerData();
        pixcelCharactor = GetComponent<PixelCharacter>();
        uiMaster        = uiMasterObj.GetComponent<UIMaster>();
        enemySpawn      = mapPoint.GetComponent<EnemySpawn>();
        currentMap      = mapPoint.GetComponent<CurrentMap>();
    }
    void Start()
    {
        isMove = true;
        ResetActorPosition();
        SetMapPoint();
    }
    void Update()
    {
        SetPlayerUI();
        SetSystemUI();
        if (isDied) { return; }

        SetEnemyUI();

        MovePlayer();

        if (besideEnemy) { Attack(); }

        Died();
    }

    #region ---UI Method
    void SetPlayerUI()
    {
        uiMaster.MainManager.MainFrameLeader.PlayerStatusUI.SetAmount
        (
            playerData.PlayerPow,
            playerData.PlayerDef,
            playerData.PlayerSpd,
            playerData.PlayerLck,
            playerData.PlayerSkl,
            playerData.PlayerSumExp,
            playerData.PlayerNextExp
        );
        uiMaster.MainManager.MainFrameLeader.PlayerInfoUI.SetPlayerInfoUI
        (
            this.faceIcon,
            playerData.PlayerName,
            playerData.PlayerLevel
        );
        uiMaster.MainManager.MainFrameLeader.GoldUI.SetText(playerData.PlayerGold);
        uiMaster.MainManager.HPFrameUI.SetPlayerHPText(playerData.PlayerHp, playerData.PlayerCurrentHp);
        uiMaster.MainManager.HPFrameUI.SetPlayerHPbar(playerData.PlayerHp, playerData.PlayerCurrentHp);
        uiMaster.MainManager.HPFrameUI.SetPlayerAttackBar(this.attackDelayAmount, this.maxDelayAmount);
    }

    void SetSystemUI()
    {
        uiMaster.MainManager.MainFrameLeader.LevelupPanelUI.SetAmount
        (
            playerData.PlayerPow,
            playerData.PlayerDef,
            playerData.PlayerSpd,
            playerData.PlayerLck,
            playerData.PlayerSkl,
            playerData.PlayerCurrentHp,
            playerData.PlayerStatusPoint
        );
    }

    void SetEnemyUI()
    {
        if(enemy == null) { return; }

        uiMaster.MainManager.MainFrameLeader.EnemyUI.SetUI(enemy);
        uiMaster.MainManager.HPFrameUI.SetEnemyHPbar(enemy);
        uiMaster.MainManager.HPFrameUI.SetEnemyAttackBar(enemy);
    }

    void SetMapPoint()
    {
        currentMap.SetEndPoint();
        enemySpawn.SpawnControll(right, currentMap.GetMapAmount());
        uiMaster.WorldObjUI.ShowWorldObj(currentMap);
    }

    public void ClearChacker(Enemy enemy)
    {
        if (enemy.GetEnemyType() == Enemy.EnemyType.Boss)
        {
            isKilledBoss = true;
            uiMaster.MainManager.ComplateUI.ShowComplateFrame();
            uiMaster.MainManager.MainFrameLeader.EventButtonUI.ShowThis();
        }
    }

    #endregion

    #region ---StatusPointChanger Method
    public void CurrentPlayerEXPAndGold(int dropEXP, int dropGold)
    {
        int skip = 0;
        playerData.PlayerSumExp += dropEXP;
        playerData.PlayerGold += dropGold;
        for (int i = 0; i < dropEXP; i++)
        {
            playerData.PlayerNextExp -= dropEXP/dropEXP;
            if (playerData.PlayerNextExp == 0)
            {
                LevelUp();
                uiMaster.MainManager.MainFrameLeader.InfoPanelUI.ShowEnemyKillPopup(1, 1, dropEXP, 1, dropGold);
                skip++;
            }
            
        }
        if(skip != 1)
        {
            uiMaster.MainManager.MainFrameLeader.InfoPanelUI.ShowEnemyKillPopup(0, 1, dropEXP, 1, dropGold);
        }
        

    }
    void LevelUp()
    {
        playerData.PlayerLevel++;
        playerData.PlayerNextExp += playerData.PlayerLevel * 10;
        playerData.PlayerStatusPoint += 5;
        AudioManager.instance.PlayOneShotSE(AudioManager.instance.LevelUpSE);
    }

    public void UpStatus(string status)
    {
        if(playerData.PlayerStatusPoint > 0)
        {
            switch (status)
            {
                case "pow":
                    playerData.PlayerPow++;
                    break;
                case "def":
                    playerData.PlayerDef++;
                    break;
                case "spd":
                    playerData.PlayerSpd++;
                    break;
                case "lck":
                    playerData.PlayerLck++;
                    break;
                case "currentHp":
                    playerData.PlayerCurrentHp += 5;
                    break;
                case "skl":
                    playerData.PlayerSkl += 5;
                    break;
            }
            playerData.PlayerStatusPoint--;
        }
        else
        {
            AudioManager.instance.PlayOneShotSE(AudioManager.instance.SystemErrerSE);
            return;
        }
        AudioManager.instance.PlayOneShotSE(AudioManager.instance.StatusUpSE);
    }
    public void DownStatus(string status)
    {
        if(status == "pow" && playerData.PlayerPow > 5)
        {
            playerData.PlayerPow--;
            playerData.PlayerStatusPoint++;
        }
        else if (status == "def" && playerData.PlayerDef > 5)
        {
            playerData.PlayerDef--;
            playerData.PlayerStatusPoint++;
        }
        else if (status == "spd" && playerData.PlayerSpd > 5)
        {
            playerData.PlayerSpd--;
            playerData.PlayerStatusPoint++;
        }
        else if (status == "lck" && playerData.PlayerLck > 5)
        {
            playerData.PlayerLck--;
            playerData.PlayerStatusPoint++;
        }
        else if (status == "currentHp" && playerData.PlayerCurrentHp > 100)
        {
            playerData.PlayerCurrentHp -= 5;
            if(playerData.PlayerCurrentHp <= playerData.PlayerHp)
            {
                playerData.PlayerHp = playerData.PlayerCurrentHp;
            }
            playerData.PlayerStatusPoint++;
        }
        else if (status == "skl" && playerData.PlayerSkl > 20)
        {
            playerData.PlayerSkl -= 5;

            playerData.PlayerStatusPoint++;
        }
        else
        {
            AudioManager.instance.PlayOneShotSE(AudioManager.instance.SystemErrerSE);
            return;
        }

        AudioManager.instance.PlayOneShotSE(AudioManager.instance.StatusDownSE);
    }

    public void FullHelth()
    {
        playerData.PlayerHp = playerData.PlayerCurrentHp;
        isDied = false;
    }

    int DamageAmount()
    {
        // todo: damageAmountにランダム性を持たせる
        // todo: 武器攻撃力を加算する
        this.damageAmount = playerData.PlayerPow + this.weaponPow;
        int critical = Random.Range(0, playerData.PlayerLck + maxLck);

        if (critical > maxLck)
        {
            AudioManager.instance.PlayOneShotSE(AudioManager.instance.CriticalSE);
            return criticalDamage = damageAmount * 2;
        }
        if (damageAmount > 5)
        {
            AudioManager.instance.PlayOneShotSE(AudioManager.instance.AttackSE);
            return damageAmount;
        }
        else
        {
            AudioManager.instance.PlayOneShotSE(AudioManager.instance.AttackSE);
            return Random.Range(0, 6);
        }
    }

    public void ShortingAttackDelay(float minusAmount)
    {
        attackDelayAmount -= minusAmount * ((float)(playerData.PlayerSpd / (float)maxSpd) * 100f);
        AudioManager.instance.PlayOneShotSE(AudioManager.instance.ShortingSE);
    }
    #endregion

    #region ---PlayerAchievement Method
    public void KillEnemyTypeChecker()
    {
        if (enemy.GetEnemyType() == Enemy.EnemyType.Slime)
        {
            slimeKillAmount++;
        }
        if (enemy.GetEnemyType() == Enemy.EnemyType.Boss)
        {
            bossKillAmount++;
        }
    }
    #endregion

    #region ---PlayerControlls Method
    void Attack()
    {
        this.attackDelayAmount -= Time.deltaTime;

        if (0 > this.attackDelayAmount)
        {
            pixcelCharactor.Attack();
            if(enemy != null)
            {
                StartCoroutine(enemy.Damage(DamageAmount()));
            }
            this.attackDelayAmount = this.maxDelayAmount;
        }
    }

    public IEnumerator Damage(int damageAmount)
    {
        yield return new WaitForSeconds(0.4f);
        playerData.PlayerHp -= damageAmount;
    }

    void Died()
    {
        if (playerData.PlayerHp <= 0)
        {
            pixcelCharactor.IsDead = true;
            isMove = false;
            isDied = true;
            playerData.PlayerHp = 0;
            uiMaster.MainManager.MainFrameLeader.EventButtonUI.ShowThis();
        }
    }

    public void Revive()
    {
        pixcelCharactor.IsDead = false;
        isMove = true;
        isDied = false;
        isKilledBoss = false;
    }



    void MovePlayer()
    {
        MoveSpeedBlender();
        if (!isRight && !isLeft || !isMove)
        {
            pixcelCharactor.MovingBlend = 0f;
        }

        if (isRight)
        {
            pixcelCharactor.Facing = (int)Mathf.Abs(Mobility / Mobility);
            if (!isMove) { return; }
            else if (isMove)
            {
                this.gameObject.transform.Translate(Mobility * Time.deltaTime, 0, 0);
                pixcelCharactor.MovingBlend = Mathf.Clamp01((float)(Mobility / maxMobility));
            }
        }
        else if (isLeft)
        {
            pixcelCharactor.Facing = -(int)Mathf.Abs(Mobility / Mobility);
            if (!isMove) { return; }
            else if (isMove)
            {

                this.gameObject.transform.Translate(-Mobility * Time.deltaTime, 0, 0);
                pixcelCharactor.MovingBlend = Mathf.Clamp01((float)(Mobility / maxMobility));
            }


        }
    }

    void MoveSpeedBlender()
    {
        if (isRight || isLeft)
        {
            if (Mobility < maxMobility)
            {
                Mobility += maxMobility / 50f;
            }
            else if (Mobility >= maxMobility)
            {
                Mobility = maxMobility;
            }
        }
        else if (!isRight && !isLeft)
        {
            Mobility = 0f;
        }
    }

    public void ResetActorPosition()
    {
        this.gameObject.transform.position = new Vector3(-4, 4, -1);
        this.gameObject.transform.GetChild(0).localScale = new Vector3(1, 1, 1);
    }
    #endregion

    #region ---PlayerCollisionMethod
    void OnTriggerEnter2D(Collider2D collision)
    {
        EnterEndPoint(collision);

        if (collision.gameObject.tag == "Enemy")
        {
            enemy = collision.gameObject.GetComponent<Enemy>();
            ShowEnemyUI();
        }

        ShowAnyDoor(collision);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy") 
        {
            enemy = null;
            HideEnemyUI();
        }

        HideAnyDoor(collision);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MapEndPoint" || collision.gameObject.tag == "Enemy")
        {
            isMove = false;
        }

        if (collision.gameObject.tag == "Enemy") { besideEnemy = true; }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MapEndPoint" || collision.gameObject.tag == "Enemy")
        {
            isMove = true;
        }

        if (collision.gameObject.tag == "Enemy") { besideEnemy = false; }
    }

    void EnterEndPoint(Collider2D collision)
    {
        if (collision.tag != "RightEndPoint" && collision.tag != "LeftEndPoint") { return; }

        if (collision.tag == "RightEndPoint")
        {
            currentMap.MapFloorChange(right);
            currentMap.SpawnPlayer(this.gameObject, right);
            currentMap.SetEndPoint();
            enemySpawn.SpawnControll(right, currentMap.GetMapAmount());
            uiMaster.WorldObjUI.ShowWorldObj(currentMap);
        }

        if (collision.tag == "LeftEndPoint")
        {
            currentMap.MapFloorChange(left);
            currentMap.SpawnPlayer(this.gameObject, left);
            currentMap.SetEndPoint();
            enemySpawn.SpawnControll(left, currentMap.GetMapAmount());
            uiMaster.WorldObjUI.ShowWorldObj(currentMap);
        }

        SaveManager.instance.SavePlayerData(playerData);
    }

    void ShowAnyDoor(Collider2D collision)
    {
        if (collision.gameObject.tag == "HouseDoor") 
        { 
            besideHouseArea = true;
            uiMaster.MainManager.MainFrameLeader.EventButtonUI.ShowThis();
        }

        if (collision.gameObject.tag == "WeaponDoor") 
        { 
            besideWeaponArea = true;
            uiMaster.MainManager.MainFrameLeader.EventButtonUI.ShowThis();
        }

        if (collision.gameObject.tag == "ArmorDoor") 
        { 
            besideArmorArea = true;
            uiMaster.MainManager.MainFrameLeader.EventButtonUI.ShowThis();
        }
    }

    void HideAnyDoor(Collider2D collision)
    {
        if (collision.gameObject.tag == "HouseDoor")
        {
            besideHouseArea = false;
            uiMaster.MainManager.MainFrameLeader.EventButtonUI.HideThis();
        }

        if (collision.gameObject.tag == "WeaponDoor")
        {
            besideWeaponArea = false;
            uiMaster.MainManager.MainFrameLeader.EventButtonUI.HideThis();
        }

        if (collision.gameObject.tag == "ArmorDoor")
        {
            besideArmorArea = false;
            uiMaster.MainManager.MainFrameLeader.EventButtonUI.HideThis();
        }
    }

    void ShowEnemyUI()
    {
        enemy.CurrentStatus(currentMap);
        uiMaster.MainManager.MainFrameLeader.EnemyUI.ShowUI();
        uiMaster.MainManager.HPFrameUI.ShowEnemyHPFrame();
        uiMaster.MainManager.MainFrameLeader.PlayerUI.HideStatusPanel();
    }

    void HideEnemyUI()
    {
        uiMaster.MainManager.MainFrameLeader.EnemyUI.HideUI();
        uiMaster.MainManager.HPFrameUI.HideEnemyHPFrame();
        uiMaster.MainManager.MainFrameLeader.PlayerUI.ShowStatusPanel();
    }
    #endregion

    #region ---SaveMethod
    
    #endregion

    
}