using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 連打防止ボタン
/// </summary>
public class test3 : MonoBehaviour
{
    [SerializeField] private Text _text;
    
     TimeSpan time = TimeSpan.FromSeconds(2);
     private int count =0 ;
     
    void Start()
    {
        //常に発信するイベント
        this.UpdateAsObservable().
            Where(_ => Input.GetKeyDown(KeyCode.Space))                //Spaceキーが押されていて
            .ThrottleFirst(time)                                        //2秒の間隔で発信する
            .Subscribe(_ =>
            {
                count++;
                Debug.Log("Space Key Down!");
                _text.text = "Space Key Down! :"+count;
            }); //実行されるイベントハンドラー
    }
}
