using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

/// <summary>
/// 簡略版
/// </summary>
public class AbrideReactiveCommand : MonoBehaviour
{
    [SerializeField] private Toggle _toggle;
    [SerializeField] private Button _button;
    [SerializeField] private Text _resultText;
    [SerializeField] private Text _buttonText;

    private void Start()
    {
         var command = _toggle.OnValueChangedAsObservable().ToReactiveCommand();
      
          // ButtonにBindする Excuteとほぼ同じ
          command.BindTo(_button);
      
          //実行される命令
          command.Subscribe(_ =>
          {
              _resultText.text += "Click!";
              _buttonText.text = _buttonText.text == "ON" ? "OFF" : "ON";
          });  
    }

 
}
