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
// MonoBehaviourPunCallbacks���p�����āAPUN�̃R�[���o�b�N���󂯎���悤�ɂ���
public class SampleScene : MonoBehaviourPunCallbacks
{
    public GameObject hostButton;
    public GameObject otherText;
    public Text countText;//�����̃|�C���g����\������e�L�X�g�{�b�N�X
    public Text rankText;//�����̃|�C���g����\������e�L�X�g�{�b�N�X
    static public RankData[] ranking;//�����L���O�p
    static public int playerNum;//�����L���O�p
    static public String rankString = "";
    bool Gaming;
    public string avatarName;
    private void Start()
    {
        // �v���C���[���g�̖��O��"Player"�ɐݒ肷��
        PhotonNetwork.NickName = "Player" + UnityEngine.Random.Range(0, 10000);
        // PhotonServerSettings�̐ݒ���e���g���ă}�X�^�[�T�[�o�[�֐ڑ�����
        PhotonNetwork.ConnectUsingSettings();
        this.Gaming = false;
        ranking = new RankData[16];
        playerNum = 0;
        //DontDestroyOnLoad(rankText);
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
        var position = new Vector3(UnityEngine.Random.Range(-3f, 3f), UnityEngine.Random.Range(-3f, 3f));
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
        viewCountText(0);


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
        // ���[�����쐬�����v���C���[�́A���݂̃T�[�o�[�������Q�[���̊J�n�����ɐݒ肷��

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