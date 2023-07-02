using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: 
// 各UI系スクリプトを取得する
// 取得したスクリプトを各オブジェクトに共有する(getter)

// Managerを取得可能
public class UIMaster : MonoBehaviour
{
    public static UIMaster instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    [Header("Player")]
    [SerializeField] Actor actor;
    public Actor Actor { get { return actor; } }

    //--------------------ChildUI--------------------//
    [Header("MasterChild")]
    [SerializeField] TitleUI titleUI;
    public TitleUI TitleUI { get { return titleUI; } }

    [SerializeField] Grid gridUI;
    public Grid GridUI { get { return gridUI; } }

    [SerializeField] Background backgroundUI;
    public Background BackgroundUI { get { return backgroundUI; } }

    [SerializeField] AreaUI areaUI;
    public AreaUI AreaUI { get { return areaUI; } }

    [SerializeField] WorldObjUI worldObjUI;
    public WorldObjUI WorldObjUI { get { return worldObjUI; } }

    //--------------------Manager--------------------//

    [SerializeField] MainManager mainManager;
    public MainManager MainManager { get { return mainManager; } }

    


}
