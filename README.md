# TreasureHunter

## 概要

TreasureHunterは、PCのブラウザ上で遊ぶことができるオンラインマルチプレイ対応のスコアアタック式宝探しゲームです。セットアップ・運用方法のマニュアルを以下に記述しています。

## 準備

### Unityのインストールおよびモジュールの追加

まず、[UnityHub](https://unity3d.com/jp/get-unity/download)をインストールしてください。
![Unity追加](https://user-images.githubusercontent.com/75965403/142373852-0bb38ac7-01ad-43f1-b01a-755e4fcab9f4.png)
次にUnityHubから`Unity`をダウンロードしてインストールしてください．インストールする際，追加するモジュールを聞かれるので`WebGL Build Support`にチェックを入れてインストールしてください。  
![モジュール追加](https://user-images.githubusercontent.com/75965403/142373844-2e1a6705-1d4c-4835-8290-a1ff20269e9a.png)

### TreasureHunterのダウンロード

[こちら](https://github.com/igakilab/CLF)の`Code`から`Download ZIP`を選択し、TreasureHunterをダウンロードして解凍してください。
![リポジトリダウンロード](https://user-images.githubusercontent.com/75965403/143399474-b537bf3d-9385-46af-8a9e-9b45d47f7937.png)




### プロジェクトの起動

UnityHubの`プロジェクト`の`リストに追加`からダウンロードして解凍した`helloWorld`フォルダを選択して追加してください．  

追加後、プロジェクトをクリックしUnityを起動します。起動後に`Unity Editor Update Check`ウィンドウが開いた場合は`Skip new version`ボタンをクリックしてください。  
 

### Photonアカウント作成とサインイン

Photon Cloudを利用するには、アプリケーションを登録してアプリケーションIDを発行する必要があります。最初に[公式サイト](https://www.photonengine.com/ja-JP/PUN)で（アカウントの登録を済ませて）サインインしてください。


### アプリケーションの作成

サインイン後のダッシュボード画面で`新しくアプリを作成する`ボタンを押すと、新しいアプリケーションの作成画面になります。Photonの種別を`Photon PUN`にして、好きなアプリケーション名を入力したら`作成する`ボタンを押してください。
![アプリケーション](https://user-images.githubusercontent.com/75965403/143398077-256f4a3d-33b3-413e-a94f-2b081adad5dc.png)

正しく作成されると、ダッシュボード画面からアプリケーションIDが確認できるようになります。
![アプリケーションID](https://user-images.githubusercontent.com/75965403/143397921-8e8ce2f8-5c77-476c-962b-2e6f3c99f1f6.png)


### アセットのインポート

Unityのプロジェクトを開いて、以下のアセットをインポートしてください。

https://assetstore.unity.com/packages/tools/network/pun-2-free-119922


### セットアップ

アセットのインポートが正常に終了すると、自動的に`PUN Wizard`が開きます。先ほど取得したアプリケーションIDを入力して`Setup Project`を押してください。(自動で`PUN Wizard`が開かなかった場合は、メニューバーの`Window`>`Photon Unity Networking`>`PUN Wizard`から、手動で`PUN Wizard`を開くことができます。)
![SetUP_1](https://user-images.githubusercontent.com/75965403/143400465-f710bf1a-e9de-4904-afbe-62c7c85db39c.png)
![SetUP_2](https://user-images.githubusercontent.com/75965403/143400533-88f0ff3c-4a89-4497-b7cd-0d04f924df31.png)

セットアップが行われると、PUN2の設定ファイル（`PhotonServerSettings`）が生成されます。これで初期設定は完了です。設定内容はデフォルトのままで問題ありません。

### ビルド設定をWebGLに変更
`File`>`Build Settings`から`Build Settings`ウインドウを開き`WebGL`を選択して`Switch Platform`ボタンをクリックします。
![WebGL](https://user-images.githubusercontent.com/75965403/143400404-4d0664a5-7cb2-426e-a4a2-8371f38faba9.png)

切り替えが完了すると`Switch Platform`ボタンのところが`Build`ボタンに変わるのでクリックしてビルドします。


### Netlifyでサイトを公開

GitHubで新しいリポジトリを作成し、ビルドして生成された`Buildフォルダ`、`TemplateDataフォルダ`、`index.html`をプッシュしてください。
[Netlify](https://app.netlify.com/)にアクセスし，`GitHub`をクリックして手順に従い登録をしてください。

登録が完了すると以下のようなホーム画面に遷移するので`New site from Git`をクリックしてください。 

`Github`をクリックしてください。  

自分のGithubのリポジトリ一覧が表示されるので，先程作成したリポジトリをクリックしてください。  

`Deploy site`をクリックしてください。  

デプロイが完了するとサイトのURLが表示されます。  

## ゲームの始め方

1.Netlifyで公開したサイトのURLにアクセスしゲームを読み込みます。
2.Startボタンをクリックし、サーバーに接続します。
3.参加者がサーバーに参加するのを待ち、最初に接続した人にのみ表示されるStartボタンを押せばゲームが開始します。

![image](https://user-images.githubusercontent.com/75965403/143404093-f686735a-07ed-4e5d-9844-36c57f3647a2.png)

## 操作方法
移動：十字キー  
画面上に出てくるボタン：マウスクリック  
稀に壁に埋まった時：Rキーで抜け出せます  



