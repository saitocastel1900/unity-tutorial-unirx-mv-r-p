# unity-tutorial-unirx-mv-r-p
This is a project created to learn design patterns, implementing UI using MV(P)R pattern with UniRx.
MV(R)Pの学習の一環で作成したプロジェクトです。
# MV(R)Pパターン  
主にWeb業界で使われているデザインパターン。クライアントが画面(UI)をよく操作することを前提としたデザインパターン。イベント処理が得意なUniRxと相性が良い。  
  
Model:値を管理  
Presenter:ModelとPresenterを繋ぐ  
View:UI全般。アニメーションもここに書く  
```mermaid
graph TD
Model--Modelの変更を検知-->Presenter
Presenter--Viewを操作-->View
Presenter--Modelを操作-->Model
View--Viewの変更を通知-->Presenter

```
