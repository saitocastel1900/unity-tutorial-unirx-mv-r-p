using System;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;

public class ReactiveCommand : MonoBehaviour
{
    [SerializeField] private Toggle _toggle;
    [SerializeField] private Button _button;
    [SerializeField] private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        IObservable<bool> toggleObservable = _toggle.OnValueChangedAsObservable();
        var reactiveCommand = new ReactiveCommand<Unit>(toggleObservable);

        //ボタンが押されたらReactiveCommandに命令を出す
        //BindToと同じことをやっている
        _button.OnClickAsObservable().Subscribe(_ =>
        {
            reactiveCommand.Execute(Unit.Default);
        });

        //実行される命令
        reactiveCommand.Subscribe(_ =>
        {
            _audioSource.mute = _audioSource.mute ? false : true;
            Debug.Log("Button Clicked!");
        });
    }

}
