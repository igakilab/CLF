using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    private float time = 60.0f;
    public Text timerText;
    public bool isTimeUp;
 	public GameObject photonController;
    void Start()
    {
        isTimeUp = false;
        photonController = GameObject.Find("photonControler");
    }

    void Update()
    {
        if (0 < time  && photonController.GetComponent<SampleScene>().isGaming())
        {
            time -= Time.deltaTime;
            timerText.text = time.ToString("F1");
        }
        else if (time < 0)
        {
            isTimeUp = true;
        }
    }
}