using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obsController : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Vector3 velocity;
    private float max_speed = 20f, min_speed = -20f;

    void Start()
    {
        this.rigid = GetComponent<Rigidbody2D>();
        //velocity = new Vector3(max_speed, min_speed, 0);
        velocity = new Vector3(max_speed, 0, 0);
    }

    void FixedUpdate()
    {

        rigid.MovePosition(this.transform.position + velocity * Time.deltaTime);

        if (this.transform.position.x >= 20)
        {
            velocity.x = min_speed;
        }
        if (this.transform.position.x <= -20)
        {
            velocity.x = max_speed;
        }/*
        if (this.transform.position.y >= 10)
        {
            velocity.y = min_speed;
        }
        if (this.transform.position.y <= -10)
        {
            velocity.y = max_speed;
        }*/


    }

}
