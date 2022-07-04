using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
ViewとModelを監視する
 */
namespace UniRx.MVRP
{
public class Presenter : MonoBehaviour
{
    [SerializeField] private Model _model;

    [SerializeField] private InputField _inputField;
    [SerializeField] private Button _upButton;
    [SerializeField] private Button _downButton;
    [SerializeField] private Slider _slider;
    
    // Start is called before the first frame update
    void Start()
    {
        //model=>view
        _model.Current
            .Subscribe(x =>
                {
                    _inputField.text = x.ToString();
                    _slider.value = x;
                }
            ).AddTo(this);

        //view=>model
        _inputField.OnValueChangedAsObservable()
            .Select(x =>
            {
                var isSucceed = int.TryParse(x, out var value);
                return (isSucceed, value);
            }).Where(x => x.isSucceed)
            .Subscribe(x => _model.UpdateCount(x.value))
            .AddTo(this);

        //sliderの値が変動したら実体にも値を変更する
        _slider
            .OnValueChangedAsObservable()
            .Subscribe(x => _model.UpdateCount((int) x))
            .AddTo(this);

        //ボタンが押されたら実体を変更する
        Observable.Merge(
            _upButton.OnClickAsObservable().Select(_ => +1),
            _downButton.OnClickAsObservable().Select(_ => -1)
        ).Subscribe(value => { _model.UpdateCount(_model.Current.Value + value); }
        ).AddTo(this);
    }

}

}
    