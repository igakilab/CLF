using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// MonoBehaviourPunCallbacks���p�����āAphotonView�v���p�e�B���g����悤�ɂ���
public class AvatarNameDisplay : MonoBehaviourPunCallbacks
{
    public string name;
    private void Start()
    {
        var nameLabel = GetComponent<TextMeshPro>();
        // �v���C���[���ƃv���C���[ID��\������
        nameLabel.text = PhotonNetwork.NickName;//$"{photonView.Owner.NickName}{photonView.OwnerActorNr}";
        //GameObject.Find("photonControler").GetComponent<SampleScene>().avatarName = nameLabel.text;
    }
}