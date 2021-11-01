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
        // �܂����[���ɎQ�����Ă��Ȃ��ꍇ�͍X�V���Ȃ�
        if (!PhotonNetwork.InRoom) { return; }

        //if (photonController.GetComponent<SampleScene>().isGaming()) { return; }

        // �܂��Q�[���̊J�n�������ݒ肳��Ă��Ȃ��ꍇ�͍X�V���Ȃ�
        if (!PhotonNetwork.CurrentRoom.TryGetStartTime(out int timestamp)) { return; }

        // �Q�[���̌o�ߎ��Ԃ����߂āA�������ʂ܂ŕ\������
        float elapsedTime = Mathf.Max(0f, unchecked(PhotonNetwork.ServerTimestamp - timestamp) / 1000f);
        if (0 < true_time && photonController.GetComponent<SampleScene>().isGaming())
        {
            true_time = time - elapsedTime;
        }
        else if (true_time <= 0)
        {
            isTimeUp = true;
        }
    }
}