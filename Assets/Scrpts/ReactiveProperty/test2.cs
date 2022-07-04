using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class test2 : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private test _test;
    
    /// <summary>
    /// 通知を受け取る側
    /// </summary>
    private void Start()
    {
        _text.text = "初回起動です";
        //イベントハンドラー
        //通知を受けとると実行
        _test.hp.Subscribe(hp=>UpdateHP(hp));
    }

    public void UpdateHP(int n)
    {
        _text.text = "hp:"+n;
    }
    
}
