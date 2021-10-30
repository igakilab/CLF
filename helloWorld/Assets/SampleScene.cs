using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

// MonoBehaviourPunCallbacks���p�����āAPUN�̃R�[���o�b�N���󂯎���悤�ɂ���
public class SampleScene : MonoBehaviourPunCallbacks
{
    public GameObject hostButton;
    public GameObject otherText;
    public Text countText;
    bool Gaming;
    private void Start()
    {
        // �v���C���[���g�̖��O��"Player"�ɐݒ肷��
        PhotonNetwork.NickName = "Player";
        // PhotonServerSettings�̐ݒ���e���g���ă}�X�^�[�T�[�o�[�֐ڑ�����
        PhotonNetwork.ConnectUsingSettings();
        this.Gaming = false;
    }

    // �}�X�^�[�T�[�o�[�ւ̐ڑ��������������ɌĂ΂��R�[���o�b�N
    public override void OnConnectedToMaster()
    {
        // "Room"�Ƃ������O�̃��[���ɎQ������i���[�������݂��Ȃ���΍쐬���ĎQ������j
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions(), TypedLobby.Default);

        
    }

    // �Q�[���T�[�o�[�ւ̐ڑ��������������ɌĂ΂��R�[���o�b�N
    public override void OnJoinedRoom()
    {
        // �����_���ȍ��W�Ɏ��g�̃A�o�^�[�i�l�b�g���[�N�I�u�W�F�N�g�j�𐶐�����
        var position = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
        PhotonNetwork.Instantiate("Avatar", position, Quaternion.identity);
        Debug.Log("�A�o�^�[����");

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

    //MasterButton����Ăяo�����
    public void PushMasterButton()
	{
        Debug.Log("�Q�[���J�n!(�z�X�g)");
        //photonView.RPC(nameof(RpcGameStart), RpcTarget.AllBuffered);
        photonView.RPC(nameof(RpcGameStart), RpcTarget.AllBuffered);
    }

    //�Q�[���J�n����
    [PunRPC]
    private void RpcGameStart()
	{
        this.Gaming = true;
        Debug.Log("�Q�[���J�n!");
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