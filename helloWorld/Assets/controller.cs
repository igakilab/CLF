using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    [SerializeField]
    //float SPEED = 1.0f;
    private Rigidbody2D rigidBody;
    private Vector2 inputAxis;
    private bool up = false, down = false, left = false, right = false;
    void Start()
    {
        // �I�u�W�F�N�g�ɐݒ肵�Ă���Rigidbody2D�̎Q�Ƃ��擾����
        this.rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // x,���̓��͒l�𓾂�
        // ���ꂼ��+��-�̒l�Ɠ��͂̊֘A�t����Input Manager�Őݒ肳��Ă���
        //inputAxis.x = Input.GetAxis("Horizontal");
        //inputAxis.y = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.up = true;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.down = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.left = true;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.right = true;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            this.up = false;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            this.down = false;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            this.left = false;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            this.right = false;
        }

        if (this.up)
        {
            this.rigidBody.AddForce(transform.up * 1.0f);
        }
        if (this.down)
        {
            this.rigidBody.AddForce(-transform.up * 1.0f);
        }
        if (this.right)
        {
            this.rigidBody.AddForce(transform.right * 1.0f);
        }
        if (this.left)
        {
            this.rigidBody.AddForce(-transform.right * 1.0f);
        }
        /*if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(2, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(-2, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Translate(0, 2, 0);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.Translate(0, -2, 0);
        }*/
    }

    /*private void FixedUpdate()
    {
        // ���x��������
        rigidBody.velocity = inputAxis.normalized * SPEED;
    }*/
}
