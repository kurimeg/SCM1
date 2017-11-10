

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


##### 以下、各フォルダ等の説明です
+ APIController  
  UIから叩かれるAPIの受け口となるソースが格納されています。  
  (MVCのControllerと同じ役割です)  
  APIControllerはHTTPリクエストの種類(GET,POSTなど)に基づいた、  
  メソッドで成り立っています。


# ここまで書きかけ！

