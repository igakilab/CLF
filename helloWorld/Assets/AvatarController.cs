using Photon.Pun;
using UnityEngine;

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
            this.rb.velocity = input*5.0f;

            Vector3 playerPos = this.transform.position;
            camera.transform.position = new Vector3(playerPos.x, playerPos.y, -10);
        }
    }
}
