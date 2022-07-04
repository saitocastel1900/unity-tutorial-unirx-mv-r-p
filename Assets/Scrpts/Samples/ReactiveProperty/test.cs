using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

/// <summary>
/// 値を保持
/// </summary>
public class test : MonoBehaviour
{
    //イベント
    /// <summary>
    /// 値に変化があると通知する
    /// </summary>
    public IntReactiveProperty hp = new IntReactiveProperty(100);

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)) hp.Value += 10;
    }
    
}
