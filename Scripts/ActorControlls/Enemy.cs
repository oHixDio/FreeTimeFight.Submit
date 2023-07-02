using Cainos.CustomizablePixelCharacter;
using Cainos.PixelArtMonster_Dungeon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Status")]
    [SerializeField] Sprite faceIcon;
    [SerializeField] new string name = "";
    [SerializeField] int hp = 0;
    [SerializeField] int maxHp = 0;
    [SerializeField] int level = 1;
    [SerializeField] int pow = 2;
    [SerializeField] int def = 2;
    [SerializeField] int spd = 2;
    [SerializeField] int lck = 2;
    [Space]
    [SerializeField] int dropExp = 10;
    [SerializeField] int dropGold = 10;
    [Space]
    [SerializeField] int maxSpd = 500;
    [SerializeField] int maxLck = 500;
    [SerializeField] float maxDelayAmount = 5f;
    [SerializeField] int upHpAmount = 12;

    [Header("Enemies")]
    [SerializeField] EnemyType enemyType;
    public enum EnemyType
    {
        Slime,
        Boss,
    }

    // DeleyAmount
    float attackDelayAmount = 5f;
    float minDelayAmount = 0.3f;

    // Attack
    int damageAmount = 0;
    int criticalDamage = 0;

    // component
    PixelMonster pixelMonster;
    BoxCollider2D boxCollider2D;
    Actor actor;
    public Actor Actor
    {
        set { actor = value; }
    }

    // bool
    bool besideActor = false;
    public bool BesideActor
    {
        set { besideActor = value; }
    }
    bool isDied = false;
    bool isDestroy = false;


    void Awake()
    {
        pixelMonster = GetComponent<PixelMonster>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        if (this.hp <= 0)
        {
            this.hp = 0;
            isDied = true;
        }
        if (isDestroy) { return; }

        if (isDied) { Died(); }


        if (besideActor) { Attack(); }

    }
    
    #region ---Get Method
    public int GetEnemyStatus(string status)
    {
        int val = 0;
        switch (status)
        {
            case "hp":
                val = this.hp;
                break;
            case "maxHp":
                val = this.maxHp;
                break;
            case "level":
                val = this.level;
                break;
            case "pow":
                val = this.pow;
                break;
            case "def":
                val = this.def;
                break;
            case "spd":
                val = this.spd;
                break;
            case "lck":
                val = this.lck;
                break;
            case "dropExp":
                val = this.dropExp;
                break;
            case "dropGold":
                val = this.dropGold;
                break;
        }
        return val;
    }
    public Sprite GetFaceIcon()
    {
        return this.faceIcon;
    }
    public string GetName()
    {
        return this.name;
    }
    public float GetAttackDelayAmount()
    {
        return this.attackDelayAmount;
    }
    public float GetMaxDelayAmount()
    {
        return this.maxDelayAmount;
    }
    public EnemyType GetEnemyType()
    {
        return enemyType;
    }
    #endregion

    #region ---AmountChanger Method
    public int DamageAmount()
    {
        // todo: damageAmountにランダム性を持たせる
        // todo: 武器攻撃力を加算する
        this.damageAmount = this.pow;
        int critical = Random.Range(0, (this.lck + maxLck));

        if (critical > maxLck)
        {
            Debug.Log("クリティカル！！");
            AudioManager.instance.PlayOneShotSESub(AudioManager.instance.EnemyCriticalSE);
            return criticalDamage = damageAmount * 2;
        }
        if (damageAmount > 5)
        {
            AudioManager.instance.PlayOneShotSESub(AudioManager.instance.EnemyAttackSE);
            return damageAmount;
        }
        else
        {
            AudioManager.instance.PlayOneShotSESub(AudioManager.instance.EnemyAttackSE);
            return Random.Range(0, 6);
        }

    }

    bool isStatusUp = false;
    int num = 0;
    public void CurrentStatus(CurrentMap c)
    {
        num = c.GetCurrentMapAmount();
        if (num <= 1) { return; }
        
        if (isStatusUp == false)
        {
            num--;
            this.level += num;
            this.hp += num * upHpAmount;
            this.maxHp += num * upHpAmount;
            this.pow += num;
            this.def += num;
            this.spd += num;
            this.lck += num;
            this.dropExp += num;
            isStatusUp = true;
        }
    }
    #endregion


    #region ---Controlls Method
    void Attack()
    {
        this.attackDelayAmount -= Time.deltaTime;

        if (0 > this.attackDelayAmount)
        {
            pixelMonster.Attack();
            if (actor != null)
            {
                StartCoroutine(actor.Damage(DamageAmount()));
            }
            this.attackDelayAmount = this.maxDelayAmount;
        }
    }

    public IEnumerator Damage(int damageAmount)
    {
        yield return new WaitForSeconds(0.2f);
        this.hp -= damageAmount;
    }

    void Died()
    {
        pixelMonster.IsDead = true;
        actor.CurrentPlayerEXPAndGold(dropExp,Random.Range(1,dropGold));
        actor.KillEnemyTypeChecker();
        actor.ClearChacker(this);
        boxCollider2D.enabled = false;
        Destroy(this.gameObject, 1.5f);
        isDestroy = true;
    }
    #endregion

    #region ---Collision Method
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            actor = collision.gameObject.GetComponent<Actor>();
            besideActor = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            actor = null;
            besideActor = false;
        }
    }

    #endregion

}
