# unity-tutorial-unirx-mv-r-p
This is a project created to learn design patterns, implementing UI using MV(P)R pattern with UniRx.
MV(R)Pの学習の一環で作成したプロジェクトです。
# MV(R)Pパターン  
・主にWeb業界で使われているデザインパターン。クライアントが画面(UI)をよく操作することを前提としたデザインパターン。イベント処理が得意なUniRxと相性が良い。  
  
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

# おまけ
### ReactiveCommandをUIに応用してみる 
・ReactiveCommandとは...　**処理が可能であるかを制御する機構**   
・ReactiveCommandでトグルなどがTrueだった場合の処理を簡易化(ここではReactiveCommandのExcuteを用いてトグルと連動し、実行可能な状態かどうなのかを通知)。  

## サンプル
・MV(R)Pパターンを用いたBGM、SEの調整

・ReactiveCommandを用いたBGM、SEのON、OFF    

## 参考
https://orotiyamatano.hatenablog.com/entry/2019/08/19/Unity%E3%81%AEMVP%E3%80%81MV(R)P%E3%82%92%E8%AA%BF%E3%81%B9%E3%81%9F%E3%81%91%E3%81%A9%E3%80%81%E3%81%A9%E3%82%8C%E3%81%8C%E6%AD%A3%E3%81%97%E3%81%84%E3%82%93%E3%81%A0%EF%BC%9F   
https://qiita.com/toRisouP/items/5365936fc14c7e7eabf9  
https://www.amazon.co.jp/UniRx-UniTask%E5%AE%8C%E5%85%A8%E7%90%86%E8%A7%A3-%E3%82%88%E3%82%8A%E9%AB%98%E5%BA%A6%E3%81%AAUnity-C-%E3%83%97%E3%83%AD%E3%82%B0%E3%83%A9%E3%83%9F%E3%83%B3%E3%82%B0/dp/4048930753  
https://www.amazon.co.jp/Unity%E3%82%B2%E3%83%BC%E3%83%A0-%E3%83%97%E3%83%AD%E3%82%B0%E3%83%A9%E3%83%9F%E3%83%B3%E3%82%B0%E3%83%BB%E3%83%90%E3%82%A4%E3%83%96%E3%83%AB-2nd-Generation-%E5%93%B2%E5%93%89/dp/4862465072/ref=pd_bxgy_img_sccl_1/358-6144516-9633332?pd_rd_w=WHHC0&pf_rd_p=020fee25-8ced-4191-bce3-27e7ce0c0e3b&pf_rd_r=JH2M0DM2QGMV9167K9PV&pd_rd_r=f436da11-9b20-46e7-83ab-204641c69757&pd_rd_wg=LK3oq&pd_rd_i=4862465072&psc=1
