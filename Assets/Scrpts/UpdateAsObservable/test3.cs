using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

/// <summary>
/// 連打防止ボタン
/// </summary>
public class test3 : MonoBehaviour
{
     TimeSpan time = TimeSpan.FromSeconds(2);
    
    void Start()
    {
        //常に発信するイベント
        this.UpdateAsObservable()
            .Where(_ => Input.GetKeyDown(KeyCode.Space))                //Spaceキーが押されていて
            .ThrottleFirst(time)                                        //2秒の間隔で発信する
            .Subscribe(_ =>Debug.Log("Space Key Down!")); //実行されるイベントハンドラー
    }
}
