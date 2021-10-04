using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaserController : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        this.rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = this.transform.position.x;//これの座標
        float y = this.transform.position.y;
        float px = player.transform.position.x;//プレイヤーの座標
        float py = player.transform.position.y;
        float vx, vy;//これの移動ベクトル
        if (x < px)
        {
            vx = 3.0f;
        }
        else
        {
            vx = -3.0f;
        }
        if (y < py)
        {
            vy = 3.0f;
        }
        else
        {
            vy = -3.0f;
        }
        this.rigid.velocity = new Vector2(vx, vy);
    }
}
