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
        // まだルームに参加していない場合は更新しない
        if (!PhotonNetwork.InRoom) { return; }

        //if (photonController.GetComponent<SampleScene>().isGaming()) { return; }

        // まだゲームの開始時刻が設定されていない場合は更新しない
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