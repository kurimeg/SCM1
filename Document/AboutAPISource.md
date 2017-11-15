

## はじめに
このmdファイルはAPIのソース説明用です。

***
### 1. ソースの概要
本ソース(SCM1_APIソリューション)はUI側からのリクエストを受け、  
DBへアクセスし、データをCRUDする処理を行います。※1  
処理後は必ず処理結果※2をAPIを呼んだUI側に返却します。※3  

    ※1 今後UI側のjsで処理しきれない複雑な処理が発生した場合は  
        API側で処理を行うかもしれません  
    ※2 [処理成功：OK]、[処理失敗：NG]、[異常終了：ER]  
    ※3 データ取得処理の場合は取得したデータも返却します

また、本ソースはAzure上のWebAppsに展開されており、  
連携しているDBはAzure上のSQL Databaseです。  

以下、アプリケーション構成図です。
![アプリケーション構成図](./mdFileResource/ApplicationConstitution.jpg?raw=true)

***
### 2. アプリの構成
このアプリはVisualStudio2017で開発しています。.NET Frameworkは4.6.2です。  
ソリューションのファイル構成は以下のようになっています。＠2017/11/10現在  
![ソリューションエクスプローラー](./mdFileResource/SolutionCompositionOverView.jpg?raw=true)

APIが叩かれると↓のような(処理層の)順番で処理が行われます。  
>APIController→PresentationService→Service→Repository→DataAccess

##### 以下、各フォルダ等の説明です
+ APIController  
  UIから叩かれるAPIの受け口となるソースが格納されています。  
  (MVCのControllerと同じ役割です)  
  APIControllerはHTTPリクエストの種類(GET,POSTなど)に基づいた、  
  メソッドで成り立っています。

+ App_Data、App_Start  
  APIControllerのルーティング設定とかが記述されています。  
  StackOverFlowによると[WebAPIConfig.cs]にいろいろ書くと、  
  APIをたたく際のアドレスとパラメーターの対応とかが変えられるらしいので追記してます。

+ DataAccess  
  DBへの接続を行い、SQLを投げるDataAccess.csが格納されています。  
  また下層にあるSQLフォルダには、DB上のテーブル毎にSQLが記述されたxmlファイルが置かれています。  
  ちなみにDataAccess.csではDapperを使用してDB接続を行い、SQLフォルダのSQLを文字列化して食わせています。

+ Model  
  DBからの取得値を格納させるためのモデルクラスが格納されています。  
  基本的にはDB上の各テーブルにつき１クラスを想定していますが、  
  処理に必要なデータクラスが追加されていくかもしれません。。

+ PresentationService  
  Controller層で呼び出される、ビジネスクラスの始点のような位置づけです。  
  この段階ではAPIとの関係は薄っすら残っている感じでしょうか。  
  ここからServiceクラスが呼ばれます。

+ Service  
  PresentationService層で呼び出される、ビジネスロジック毎の塊です。
  ここでもDB上のテーブル毎に1csファイル(１クラス)作られるイメージです。    
  この段階ではServiceクラスとAPIとの関係は疎結合になっています。  
  例えば社員マスタServiceクラスの「社員マスタから情報を取ってくる」というビジネスロジックは、  
  ログイン処理のAPIPresentationServiceクラスでも使われますが、  
  ログイン処理とは別に、各社員のマスタメンテを行いたい場合の社員情報表示処理にも使われると思います。

+ Repository  
  Service層で呼び出される、ビジネスクラスの終点のような位置づけです。  
  この段階ではServiceクラスのロジックで必要な、  
  DBデータへのCRUD処理を実現するためにどのSQLを呼ぶかを(パラメーターと共に)指定しています。


# ここまで書きかけ！

