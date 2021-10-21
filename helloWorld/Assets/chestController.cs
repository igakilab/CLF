using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestController : MonoBehaviour
{
    public float createRange = 5f;
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
        
        chestPosition.x = Random.Range(-createRange, createRange);
        chestPosition.y = Random.Range(-createRange, createRange);
        PhotonNetwork.Instantiate("Kaizoku_Takarabako", chestPosition, Quaternion.identity);
        Debug.Log("宝箱を生成した！");
        
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
