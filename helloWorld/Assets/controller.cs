using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controller : MonoBehaviour
{
    Rigidbody2D rigid;
    float speed = 5.0f;
    float vx = 0, vy = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.rigid = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.vx = -speed;
            if (Input.GetKey(KeyCode.RightArrow))
            {
                this.vx = 0;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            this.vx = +speed;
        }
        else
        {
            this.vx = 0;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.vy = -speed;
            if (Input.GetKey(KeyCode.UpArrow))
            {
                this.vy = 0;
            }
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            this.vy = +speed;
        }
        else
        {
            this.vy = 0;
        }

        this.rigid.velocity = new Vector2(this.vx, this.vy);
        */
    }

    private string enemyTag = "Enemy";
    private string chestTag = "Chest";

    #region//?ڐG????
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == enemyTag)
        {
            SceneManager.LoadScene("GameOverScene");
            Debug.Log("?G?ƐڐG?????I");
        }
        else if (collision.collider.tag == chestTag)
        {
            //SceneManager.LoadScene("GameOverScene");
            
            Debug.Log("?󔠂ƐڐG?????I");
        }
    }

    
    
    #endregion
}
