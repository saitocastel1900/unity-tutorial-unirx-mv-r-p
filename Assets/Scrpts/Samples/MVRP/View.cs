using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

/*
 描画に関するロジック
 */
namespace UniRx.MVRP
{
 public class View : MonoBehaviour
 {
  [SerializeField] private Slider _slider;
  [SerializeField] private Image _gameobj;
  public void Up()
  {
   _gameobj.color += Color.cyan;
   Debug.Log(_gameobj.color);
  }
  public void Down()
  {
   _gameobj.color -= Color.magenta;
   Debug.Log(_gameobj.color);
  }

  public void Slider()
  {
   _gameobj.color = new Color(_slider.value,_slider.value,_slider.value,_slider.value);
   Debug.Log(_gameobj.color);
  }

 }
}
   