using System;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;

public class ReactiveCommand : MonoBehaviour
{
    [SerializeField] private Toggle _toggle;
    [SerializeField] private Button _button;
    
    // Start is called before the first frame update
    void Start()
    {
        IObservable<bool> toggleObservable = _toggle.OnValueChangedAsObservable();
        var reactiveCommand = new ReactiveCommand<Unit>(toggleObservable);

        _button.OnClickAsObservable().Subscribe(_ =>
        {
            reactiveCommand.Execute(Unit.Default);
        });

        reactiveCommand.Subscribe(_ =>
        {
            Debug.Log("Button Clicked!");
        });
    }

}
