using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warpController : MonoBehaviour
{
    public GameObject gate1;
    public GameObject gate2;
    public GameObject gate3;
    public GameObject gate4;

    GameObject[] outGates;

    void Start()
    {
        outGates = new GameObject[] { gate1, gate2, gate3, gate4 };
    }

    private string playerTag = "Player";
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == playerTag)
        {
            Debug.Log("プレイヤーはワープした！");
            collision.transform.position = outGates[Random.Range(0,4)].transform.position;
        }

    }
}
