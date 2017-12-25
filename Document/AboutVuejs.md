# アプリケーション構成
本題に入る前に、アプリについての説明をしたいと思います。
## アプリケーション構成
![アプリケーション構成.png](https://qiita-image-store.s3.amazonaws.com/0/163867/4e9a6f5a-1bac-88ba-8113-4cb12de56f7d.png)

処理は全てWeb APIになっています。
サーバー側は全てAzureで、
データベースはSQL Databaseを使用し、APIサーバーはC#で開発しています。
ソース管理はGitHubを使用しています。
今後、通知サーバー（Node.js/socket.io）を増やす予定です。

# 環境構築
[electron-vue](https://github.com/SimulatedGREG/electron-vue) というボイラープレートを使用しました。
フロントの構成がElectronとVue.jsになったのも、このボイラープレートがあったことが大きな要因でした。

- vue-cli
- vue-loader
- webpack
- electron-builder
- vue-router
- vuex
- axios

など開発から自動デプロイまで様々な設定が含まれています。
詳しい環境構築方法は[electron-vue（日本語ドキュメント）](https://simulatedgreg.gitbooks.io/electron-vue/content/ja/) をご覧ください。

インストールが完了し、 `npm run dev` を実行すると、もうHello Worldです。

![HelloElectoronVue.jpg](https://qiita-image-store.s3.amazonaws.com/0/163867/3eaf55a1-9884-1bf5-7d17-8eb230d1e6be.jpeg)

詳しいバージョンなどはこちらです。
OS：Windows 8.1
Electron：1.7.9
Vue.js：2.5.3
Node.js：7.9.0
開発にはVisual Studio Codeを使用しました。

デフォルトのディレクトリ構成はこのようになります。
![ディレクトリ.jpg](https://qiita-image-store.s3.amazonaws.com/0/163867/4b46e9f0-59e0-cd3f-c7f6-9041bc11a1c0.jpeg)


環境が整ったところで`src`以下をいじっていくわけですが、`main`？`renderer`?と謎のフォルダが(´・ω・｀)
ということで、やっと本題です(｀･ω･´)
# Electronとは？
Mac/Linux/Windowsで動作するデスクトップアプリケーションを作るためのフレームワークです。
HTML/JavaScript/CSSといったWebの技術で開発できることが特徴です。
このアプリもデスクトップver.とブラウザver.を同一ソースでリリースしています。

## 2つのプロセス
Chromiumをベースとしているので、以下の2つのプロセスから構成されます。
そして、それぞれのプロセスにNode.jsが埋め込まれています。
こちらがChromiumの構成です。
![Chromium構成.jpg](https://qiita-image-store.s3.amazonaws.com/0/163867/7574096c-354b-d1e0-2d03-d57eb61ada41.jpeg)
※[Practice on embedding Node.js into Atom Editor by Cheng Zhao](https://speakerdeck.com/zcbenz/practice-on-embedding-node-dot-js-into-atom-editor)



そして、こちらはElectron（旧称：Atom Shell）の構成です。
![AtomShell構成.jpg](https://qiita-image-store.s3.amazonaws.com/0/163867/5ca7a3c2-ac0b-3ea7-42e7-d88c976060c6.jpeg)
※[Practice on embedding Node.js into Atom Editor by Cheng Zhao](https://speakerdeck.com/zcbenz/practice-on-embedding-node-dot-js-into-atom-editor)

- Main Process（1つのみ）  
ウィンドウの表示などバッグエンド
- Renderer Process（複数）  
レンダリング  
※今回はここにVue.jsを使用しています。

# Vue.jsとは？
インタラクティブなインタフェースを作るためのJavaScriptライブラリです。

## Progressive Framework
Vue.jsの大きな特徴の1つがこのProgressive Frameworkです。

フロントエンドには様々なフレームワークがあり、アプリケーション開発の複雑性を解決しようとしていますが、そのフレームワーク自身にも複雑性があります。

開発当初、適切なフレームワークを採用したとしても、アプリケーションはProgressive（進歩的）であり、どんどん変化していきます。

この変化に対して、フレームワークもProgressiveであろうとするのが、Progressive Frameworkの考え方です。

Vue.js自体はデータバインディングやリアクティブなレンダリングといった単純なライブラリであり、そこにその他のライブラリ（vue-router、vuexなど）を組み合わせることで、アプリケーションの規模に応じたフレームワークを作っていくことができます。

Vue.jsではその組み合わせる領域を6つのレイヤーに分けています。
アプリケーションが小規模であれば第1、2階層のVue.jsとして提供する機能のみを、規模が大きくなるにつれ、第3階層のルーティングや、第4階層の状態管理を組み合わせていきます。
このアプリでは、第5階層まで全て含めています。

![ProgressiveFramework.jpg](https://qiita-image-store.s3.amazonaws.com/0/163867/0fd5b097-cfcb-9880-5157-9e229f95e496.jpeg)
※[The Progressive Framework](https://docs.google.com/presentation/d/1WnYsxRMiNEArT3xz7xXHdKeH1C-jT92VxmptghJb5Es/edit#slide=id.p)

1. Declarative Rendering：Vue.js  
データバインディング、リアクティブなレンダリング
1. Component System：Vue.js  
UIのモジュール化
1. Client-side Routing：vue-router  
シングルページアプリケーションの構築
1. Large-scale State Management：vuex  
コンポーネント間での状態の集中管理
1. Build System：vue-cli、webpack、vue-loader  
プロジェクトの環境構築や構成管理
1. Client-server Data Persistence：今後提供予定…  
アプリケーションの複雑なデータ構造の永続化

# Main Process
ひとまずはウィンドウが立ち上がればよいので、electron-vueインストール時に自動生成されたまま変更しません。

```javascript:src/main/index.js
'use strict'

import { app, BrowserWindow } from 'electron'

if (process.env.NODE_ENV !== 'development') {
  global.__static = require('path').join(__dirname, '/static').replace(/\\/g, '\\\\')
}

let mainWindow
const winURL = process.env.NODE_ENV === 'development'
  ? `http://localhost:9080`
  : `file://${__dirname}/index.html`

function createWindow () {
  mainWindow = new BrowserWindow({
    height: 563,
    useContentSize: true,
    width: 1000
  })

  mainWindow.loadURL(winURL)

  mainWindow.on('closed', () => {
    mainWindow = null
  })
}

app.on('ready', createWindow)

app.on('window-all-closed', () => {
  if (process.platform !== 'darwin') {
    app.quit()
  }
})

app.on('activate', () => {
  if (mainWindow === null) {
    createWindow()
  }
})
```
`createWindow ()`で、幅や高さ、URLなどを設定し、Electronの初期化処理終了後（ = ready）に`createWindow`を呼び出すだけです。
実際には、ここでメニューバーの設定やスタートアップへの登録、自動アップデートなどを実装しています。

# Renderer Process 
`npm run build`して最終的に出来上がるディレクトリ構成は以下のようになります。

![ビルド後ファイル.jpg](https://qiita-image-store.s3.amazonaws.com/0/163867/3532d0ca-6a95-1928-1f48-3f283ceee6f4.jpeg)

シンプルですね！

この`index.html`の基本となるのが、`index.ejs`です。

```html:src/index.ejs
<!DOCTYPE html>
<html>
  <head>
    <meta charset="utf-8">
    <title>SekiPa</title>
    <% if (htmlWebpackPlugin.options.nodeModules) { %>
      <script>
        require('module').globalPaths.push('<%= htmlWebpackPlugin.options.nodeModules.replace(/\\/g, '\\\\') %>')
      </script>
    <% } %>
  </head>
  <body>
    <div id="app"></div>
    <script>
      if (process.env.NODE_ENV !== 'development') window.__static = require('path').join(__dirname, '/static').replace(/\\/g, '\\\\')
    </script>
  </body>
</html>
```

`body`には`<div id="app"></div>`しかないぞ(´・ω・｀)
どうなっているんだ(´・ω・｀)？

## コンポーネント
HTML要素をコンポーネントとして部品化、カプセル化することができます。
コンポーネントはVueインスタンスそのものです。
![components.png](https://qiita-image-store.s3.amazonaws.com/0/163867/5a111f9a-4232-1180-6e5c-739d537e22e2.png)
※[Vue.js（日本語）はじめに](https://jp.vuejs.org/v2/guide/index.html)

コンポーネントを組み合わせることで、アプリケーションを構築していきます。
このアプリではこのようにコンポーネントを分割しています。

![コンポーネント構成.jpg](https://qiita-image-store.s3.amazonaws.com/0/163867/43dd29b0-f159-5829-9b27-0567b9f38d86.jpeg)

**ログイン（Login.vue）**
![SekiPaログイン_コンポーネント分割.jpg](https://qiita-image-store.s3.amazonaws.com/0/163867/46e961a4-18df-3fca-dc80-f0374a5b649f.jpeg)

1. Login.vue

**座席表（Chart.vue）**
![SekiPa検索_モザイク_コンポーネント分割.jpg](https://qiita-image-store.s3.amazonaws.com/0/163867/4a0ebc84-2d1a-0d02-5e5a-7c2f48fabcb4.jpeg)

1. Chart.vue
2. Seat.vue
3. Search.vue  
（デスクもコンポーネント化予定…）

**ローディング（Loading.vue）**
![SekiPaローディング_コンポーネント分割.jpg](https://qiita-image-store.s3.amazonaws.com/0/163867/213a52c3-001c-9db0-d7b3-1ee53ff8d40f.jpeg)

1. Loading.vue

**モーダル（Modal.vue）**
![SekiPa登録_コンポーネント分割.jpg](https://qiita-image-store.s3.amazonaws.com/0/163867/a33af536-ec25-e52c-46c4-582db230ad3c.jpeg)

1. Modal.vue  
    -  Alert.vue
    -  AlertReg.vue
    -  Error.vue


ルーティングの対象となるコンポーネントはLogin.vueとChart.vueのみです。
これに対して、Loading.vueやModal.vueなどレイヤーを重ねています。
（[Vue.js（日本語）スタイルガイド](https://jp.vuejs.org/v2/style-guide/)に沿って、命名やディレクトリ構成は直す予定…）

拡張子`.vue`ってなんだ(´・ω・｀)？

### 単一ファイルコンポーネント
カプセル化したい単位は、ファイルの種類ごとではなく、このアプリで言えば座席、検索ウィンドウといったオブジェクト単位です。
`.vue`ファイル内には、`<template>`、`<script>`、`<style>`の3種類のタグがあり、1ファイル＝1コンポーネントとして扱うことができます。
※この`.vue`ファイルは、`vue-loader`によりビルド時にJavaScriptに変換されています。

ルートとなるコンポーネント`App.vue`です。

```html:src/renderer/App.vue
<template>
  <div id="app">
    <router-view></router-view>
    <loading></loading>
    <modal></modal>
  </div>
</template>

<script>
  import Modal from './components/Modal'
  import Loading from './components/Loading'

  export default {
    components: {
      Loading, Modal
    }
  }
</script>

<style>
  #app{
    position: relative;
    zoom: 70%;
  }
  body {
    margin: 0 0 0 0;
    font-family: 'ＭＳ Ｐ明朝', 'MS PMincho','ヒラギノ明朝 Pro W3', 'Hiragino Mincho Pro', 'serif'sans-serif;
  }
  .main-layer {
    /* 省略 */
  }
  .seat-layer {
    /* 省略 */
  }
  .search-layer{
    /* 省略 */
  }
  .alert-layer{
    /* 省略 */
  }
  .loading-layer{
    /* 省略 */
  }
  .fade-enter-active, .fade-leave-active {
    transition: opacity .3s
  }
  .fade-enter, .fade-leave-to{
    opacity: 0
  }
</style>
```
各レイヤーや`body`などグローバルなスタイルはこちらで定義しています。

続いて、Renderer Processのエントリーポイントとなる`main.js`です。

```javascript:src/renderer/main.js
import Vue from 'vue'
import router from './router'
import store from './store'
import App from './App'
import httpClient from './util/http-client'

if (!process.env.IS_WEB) Vue.use(require('vue-electron'))
Vue.use(httpClient, { store })
Vue.config.productionTip = false

/* eslint-disable no-new */
new Vue({
  components: { App },
  router,
  store,
  template: '<App/>'
}).$mount('#app')
```
ここでApp.vueをインスタンス化して、`<div id="app"></div>`にmountしています。

ん？`<router-view></router-view>`ってなんだろう(´・ω・｀)？

## ルーティング　～vue-router～
### vue-routerとは
シングルページアプリケーション構築のためのルーティングライブラリです。

### ルート定義
まずは、コンポーネントとルートのマッピングを行います。

```javascript:src/renderer/router/index.js
import Vue from 'vue'
import Router from 'vue-router'
import Login from '@/components/Login'
import Chart from '@/components/Chart'

Vue.use(Router)

const router = new Router({
  routes: [   
    {
      path: '/',
      name: 'login',
      component: Login
    },
    {
      path: '/chart',
      name: 'chart',
      component: Chart,
    }
  ]
})

export default router
```

このアプリではログインから座席表への遷移しかありませんので、
コンポーネントとそれに対応するパスを定義して完成です。
これでrouter-viewコンポーネントがパスにマッチしたコンポーネントを描画してくれます。

### ページ遷移
```html
<router-link to="home">Home</router-link>
↓
<a href="home">Home</a>
```
router-linkコンポーネントを使えば、toプロパティに指定したパスへ遷移する`<a>`タグを生成してくれます。
※[vue-router（日本語）router-link](https://router.vuejs.org/ja/api/router-link.html)

また、routerのインスタンスメソッドを使うこともできます。
### routerインスタンスメソッド 
- router.push(location, onComplete?, onAbort?)：履歴を追加し、遷移する

```javascript
router.push('chart')
```


- router.go(n)：パラメーターで指定されたページへ移動する

```javascript
// 1ページ進む
router.go(1)

// 1ページ戻る
router.go(-1)
```

`router.push()`と`router.go()`で進む/戻るボタンを実装することができます。

- router.replace(location, onComplete?, onAbort?)：履歴を追加せず、遷移する

```javascript
router.replace('chart')
```
このアプリでは、履歴を残す必要がないので、
ログインボタン押下時に`router.replace('chart')`で遷移しています。

### ナビゲーションガード
ここでは実装していませんが、
「リダイレクトされたら、必ず認証を行いたい」といった場合…

リダイレクトやキャンセルによる遷移に対して

- グローバル
- ルート単位
- コンポーネント単位

に処理をフックすることができます。
※[vue-router（日本語）ナビゲーションガード](https://router.vuejs.org/ja/advanced/navigation-guards.html)

コンポーネントとページ遷移についてはわかったぞ(｀･ω･´)！
Chart.vueの初期表示から検索結果表示まではこんな感じにしたい(｀･ω･´)！

1. 座席・社員の位置情報を取得して、Seatコンポーネントを配置  
DBにX座標、Y座標、縦か横かを表すフラグを保持しています。
2. 検索テキストボックスの入力値で社員の絞り込み    
3. 社員名ボタン押下で検索
4. 該当社員の座席の色を変える

でも、ロジックはどこに書けばいいんだろう(´・ω・｀)？

## MVVMと状態管理　～vuex～
この章は、[Vue.jsで実現するMVVMパターン Fluxアーキテクチャとの距離](http://techblog.reraku.co.jp/entry/2016/12/13/080000)をまとめたものです。

### Model-View-ViewModelとは
Vue.jsは、MVVMアーキテクチャの影響を受けています。
**MVVM**とは、Model-View-ViewModelに分割して、設計・実装するアーキテクチャパターンのことです。

MVVMが実現しようとしているのは、**PDS（Presentation Domain Separation）**です。
PDSはその名の通り、「Presentation（UI）とDomain（ロジック）はわけましょう」という考え方です。

もしこのアプリをjQueryだけで実装しようとすると…

- **DOMがHTML外で生成されてしまう**  
座席表ボタンを表示するには、DBから取得した座席・社員の位置情報をループで回して、`<button>`タグを生成して…

この`button`に「CSSを追加したい！」となった場合、DOMを生成しているロジックを見なければいけません。

- **様々な場所でイベントハンドラが設定されてしまう**  
検索イベントは初期表示で、座席登録イベントは`<button>`タグ生成のループでハンドルして…

どこでどのようなイベントが起きているのかが分かりづらくなってしまいます。

- **DOMが状態を管理している**  
検索結果を表示するには、座席表ボタンのエレメントを全て取得して、結果と一致するエレメントを探して…

何をするにも、まずDOMを見なければいけません。

このように、UIとロジックがどんどん密結合になっていき、複雑化していってしまいます。

そこでまず、View（UI）とModel（ロジック）に分けます。
このViewとModelをつなげるのがViewModelです。
それでは、Model-View-ControllerのControllerと何が違うのでしょうか。

ViewModelは、Viewとバインドされたオブジェクトを持っています。
この**ViewとViewModelが双方向にバインド**されていることが、MVVMの特徴です。

![MVVM.jpg](https://qiita-image-store.s3.amazonaws.com/0/163867/3aee656b-9cda-9af5-da59-b1108c159bec.jpeg)

イベント発生から、Viewへの反映までを追ってみると…

1. Viewでイベントが起きます。
2. ViewModelは、Modelのメソッドを呼び出します。
3. Modelのメソッドによる変更をViewModelは監視し、自身のオブジェクトを書き換えます。
4. ViewとViewModelはバインドされているので、ViewModelの変更がViewに反映されます。

このようなフローになります。
そして、この**フロー**が重要です。
ViewModelは、Modelのメソッドの戻り値を利用して…などということはしていません。
そうすると、どんどんModelとViewは密結合になっていってしまいます。

それを防ぐために、**単方向データフロー**を強制してくれるのが、**Vuex**です。

### Vuexとは
単方向データフローを実現するための状態管理ライブラリです。

先程の例のように、ViewModelとModelが1対1になるとは限りません。

![MVVM_複雑化.jpg](https://qiita-image-store.s3.amazonaws.com/0/163867/b0cfbdb5-da17-51e7-dabe-54e8292a7c65.jpeg)

このように、「異なるViewModelから同じメソッドを呼び出したい！」ということもあると思います。
すると、またどんどん複雑化していきます。

そこで、「単一のModelにしてそこですべて管理しよう！」とうのがVuexの考え方です。

![MVVM_Storeの概念.jpg](https://qiita-image-store.s3.amazonaws.com/0/163867/370e7f74-aab8-049d-0433-0f0a0b275511.jpeg)

Vuexでは、この単一のModelを**Store**と呼びます。
Storeの中には、**Action**、**Mutation**、**State**が定義されています。

- Action  
ビジネスロジックです。非同期通信はここで行います。
- Mutation  
唯一Stateの変更をすることができます。
- State  
状態（アプリ内で使用したいデータなど）そのものです。

先程のイベント発生から、Viewへの反映をVuexに沿って見てみると…
1. Viewでイベントが起きます。
2. ViewModelは、StoreのActionを呼び出します。
3. StoreのActionは、MutationをCommitしてStateを変更します。
4. Stateの変更をViewModelは監視し、自身のオブジェクトを書き換えます。
5. ViewとViewModelはバインドされているので、ViewModelの変更がViewに反映されます。

Storeの中では、このAction、Mutation、StateをModule化することができます。
このアプリではこのようにModule化しています。
![Store構成.jpg](https://qiita-image-store.s3.amazonaws.com/0/163867/7c5bfab9-f7bb-90b0-b33b-46fb0a55663d.jpeg)

よく見るVuexの図は、MVVMと照らし合わせるとこのようになります。
![VuexとMVVM.jpg](https://qiita-image-store.s3.amazonaws.com/0/163867/446dbb3d-3c9f-2b00-07be-6fadb1633745.jpeg)

それでは、まずView/ViewModelにあたる`Chart.vue`を見てみます。

```html:src/renderer/components/Chart.vue
<template>
  <div class="main-layer">
    <img 
      class="icon" 
      src="../assets/images/search_icon.png" 			
      @click="showSearch"
    >	
    <search v-if="show"></search>
    <img
      class="rel" 
      src="../assets/images/reload.png"	
      @click="reload"
    >
    <button 
      class="logout"     
      v-if="!isGuest"
      @click="logout"
    >Log out</button>
    <div class="tables">
      <!-- 省略　デスクと内線 -->
    </div>
    <div class="seat-layer" >
      <seat 
        v-for="seat in seats" 
        :id="seat.SEAT_NO" 
        :key="seat.SEAT_NO" 
        :class="{ seatY: !seat.VERTICAL_FLG , searched: userPath.length != 0 && seat.SEAT_NO === userPath[0].SEAT_NO }" 
        :style="{ left: seat.CONTENT_POSITION_X + 'px', top: seat.CONTENT_POSITION_Y + 'px' }"
        :seat="seat" 
      ></seat>
    </div>
  </div>
</template>

<script>
  import Seat from './Chart/Seat'
  import Search from './Chart/Search'
  import * as messages from '@/assets/messages'
  import { mapActions, mapMutations, mapState } from 'vuex'

  export default {
    components: {
      Seat, Search
    },
    data: function () {
      return {
        empNo: JSON.parse(localStorage.getItem('authInfo')).EmpNo
      }
    },
    computed: {
      ...mapState('auth', {
        token: state => state.token,
        isGuest: state => state.isGuest
      }),
      ...mapState('search', {
        show: state => state.show
      }),
      ...mapState('getMaster', {
        seats: state => state.seatInfo
      }),
      ...mapState('getUserPath', {
        userPath: state => state.userPath
      })
    },
    created: function () {
      this.showLoading(true)
      this.fetchSeatInfo({
        Token: this.token
      })
      this.fetchEmpInfo({
        token: {
          Token: this.token,
          EmpNo: ''
        },
        loginEmpNO: this.empNo
      })
      this.getIsReserved({
        EmpNo: this.empNo,
        Token: this.token
      })
    },
    updated: function () {
      this.showLoading(false)
    },
    methods: {
      ...mapActions({
        fetchSeatInfo: 'getMaster/fetchSeatInfo',
        fetchEmpInfo: 'getMaster/fetchEmpInfo',
        getIsReserved: 'reserve/getIsReserved',
        showAlert: 'modal/showAlert'
      }),
      ...mapMutations({
        showSearch: 'search/showSearch',
        showLoading: 'loading/showLoading'
      }),
      logout: function () {
        this.showAlert({
          message: messages.I_005,
          actionName: 'auth/logout',
          param: {}
        })
      },
      reload: function () {
        this.showLoading(true)
        this.fetchSeatInfo({
          Token: this.token
        })
      }
    }
  }
</script>

<style scoped>
  /* 省略 */
</style>
```

`<template>`と`<style>`がView、`<script>`がViewModelになります。

`v-for`属性(´・ω・｀)？`computed`オプション(´・ω・｀)？

### ディレクティブ
要素をリアクティブにするためのHTML属性です。
属性値の変化に応じたDOM操作やDOMイベントのハンドリングなどができます。
この属性により、DOMに関する操作は`template`上に集約されます。

- **v-text**  
要素のtextContentを更新します。Mustache構文が使用できます。

```html
<span v-text="message"></span>
<span>{{ message }}</span>
```

- **v-show**  
真偽値によって、要素のdisplayプロパティをblock/noneに設定します。

```html
<h1 v-if="ok">Hello!</h1>
```

- **v-if**  
真偽値によって、DOM要素自体を作成/破棄します。

```html
<h1 v-show="ok">Hello!</h1>
```

- **v-for**  
ソースデータに基づいて、要素を複数回描画します。

```html
<div v-for="item in items">
  {{ item.text }}
</div>
```
- **v-bind**  
`class`や`style`など通常のHTML属性をリアクティブにします。省略記法`:`があります。

```html
<div :class="{ red: isRed }"></div>
<div :style="{ fontSize: size + 'px' }"></div>
```

- **v-model**  
以下の要素への入力値をバインドします。
 - `<input>`
 - `<select>`
 - `<textarea>`
 - コンポーネント

```html
<input v-model="message" placeholder="edit me">
<p>Message is: {{ message }}</p>
```

- **v-on**  
要素のイベントをハンドリングします。省略記法`@`があります。

```html
<button @click="doThis"></button>
<input @keyup.enter="onEnter">
```
※[Vue.js（日本語）API　ディレクティブ](https://jp.vuejs.org/v2/api/#%E3%83%87%E3%82%A3%E3%83%AC%E3%82%AF%E3%83%86%E3%82%A3%E3%83%96)


### コンポーネントオプション
コンポーネントの各種設定を行います。

- templateで使用されるアセット
 - **components**  
 ここではSearchとSeatコンポーネントのみ使用するため、componentsのみです。

- インターフェース
 - **props**  
 親コンポーネントから子コンポーネントへのデータの受け渡しはこのpropsを通して行われます。
 
 ```html:親コンポーネント
<template>
  <div id="parent">
    <input type="text" v-model="parentMessage"></input>
    <child :message="parentMessage"></child>
  </div>
</template>

<script>
  export default {
    data: function () {
      return {
        parentMessage: '',
      }
    }
  }
</script>
```

```html:子コンポーネント
<template>
  <div id="child">
    <p>Message from parent： {{ message }}</p>
  </div>
</template>

<script>
  export default {
    props: ['message']
  }
</script>
```
[Vue.js（日本語）コンポーネント　プロパティ](https://jp.vuejs.org/v2/guide/components.html)

- ローカルの状態
 ViewとViewModelをバインドするオブジェクトの定義です。
 ここで定義したオブジェクトはリアクティブになります。
 - **data**  
 Vueインスタンス作成時に定義されているオブジェクトのみリアクティブとなります。
 Vueインスタンス作成後にリアクティブなオブジェクトを追加したい場合は、`Vue.set(object, key, value)`メソッドを使う必要があります。

 - **computed**  
 computedプロパティに依存するものが更新された場合、 computedプロパティは再評価されます。

```html:
<template>
  <div id="example">
    <input type="text" v-model="message"></input>
    <p>Computed reversed message: {{ reversedMessage }}</p>
  </div>
</template>

<script>
  export default {
    data: function () {
      return {
        message: '',
      }
    },
    computed: {
      reversedMessage: function () {
        return this.message.split('').reverse().join('')
      }
    }
  }
</script>
```
Viewでの入力値は、v-modelディレクティブによりdataオプションにバインドされます。
computedプロパティである`reversedMessage`は、`message`の変更をトリガーに`this.message.split('').reverse().join('')`を実行します

※[Vue.js（日本語）算出プロパティとウォッチャ](https://jp.vuejs.org/v2/guide/computed.html)

- リアクティブイベント
 Vueインスタンスのライフサイクルに応じてイベントをフックできます。
![ライフサイクルフック.png](https://qiita-image-store.s3.amazonaws.com/0/163867/fece2873-7caa-d01d-5b79-11472cab3bfd.png)
※[Vue.js（日本語）Vue インスタンス　ライフサイクルダイアグラム](https://jp.vuejs.org/v2/guide/instance.html#%E3%82%A4%E3%83%B3%E3%82%B9%E3%82%BF%E3%83%B3%E3%82%B9%E3%83%A9%E3%82%A4%E3%83%95%E3%82%B5%E3%82%A4%E3%82%AF%E3%83%AB%E3%83%95%E3%83%83%E3%82%AF)

- 非リアクティブイベント
 - **methods**  
   Actionのdispatch、MutationのCommitはこちらで行います。

※[Vue.js（日本語）API　オプション](https://jp.vuejs.org/v2/api/)

次に、ModelにあたるStoreを見ていきます。
こちらは社員・座席情報取得を行う`getMaster.js`です・

```javascript:src/renderer/store/modules/getMaster.js
import Vue from 'vue'
import * as constants from '@/assets/constants'

const state = {
  seatInfo: [],
  empInfo: [],
  loginEmpName: ''
}

const mutations = {
  fetchSeatInfo (state, seatInfo) {
    state.seatInfo = seatInfo
  },
  fetchEmpInfo (state, empInfo) {
    state.empInfo = empInfo.empInfo
    state.loginEmpName = empInfo.loginEmpName
  },
  reset (state) {
    state.seatInfo = []
    state.empInfo = []
    state.loginEmpName = ''
  }
}

const actions = {
  fetchSeatInfo ({ commit }, token) {
    Vue.http.post('/seatwithemp/FetchSeatWithEmpInfo', token)
      .then((data) => {
        if (data.ProcessStatus === constants.STATUS_OK) {
          commit('fetchSeatInfo', data.SeatWithEmpInfo)
        }
      })
  },
  fetchEmpInfo ({ commit }, authInfo) {
    Vue.http.post('/emp/FetchEmpInfo', authInfo.token)
      .then((data) => {
        if (data.ProcessStatus === constants.STATUS_OK) {
          let loginEmpName = data.EmpInfo.find(emp => emp.EMP_NO === authInfo.loginEmpNO).DISPLAY_EMP_NM
          commit('fetchEmpInfo', { empInfo: data.EmpInfo, loginEmpName: loginEmpName })
        }
      })
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions
}
```
### namespace
`namespaced: true`にすることで、State、Mutation、ActionをModuleのパスに基づくnamespaceに入れることができます。

※[Vuex（日本語）モジュール　名前空間](https://vuex.vuejs.org/ja/modules.html)

### コンポーネントをバインドするヘルパー
State、Mutation、Actionは、それぞれ`mapState`、`mapMutations`、`mapActions`といったヘルパーを使用することで、対応するコンポーネントオプションを生成してくれます。

※[Vuex（日本語）コンポーネントをバインドするヘルパー](https://vuex.vuejs.org/ja/api.html)


ん？通信はどうなっているんだ(´・ω・｀)？

## 通信　～axios～
### axiosとは
ブラウザやNode.jsのためのPromiseベースのHTTPクライアントです。

beseURLを指定して、interceptorsでrequest/responseのエラーハンドリングを行っています。

```javascript:src/renderer/util/http-client.js
import axios from 'axios'
import * as constants from '@/assets/constants'
import * as messages from '@/assets/messages'

const client = axios.create({
  baseURL: 'http://xxx'
})

export default (Vue, { store }) => {
  client.interceptors.request.use((config) => {
    return config
  }, (error) => {
    store.commit('loading/showLoading', false)
    store.dispatch('modal/showError', messages.E_001)
    return Promise.reject(error)
  })

  client.interceptors.response.use((response) => {
    if (response.data.ProcessStatus === constants.STATUS_OK) {
      store.commit('modal/hideModal')
    } else if (response.data.ProcessStatus === constants.STATUS_TOKEN_ER) {
      store.dispatch('auth/logout')
      store.dispatch('modal/showError', response.data.ResponseMessage)
    } else {
      store.dispatch('modal/showError', response.data.ResponseMessage)
    }
    return response.data
  }, (error) => {
    store.commit('loading/showLoading', false)
    store.dispatch('modal/showError', messages.E_001)
    return Promise.reject(error)
  })

  Vue.http = Vue.prototype.$http = client
}
```
※[axios（英語）](https://github.com/axios/axios)

これで一通りの実装方法が見えてきました！
ページ遷移から座席表表示までを追ってみると…

1. Vueインスタンスのライフサイクルイベント`created`で、Vuexのヘルパー`mapActions`によりバインドされたAction`fetchSeatInfo`をDispatchする。
2. Action`fetchSeatInfo`では、APIで座席情報を取得し、Mutaiton`fetchSeatInfo`をCommitして、State`seatInfo`を更新する。
3. State`seatInfo`はComputedプロパティに設定されているので、State`seatInfo`の更新をトリガーに`Seat`コンポーネントのレンダリングが行われる。
4. `Seat`コンポーネントのディレクティブ`v-for`、`:class`、`:style`によって、それぞれの座席のスタイルが適用される。

このような流れになります！座席表表示まで完成です(｀･ω･´)！

ここからは一気に検索結果表示まで見ていきましょう。

```html:src/renderer/components/Chart/Search.vue
<template>
  <transition name="fade">
      <div class="search-layer">
          <img 
            class="icon"
            src="../../assets/images/search_icon.png"           
          >
          <div class="topChar">検索</div>
          <button           
            class="back" 
            type="button" 
            @click="hideSearch"
          >✖</button>
          <div>
              <input 
                class="searchword"
                type="text" 
                v-model="searchtxt"               
              >
                <img 
                  class="button"
                  src="../../assets/images/search_button.png"                 
                >
              </input>			
          </div>
          <div class="announceChar">{{ this.filterEmp(searchtxt).searchMessage }}</div>
          <button
            class="rslt"  
            type="button"                     
            v-for="emp in this.filterEmp(searchtxt).filteredEmp"
            :id="emp.EMP_NO"  
            :key="emp.EMP_NO" 
            @click="getpath" 
          >{{ emp.EMP_NO }} {{ emp.EMP_NM }}</button>
      </div>
  </transition>
</template>

<script>
  import { mapActions, mapMutations, mapGetters, mapState } from 'vuex'

  export default {
    data: function () {
      return {
        searchtxt: null
      }
    },
    computed: {
      ...mapState('auth', {
        token: state => state.token
      }),
      ...mapGetters({
        filterEmp: 'search/filterEmp'
      })
    },
    methods: {
      ...mapActions({
        getUserPath: 'getUserPath/getUserPath'
        }),
      ...mapMutations({
        hideSearch: 'search/hideSearch'
      }),

      getpath: function (event) {
        this.getUserPath({
          EmpNo: event.target.id,
          Token: this.token
        })
        this.hideSearch()
      }
    }
  }
</script>

<style scoped>
  /* 省略 */
</style>
```

```src/renderer/store/modules/search.js
import * as messages from '@/assets/messages'

const state = {
  show: false,
  searchMessage: ''
}

const getters = {
  filterEmp: (state, getters, rootState) => (seachText) => {
    if (!seachText) return []

    let filteredEmp = rootState.getMaster.empInfo.filter(emp => {
      let knj = false
      let kana = false
      if (emp.EMP_NM) knj = emp.EMP_NM.replace(/\s+/g, '').startsWith(seachText)
      if (emp.EMP_KANA_NM) kana = emp.EMP_KANA_NM.replace(/\s+/g, '').startsWith(seachText)

      return knj || kana
    })
    let searchMessage = ''
    if (filteredEmp.length > 0) {
      searchMessage = messages.I_001
    } else {
      searchMessage = messages.I_002
    }

    return { filteredEmp: filteredEmp, searchMessage: searchMessage }
  }
}

const mutations = {
  showSearch (state) {
    state.show = true
  },
  hideSearch (state) {
    state.show = false
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  getters
}
```

```src/renderer/store/modules/getUserPath.js
import Vue from 'vue'
import * as constants from '@/assets/constants'

const state = {
  userPath: []
}

const mutations = {
  setPath (state, userpath) {
    state.userPath = userpath.EmpLocation
  },
  reset (state) {
    state.userPath = []
  }
}

const actions = {
  getUserPath ({ commit }, empNo, token) {
    Vue.http.post('/emplocation/FetchAllEmpLocationInfo', empNo, token)
      .then((data) => {
        if (data.ProcessStatus === constants.STATUS_OK) {
          commit('setPath', { EmpLocation: data.EmpLocation })
        }
      })
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions
}
```

あれ？`transition`？`getters`ってなんだろう(´・ω・｀)？

## transition
### transitionとは
`v-if`や`v-show`による条件付きのレンダリングや動的コンポーネントにentering/leaving トランジションを追加することができる、ラッパーコンポーネントです。

以下の6つのクラスが用意されています。
1. v-enter
2. v-enter-active
3. v-enter-to
4. v-leave
5. v-leave-active
6. v-leave-to

![transition.png](https://qiita-image-store.s3.amazonaws.com/0/163867/a40d1715-5577-365f-8719-b027942b8272.png)

`v-`の部分はtransitionコンポーネントの`name`属性に指定した値が設定されます。
`App.vue`で設定していたのは、このtransitionのスタイルになります。

```css:src/renderer/App.vue
  .fade-enter-active, .fade-leave-active {
    transition: opacity .3s
  }
  .fade-enter, .fade-leave-to{
    opacity: 0
  }
```
#### 動的コンポーネント
`component`要素の`is`属性に、コンポーネント名を指定することでコンポーネントを動的に設定することができます。
このアプリでは、ModalコンポーネントでAlertやErrorコンポーネントの切り替えを行っています。

```html:src/renderer/components/Modal.vue
<template>
  <transition name="fade">
    <div class="alert-layer" v-if="show">
        <component :is="modalName" :message="message"></component>
    </div>
  </transition>
</template>
```

※[Vue.js（日本語）Enter/Leave とトランジション一覧](https://jp.vuejs.org/v2/guide/transitions.html)

## State、Mutation、ActionとGetter
StoreにはGetterを作成することもできます。
このアプリでは検索結果の絞り込みに使用しています。

検索テキストボックスの入力をトリガーに、State`empInfo`を前方一致検索しています。
引数にはこのモジュール内の`state`だけでなく、グローバルな`rootState`も設定することができます。

State、Mutation、Actionと同様に、Getterにも`mapGetters`ヘルパーがあります。

※[Vuex（日本語）ゲッター](https://vuex.vuejs.org/ja/getters.html)

それでは、検索から検索結果表示までを追ってみると…

1. `Search`コンポーネントのcomputedプロパティ`filterEmp`により、検索テキストボックスへの入力をトリガーに検索結果であるState`empInfo`を取得する。
2. ディレクティブ`v-for`によって、社員名ボタンが表示される。
3. 社員名ボタンのclickイベントで、Action`getUserPath`がDispatchされ、State`userPath`が更新される。
4. State`userPath`の更新をトリガーに、`Chart`コンポーネントの`:class`が再評価され、`searched`が適用される。

ついに、検索結果表示まで完成です(｀･ω･´)！

# 参考
[Electron（日本語）](https://electronjs.org/)  
[Vue.js（日本語）](https://jp.vuejs.org/index.html)  
[electron-vue（日本語）](https://simulatedgreg.gitbooks.io/electron-vue/content/ja/)  
[Vue.js入門 ―最速で作るシンプルなWebアプリケーション](http://gihyo.jp/dev/serial/01/vuejs)  
[Practice on embedding Node.js into Atom Editor by Cheng Zhao](https://speakerdeck.com/zcbenz/practice-on-embedding-node-dot-js-into-atom-editor)  
[The Progressive Framework](https://docs.google.com/presentation/d/1WnYsxRMiNEArT3xz7xXHdKeH1C-jT92VxmptghJb5Es/edit#slide=id.p)  
[ElectronでVue.jsを始める](https://qiita.com/SatoTakumi/items/fd79672d7eb8a9b4a0bb)  
[ChromiumからElectronを眺める](https://qiita.com/seihmd/items/8caf3af3b7a612b3c628)  
