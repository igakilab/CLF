# TreasureHunter

## 概要

TreasureHunterは、PCのブラウザ上で遊ぶことができるオンラインマルチプレイ対応のタイムアタック式宝探しゲームです。セットアップ・運用方法のマニュアルを以下に記述しています。

## 準備

### Unityのインストールおよびモジュールの追加

まず、[UnityHub](https://unity3d.com/jp/get-unity/download)をインストールしてください。
![Unity追加](https://user-images.githubusercontent.com/75965403/142373852-0bb38ac7-01ad-43f1-b01a-755e4fcab9f4.png)
次にUnityHubから`Unity(2020.3.18f1)`をダウンロードしてインストールしてください．インストールする際，追加するモジュールを聞かれるので`WebGL Build Support`にチェックを入れてインストールしてください。  
![モジュール追加](https://user-images.githubusercontent.com/75965403/142373844-2e1a6705-1d4c-4835-8290-a1ff20269e9a.png)

### TreasureHunterのダウンロード

[こちら](https://github.com/igakilab/CLF)からTreasureHunterをダウンロードして解凍してください。

### プロジェクトの起動

UnityHubの`プロジェクト`の`リストに追加`からダウンロードして解凍した`helloWorld`フォルダを選択して追加してください．  

追加後、プロジェクトをクリックしUnityを起動します。起動後に`Unity Editor Update Check`ウィンドウが開いた場合は`Skip new version`ボタンをクリックしてください。  
 

### Photonアカウント作成とサインイン

Photon Cloudを利用するには、アプリケーションを登録してアプリケーションIDを発行する必要があります。最初に[公式サイト](https://www.photonengine.com/ja-JP/PUN)で（アカウントの登録を済ませて）サインインしてください。


### アプリケーションの作成

サインイン後のダッシュボード画面で`新しくアプリを作成する`ボタンを押すと、新しいアプリケーションの作成画面になります。Photonの種別を`Photon PUN`にして、好きなアプリケーション名を入力したら`作成する`ボタンを押してください。正しく作成されると、ダッシュボード画面からアプリケーションIDが確認できるようになります。


### アセットのインポート

Unityのプロジェクトを開いて、以下のアセットをインポートしてください。
[アセット(PUN2)](https://assetstore.unity.com/packages/tools/network/pun-2-free-119922)


### セットアップ

アセットのインポートが正常に終了すると、自動的に`PUN Wizard`が開きます。先ほど取得したアプリケーションIDを入力して`Setup Project`を押してください。(自動で`PUN Wizard`が開かなかった場合は、メニューバーの`Window`>`Photon Unity Networking`>`PUN Wizard`から、手動で`PUN Wizard`を開くことができます。)

セットアップが行われると、PUN2の設定ファイル（`PhotonServerSettings`）が生成されます。これで初期設定は完了です。設定内容はデフォルトのままでも問題ないですが、以下にオススメの設定を記載します。

###ビルド設定をWebGLに変更
`File`>`Build Settings`から`Build Settings`ウインドウを開き`WebGL`を選択して`Switch Platform`ボタンをクリックします。

切り替えが完了すると`Switch Platform`ボタンのところが`Build`ボタンに変わるのでクリックしてビルドします。


### Netlifyでサイトを公開

