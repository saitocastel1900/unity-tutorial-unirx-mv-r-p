# unity-tutorial-unirx-mv-r-p
This is a project created to learn design patterns, implementing UI using MV(P)R pattern with UniRx.
MV(R)Pの学習の一環で作成したプロジェクトです。
# MV(R)Pパターン  
・主にWeb業界で使われているデザインパターン。クライアントが画面(UI)をよく操作することを前提としたデザインパターン。イベント処理が得意なUniRxと相性が良い。  
  
Model:値を管理  
Presenter:ModelとPresenterを繋ぐ、互いを監視して値を反映する  
View:UI全般。アニメーションもここに書く  
```mermaid
graph TD
Model--Modelの変更を検知-->Presenter
Presenter--Viewを操作-->View
Presenter--Modelを操作-->Model
View--Viewの変更を通知-->Presenter

```  
### 便利なイベントとLINQ
| イベント | 説明 |
|:---:|:---:|
|UpdateAsObservable |UpdateをObservableで使えるようにした(指定したgameObjectに紐づくObservable) |
|ReactiveProperty |value変化時に通知 |
|OnClickAsObservable |入力が終わるのを待つ |
|IntReactiveProperty |ReactivePropertyの値をインスペクタで調整できるようになったもの |
|Timer |指定した時間ごとに通知を出す |
|ReactiveCommand |処理が可能であるかを管理する |
|EveryUpdate |マイフレーム通知を出す(gameObjectから独立したObservable) |
|OnValueChangedAsObservable |トグルイベントのUniRXバージョン |
|ObserveEveryValueChanged |値の変動を毎フレーム監視する |
|OnMouseDown,Drag,Pointer.. |マウスイベントのObaserbableバージョン |
OnClickAsObservable |ボタンクリック時に呼ばれる |

| オペレータ | 説明 |
|:---:|:---:|
|ThrottleFirst |メッセージが入力されてから一定期間間引く |
|Where |値が変化するのを待つ |
|DistinctUntilChanged |前回と同じ値を削除 |
|AddTo |オブジェクト削除時に処理を終了する |
|BindTo ButtonのイベントとInteactableの連携が可能 |
|Distinct |過去の値を取り除く |
|First |条件を満たした最初の値を取り入れる |
|Last |条件を持たした最後の値を取り入れる |
|Skip |指定した値をスキップする |
|SkipWhile |条件を満たしている間スキップする |
|TakeWhile |条件を持たしている値を取り入れる |
|Throttle |入力されてから一定時間経過したら最後のメッセージを取り出す |
|Select |メッセージを変換する |
|Merge |複数のObservableを合わせる |
|Buffer |複数のメッセージをまとめる |
|Do|関数を登録可能 |

#### 購読の基本機能
```
.Subscribe(x => { _inputField.text = x.ToString(); _slider.value = x; }, //行いたい関数
                ex=>Debug.LogError("OnError!"), //エラー処理
                ()=>Debug.Log("OnCompleted!") //完了通知
            ).AddTo(this);
```

## カスタムReactivePropertyを作ってみる
-Updateを回さなくても判断できるのでメモリにやさしい  
-LINQで細かく指定できるので、コードも見やすい  

・定義元  
``` 
 public enum STEP
{
    /// <summary>
    /// 変化待ち状態
    /// </summary>
    NONE=-1,
    /// <summary>
    /// 値の初期化時・準備
    /// </summary>
    SET,
    /// <summary>
    /// ゲームプレイ時
    /// </summary>
    PLAY,
    /// <summary>
    /// ゲーム終了時
    /// </summary>
    CLEAR
}

[System.Serializable]
public class StepReactiveProperty : ReactiveProperty<STEP>
{
    //コンストラクタ
    public StepReactiveProperty() { }
    public StepReactiveProperty(STEP initialValue) : base(initialValue) { }
}
```

・使用元
```
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
```
## 色々実装してみる
### MV(R)Pパターンを用いた画像の色調整
![スクリーンショット 2022-07-05 000524](https://user-images.githubusercontent.com/96648305/177185133-270291de-af34-492f-bb33-07bea5539d00.png)

### ReactiveCommandを用いたBGMのON、OFF    
![スクリーンショット 2022-07-05 040501](https://user-images.githubusercontent.com/96648305/177207048-f421ea46-3295-4228-a7bf-6f190ca3f560.png)

### 値を監視する(ReactiveProperty)
![スクリーンショット 2022-07-05 003824](https://user-images.githubusercontent.com/96648305/177186361-758ec2c3-49ab-47eb-8e20-5fdf8c8694be.png)

### 連続防止ボタン(UpdateAsObservable)
![スクリーンショット 2022-07-05 004347](https://user-images.githubusercontent.com/96648305/177186561-336c1e4b-5e89-442b-9a5b-5683a36d49db.png)

### タップ処理・長押し処理

## 参考
https://orotiyamatano.hatenablog.com/entry/2019/08/19/Unity%E3%81%AEMVP%E3%80%81MV(R)P%E3%82%92%E8%AA%BF%E3%81%B9%E3%81%9F%E3%81%91%E3%81%A9%E3%80%81%E3%81%A9%E3%82%8C%E3%81%8C%E6%AD%A3%E3%81%97%E3%81%84%E3%82%93%E3%81%A0%EF%BC%9F   
https://qiita.com/toRisouP/items/5365936fc14c7e7eabf9  
https://www.kadokawa.co.jp/product/302009000670/  
https://www.borndigital.co.jp/book/22432.html  
https://github.com/ryo620org/Padlock  
https://qiita.com/OKsaiyowa/items/745c5359682c7baad6bf  
https://www.hanachiru-blog.com/entry/2019/04/10/175015

## 使用したサウンド
らららコッペパン：https://stsic-bgm.github.io/rarara-koppepan/  
https://soundeffect-lab.info/sound/button/  
