using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ゲーム開始時の画面を表示するスクリプト
// ヒエラルキーではこのオブジェクト以外Falseにしておく
public class GameStart : MonoBehaviour
{
    private void Start()
    {
        UIMaster.instance.TitleUI.ShowTitle();
    }
}
