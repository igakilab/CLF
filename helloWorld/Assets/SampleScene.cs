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
    public Text countText;//自分のポイント数を表示するテキストボックス
    public Text rankText;//自分のポイント数を表示するテキストボックス
    static public RankData[] ranking;//ランキング用
    static public int playerNum;//ランキング用
    static public String rankString = "";
    bool Gaming;
    public string avatarName;
    private void Start()
    {
        // プレイヤー自身の名前を"Player"に設定する
        PhotonNetwork.NickName = "Player" + UnityEngine.Random.Range(0, 10000);
        // PhotonServerSettingsの設定内容を使ってマスターサーバーへ接続する
        PhotonNetwork.ConnectUsingSettings();
        this.Gaming = false;
        ranking = new RankData[16];
        playerNum = 0;
        //DontDestroyOnLoad(rankText);
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
        viewCountText(0);


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
        // ルームを作成したプレイヤーは、現在のサーバー時刻をゲームの開始時刻に設定する

        if (PhotonNetwork.IsMasterClient)
        {

            PhotonNetwork.CurrentRoom.SetStartTime(PhotonNetwork.ServerTimestamp);

        }
    }

    [PunRPC]
    private void RpcSendCount(string name,int point)
	{
        Debug.Log(name + point.ToString());
        int i;
        for(i = 0;i < playerNum; i++)
		{
			if (ranking[i].name.Equals(name))
			{
                ranking[i].point = point;
                break;
			}
		}
        if(playerNum < 15 && i == playerNum)
		{
            ranking[playerNum++] = new RankData(name, point);
		}
        /*for(i = 0;i < 15; i++)
		{
            for(int j = 0;j < 16; j++)
			{
                if(ranking[i].point < ranking[j].point)
				{
                    RankData swap;
                    swap = ranking[j];
                    ranking[j] = ranking[i];
                    ranking[i] = swap;

                }
			}
		}*/
        rankString = "";
        for (i = 0;i < playerNum; i++)
		{
            rankString += ranking[i].name + ":" + ranking[i].point.ToString() + "\n";
		}
        rankText.text = rankString;
    }

    public bool isGaming()
	{
        return Gaming;
	}

    public void viewCountText(int point)
	{
        countText.text = PhotonNetwork.NickName + ": " + point.ToString()+"pt";
        photonView.RPC(nameof(RpcSendCount), RpcTarget.AllBuffered, PhotonNetwork.NickName, point);
        Debug.Log("viewCountText:" + PhotonNetwork.NickName);
    }

    public static String getRankString()
	{
        return rankString;
	}
}