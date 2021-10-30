using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

// MonoBehaviourPunCallbacksを継承して、PUNのコールバックを受け取れるようにする
public class SampleScene : MonoBehaviourPunCallbacks
{
    public GameObject hostButton;
    public GameObject otherText;
    public Text countText;
    bool Gaming;
    private void Start()
    {
        // プレイヤー自身の名前を"Player"に設定する
        PhotonNetwork.NickName = "Player";
        // PhotonServerSettingsの設定内容を使ってマスターサーバーへ接続する
        PhotonNetwork.ConnectUsingSettings();
        this.Gaming = false;
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
        var position = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
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

    public bool isGaming()
	{
        return Gaming;
	}

    public void viewCountText(int point)
	{
        countText.text = point.ToString()+"pt";
	}
}