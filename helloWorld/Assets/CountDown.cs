using Photon.Pun;
using TMPro;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    private float time = 60.0f;
    public float true_time = 60.0f;
    public bool isTimeUp;
    public GameObject photonController;

    private void Start()
    {
        isTimeUp = false;
        photonController = GameObject.Find("photonControler");
    }

    private void Update()
    {
        // まだルームに参加していない場合は更新しない
        if (!PhotonNetwork.InRoom) { return; }

        //if (photonController.GetComponent<SampleScene>().isGaming()) { return; }

        // まだゲームの開始時刻が設定されていない場合は更新しない
        if (!PhotonNetwork.CurrentRoom.TryGetStartTime(out int timestamp)) { return; }

        // ゲームの経過時間を求めて、小数第一位まで表示する
        float elapsedTime = Mathf.Max(0f, unchecked(PhotonNetwork.ServerTimestamp - timestamp) / 1000f);
        if (0 < true_time && photonController.GetComponent<SampleScene>().isGaming())
        {
            true_time = time - elapsedTime;
        }
        else if (true_time < 0)
        {
            isTimeUp = true;
        }
    }
}