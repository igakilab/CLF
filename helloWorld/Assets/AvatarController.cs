using Photon.Pun;
using UnityEngine;

// MonoBehaviourPunCallbacks���p�����āAphotonView�v���p�e�B���g����悤�ɂ���
public class AvatarController : MonoBehaviourPunCallbacks
{
    Camera camera;

    private void Start()
	{
        camera = Camera.main;
	}

    private void Update()
    {
        
        // ���g�����������I�u�W�F�N�g�����Ɉړ��������s��
        if (photonView.IsMine)
        {
            var input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
            transform.Translate(6f * Time.deltaTime * input.normalized);

            Vector3 playerPos = this.transform.position;
            camera.transform.position = new Vector3(playerPos.x, playerPos.y, -10);
        }
    }
}
