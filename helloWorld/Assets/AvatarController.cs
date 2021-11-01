using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

// MonoBehaviourPunCallbacksを継承して、photonViewプロパティを使えるようにする
public class AvatarController : MonoBehaviourPunCallbacks
{
    Camera camera;
    Rigidbody2D rb;
    private GameObject photonController;
    private GameObject timeUp;
    public static int chestCount = 0;
    private void Start()
	{
        camera = Camera.main;
        this.rb = GetComponent<Rigidbody2D>();
        photonController = GameObject.Find("photonControler");
        timeUp = GameObject.Find("GameObject");
	}


    private void Update()
    {
        if (timeUp.GetComponent<CountDown>().isTimeUp == true)
        {
            // ルームから退出する
            PhotonNetwork.LeaveRoom();
            SceneManager.LoadScene("GameOverScene");
        }

        // 自身が生成したオブジェクトだけに移動処理を行う
        if (photonView.IsMine && photonController.GetComponent<SampleScene>().isGaming())
        {
            
            var input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            //transform.Translate(6f * Time.deltaTime * input.normalized);
            //this.rb.AddForce(input);
            //this.rb.velocity = input*5.0f;
            this.rb.AddForce(1000*input * Time.deltaTime);
            Vector3 playerPos = this.transform.position;
            camera.transform.position = new Vector3(playerPos.x, playerPos.y, -10);
            if (this.transform.position.x > 30 || this.transform.position.y > 30 || this.transform.position.x < -30 || this.transform.position.y < -30)
            {
                Vector3 init = new Vector3(0, 0, 0);
                this.transform.position = init;
            }
			if (Input.GetKeyDown(KeyCode.R))
			{
                Vector3 init = new Vector3(0, 0, 0);
                this.transform.position = init;
            }
        }
    }

    //private string playerTag = "Player";
    private string chestTag = "Chest";
    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (photonView.IsMine && collision.collider.tag == chestTag)
        {
            Debug.Log("宝箱と接触した！");
            photonController.GetComponent<SampleScene>().viewCountText(++chestCount);
            
        }

    }
}
