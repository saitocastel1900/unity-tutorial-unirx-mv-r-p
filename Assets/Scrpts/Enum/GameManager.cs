using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;


/// <summary>
/// Enumでの状態管理法
/// </summary>
public class GameManager : MonoBehaviour
{
    public StepReactiveProperty _state;
    
    void Start()
    {
        _state
            .DistinctUntilChanged()
            .Where(x => x != STEP.CLEAR)
            .Subscribe(_ =>
            {
                Result();
            }).AddTo(this);
    }
    
    void Result()
    {
       //GUIの表示とか... 
    }
}
