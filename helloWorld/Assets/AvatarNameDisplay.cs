using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// MonoBehaviourPunCallbacksを継承して、photonViewプロパティを使えるようにする
public class AvatarNameDisplay : MonoBehaviourPunCallbacks
{
    public string name;
    private void Start()
    {
        var nameLabel = GetComponent<TextMeshPro>();
        // プレイヤー名とプレイヤーIDを表示する
        nameLabel.text = PhotonNetwork.NickName;//$"{photonView.Owner.NickName}{photonView.OwnerActorNr}";
        //GameObject.Find("photonControler").GetComponent<SampleScene>().avatarName = nameLabel.text;
    }
}