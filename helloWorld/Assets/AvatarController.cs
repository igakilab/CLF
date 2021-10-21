using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

// MonoBehaviourPunCallbacks���p�����āAphotonView�v���p�e�B���g����悤�ɂ���
public class AvatarController : MonoBehaviourPunCallbacks
{
    Camera camera;
    Rigidbody2D rb;
    private void Start()
	{
        camera = Camera.main;
        this.rb = GetComponent<Rigidbody2D>();
	}

    private void Update()
    {
        
        // ���g�����������I�u�W�F�N�g�����Ɉړ��������s��
        if (photonView.IsMine)
        {
            var input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            //transform.Translate(6f * Time.deltaTime * input.normalized);
            //this.rb.AddForce(input);
            //this.rb.velocity = input*5.0f;
            this.rb.AddForce(input);
            Vector3 playerPos = this.transform.position;
            camera.transform.position = new Vector3(playerPos.x, playerPos.y, -10);
        }
    }

    //private string playerTag = "Player";
    private string chestTag = "Chest";
    private int chestCount = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("�����ƐڐG����");
        /*if (collision.collider.tag == playerTag)
        {
            SceneManager.LoadScene("GameOverScene");
            Debug.Log("�G�ƐڐG�����I");
        
        }*/
        if(collision.collider.tag == chestTag)
        {
            Debug.Log("�󔠂ƐڐG�����I");
            Debug.Log(++chestCount);
        }
            
    }
}
