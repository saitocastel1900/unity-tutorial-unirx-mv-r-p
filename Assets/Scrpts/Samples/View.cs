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
  [SerializeField] private Image _gameobj;
  public void Up()
  {
   _gameobj.color = Color.cyan;
  }
  public void Down()
  {
   _gameobj.color = Color.magenta;
  }
  
 }
}
   