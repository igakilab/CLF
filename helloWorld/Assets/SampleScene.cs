using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RankData
{
    public String name;
    public int point;
    public RankData(string name, int point)
	{
        this.name = name;
        this.point = point;
	}
}
// MonoBehaviourPunCallbacksを継承して、PUNのコールバックを受け取れるようにする
public class SampleScene : MonoBehaviourPunCallbacks
{
    public GameObject hostButton;
    public GameObject otherText;
    public Text countText;
    static public RankData[] ranking;
    bool Gaming;
    private void Start()
    {
        // プレイヤー自身の名前を"Player"に設定する
        PhotonNetwork.NickName = "Player"+ UnityEngine.Random.Range(0,10000).ToString();
        // PhotonServerSettingsの設定内容を使ってマスターサーバーへ接続する
        PhotonNetwork.ConnectUsingSettings();
        this.Gaming = false;
        ranking = new RankData[16];
    }

    // マスターサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnConnectedToMaster()
    {
        // "Room"という名前のルームに参加する（ルームが存在しなければ作成して参加する）
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions(), TypedLobby.Default);

        
    }

    // ゲームサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnJoinedRoom()
    {
        // ランダムな座標に自身のアバター（ネットワークオブジェクト）を生成する
        var position = new Vector3(UnityEngine.Random.Range(-3f, 3f), UnityEngine.Random.Range(-3f, 3f));
        PhotonNetwork.Instantiate("Avatar", position, Quaternion.identity);
        Debug.Log("アバター生成");

        if (PhotonNetwork.IsMasterClient)
        {
            hostButton.SetActive(true);
            Debug.Log("isMaster");
        }
        else
        {
            otherText.SetActive(true);
            Debug.Log("isntMaster");
        }
    }

    //MasterButtonから呼び出される
    public void PushMasterButton()
	{
        Debug.Log("ゲーム開始!(ホスト)");
        //photonView.RPC(nameof(RpcGameStart), RpcTarget.AllBuffered);
        photonView.RPC(nameof(RpcGameStart), RpcTarget.AllBuffered);
    }

    //ゲーム開始処理
    [PunRPC]
    private void RpcGameStart()
	{
        this.Gaming = true;
        Debug.Log("ゲーム開始!");
	}

    [PunRPC]
    private void RpcSendCount(string name,int point)
	{
        Debug.Log(name + point.ToString());
	}

    public bool isGaming()
	{
        return Gaming;
	}

    public void viewCountText(int point)
	{
        countText.text = PhotonNetwork.NickName + ": " + point.ToString()+"pt";
        photonView.RPC(nameof(RpcSendCount), RpcTarget.AllBuffered, PhotonNetwork.NickName, point);
    }
}