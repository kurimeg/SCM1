# SCM1
For Internal Development

## 開発時の備忘
### WebAPI開発
+ 接続文字列の外部ファイル
    + 「$\SCM1\SCM1_API\SCM1_API\DataAccess」にDataAccess.configを配置する必要がある
    + DataAccess.configは、「KSC文書サーバ\プロジェクト\KSC\SCM1\DataAccess.config」に配置
+ ビルドでエラーが発生する場合（プログラム 'http://localhost:xxxxx/'を開始できません）
    + 「$\SCM1\SCM1_API」の「.vs」（隠しフォルダ）と「packages」を削除
    + →Nugetパッケージの復元
    + →リビルドで解決
+ クロスドメイン対策
    + Electronはネイティブアプリのように振る舞うが、内部でWebサーバを動かしている？ためWebAPIのリクエストがクロスドメインエラーとなる
    + [ここ](https://social.technet.microsoft.com/wiki/contents/articles/33771.fix-to-no-access-control-allow-origin-header-is-present-or-working-with-cross-origin-request-in-asp-net-web-api.aspx)を参考に対応
    + APIコントローラクラスの属性に「[EnableCors(origins: "*", headers: "*", methods: "*")]」を付与

## はじめに
このリポジトリでは画面側とAPI側を管理する予定です。  
(調べながら/走りながら)  

+ Gitの運用方法はコチラを参照のこと  
 参考)  
 [【GitHub】開発フロー](https://qiita.com/KokiEnomoto/items/cc155ef12227a6bf3376)  
  
+ Gitのソース(branch)運用管理方法はコチラを参照のこと  
 参考)  
 [ぼくが実際に運用していたGitブランチモデルについて](https://havelog.ayumusato.com/develop/git/e513-git_branch_model.html#e513-2)  
  
ざっくり言うと、作業単位でブランチを切るイメージです。


###1. アプリの構成

+ API側はこちらを参照





