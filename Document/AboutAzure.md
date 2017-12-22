

## はじめに
このmdファイルはSekipaにおけるAzure環境の説明用です。

***
## 1. Sekipaで利用しているAzureの概要
本Sekipaプロジェクトでは以下を使用しています。

+ AppService(APIサーバー,Web版Sekipa,Socketサーバー)
+ SQLDatabase(APIサーバーが使用するDB)

接続文字列やAzure内での項目名(AppService名とか)は社内サーバーにある資料を参照してください。  
以下、それぞれの説明です。

***
### AppService(APIサーバー,Web版Sekipa,Socketサーバー)  
　ココを見ている人は意識高いエンジニアなはずなので、今更AppServiceってなんぞやって説明はしません。  

※もしもの為に置いておきます   
 [Azure Web Apps 入門](https://www.slideshare.net/mihokurosawa96/azure-web-apps-63234477)

APIサーバーと言うくらいだからVMじゃないの？って思った方。良い質問です。  
  
今回APIサーバーとしての要件は「APIを配置する」のみだったので、  
VMを立ててそこのIISにデプロイ、なんて事をしなくてもAppServiceだけで事足りていたのです。  
(実プロジェクトでよくある、バッチを同居させたり～とか、ファイルの置き場所にしたり～とかは要らなかったので)

Web版Sekipaに関してはElectron版のソースを、npmでWeb版にビルドしたものになります。  
よって変換したElectronのソースのみをデプロイしている形になります。  
(Web版SekipaもAPIサーバーのAPIを呼んでいます)


**【Socketサーバーについては知ってる人の追記待ち！！】**

***
### SQLDatabase(APIサーバーが使用するDB)
　ココを見ている人は意識高いエンジニアなはずなので、今更SQLDatabaseって(ry

※もしもの為に置いておきます   
 [Azure SQL Database サービスとは](https://docs.microsoft.com/ja-jp/azure/sql-database/sql-database-technical-overview)

SQLDatabaseは特別SQLServerと使用感が変わることはありませんでした。  
強いて言うならSSMSで、テーブル毎に右クリックによるスクリプト作成ができなくて不便だったくらいでしょうか。

あと、基本的な仕様として日本語のデータを挿入する際には  
【 N’挿入したい文字列’】 という形で入れてあげないと、文字化けしてしまいます。  
⇒なので直接DBにデータをINSERTする時とかは注意してください。  
※DBの照合順序とかをいじると直るらしいので、時間と精神的余裕があれば直してみてください

今のところ日本語データを登録するソースはないので分かりませんが、  
今後日本語を登録する事になった場合は、もしかしたらDappaerだけではうまいことやってくれず、  
xml内のSQLにも"N"プレフィックスをつけないと文字化けするかもしれません。


***
## 2. ちょっとトリッキーな事
AppServiceの作成手順とか、ググれば一発で出るようなやつは書きません。  
勉強だと思ってそれくらいは調べて下さい。  
ググってもピンポイントですぐには出ないっぽい以下の2点については  
ヒント含めここで書かせて頂きます。

+ PublishSettingsファイルを利用して、VisualStudioからAppServiceにデプロイする
+ APIサーバーのログをKuduから見る

以下、それぞれの説明です。

***
### PublishSettingsファイルを利用して、VisualStudioからAppServiceにデプロイする
↓のリンクの【Windows Azure Web サイトを作成する】と  
【Web アプリケーションを発行する】の部分を参照してください。  
※APIサーバーもWeb版も同じやり方でデプロイしてます  
[Visual Studio から Windows Azure にデプロイする](https://sakapon.wordpress.com/2013/11/24/vs-deploy-azure/)


***
### APIサーバーのログをKuduから見る
↓のリンクの通りに,「AppService：scm1API」のKuduのCMD画面を開き、  
  site -> wwwroot -> Log -> General.log
を閲覧して下さい。  
※過去ログについては同階層のArchivesフォルダ内に入っています
  
 [Azure Web Appsの中を「コンソール」や「シェル」でのぞいてみる (3/3)](http://www.atmarkit.co.jp/ait/articles/1707/27/news024_3.html)

***
## 3. やれなかった事
当初はバッチサーバーは、新浦安のlocalサーバーではなく、  
AzureのAppService(APIサーバー)に付随する、「Webジョブ」と呼ばれるものに乗っけることを想定していました。  
  
ですが定時実行する対象ファイル(nodeを使ってjsで送る方法と、  PowerShellでの方法の2通り試しました)が、  
AzureのWebジョブ上では正しく動いている扱いになっているにも関わらず、  
APIサーバーに届いていないのかDBデータの削除ができませんでした。  

恐らくAPIサーバー自身が新浦安環境に合わせてIP制限をかけている為、  
動的IPアドレスであるAppServiceひいては当該Webジョブが弾かれていた為にこけていたのだと思われます。


# あとはなんかあったら追記する感じで...。