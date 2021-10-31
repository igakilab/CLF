using Photon.Pun;
using TMPro;
using UnityEngine;

public class GameRoomTimeDisplay : MonoBehaviour
{
    private TextMeshProUGUI timeLabel;
    public GameObject countdown;
    public GameObject photonController;

    private void Start()
    {
        timeLabel = GetComponent<TextMeshProUGUI>();
        photonController = GameObject.Find("photonControler");
        countdown = GameObject.Find("GameObject");
    }

    private void Update()
    {
        // �܂����[���ɎQ�����Ă��Ȃ��ꍇ�͍X�V���Ȃ�
        if (!PhotonNetwork.InRoom) { return; }

        //if (photonController.GetComponent<SampleScene>().isGaming()) { return; }

        // �܂��Q�[���̊J�n�������ݒ肳��Ă��Ȃ��ꍇ�͍X�V���Ȃ�
        if (!PhotonNetwork.CurrentRoom.TryGetStartTime(out int timestamp)) { return; }

        if (0 < countdown.GetComponent<CountDown>().true_time && photonController.GetComponent<SampleScene>().isGaming()) {
            timeLabel.text = countdown.GetComponent<CountDown>().true_time.ToString("f1");
        }
        else if (countdown.GetComponent<CountDown>().true_time < 0)
        {
            return;
        }
    }
}