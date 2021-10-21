using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

// MonoBehaviourPunCallbacksを継承して、photonViewプロパティを使えるようにする
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
        
        // 自身が生成したオブジェクトだけに移動処理を行う
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
        // Debug.Log("何かと接触した");
        /*if (collision.collider.tag == playerTag)
        {
            SceneManager.LoadScene("GameOverScene");
            Debug.Log("敵と接触した！");
        
        }*/
        if(collision.collider.tag == chestTag)
        {
            Debug.Log("宝箱と接触した！");
            Debug.Log(++chestCount);
        }
            
    }
}
