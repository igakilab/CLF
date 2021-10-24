using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestController : MonoBehaviour
{
    public int createRange = 30;
    //public int chestNumber = 2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void chestCreate()
    {
        Vector2 chestPosition = new Vector2();
        
        chestPosition.x = Random.Range(-29, 29);
        chestPosition.y = Random.Range(-29, 29);
        PhotonNetwork.Instantiate("Kaizoku_Takarabako", chestPosition, Quaternion.identity);
        Debug.Log("宝箱を生成した！(x:" + chestPosition.x + " y:" + chestPosition.y + ")");
        
    }

    private string playerTag = "Player";
    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.collider.tag == playerTag)
        {
            Debug.Log("宝箱はプレイヤーと接触した！");
            Destroy(this.gameObject);
            if(PhotonNetwork.IsMasterClient)
            chestCreate();
        }

    }

}
