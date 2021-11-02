using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resultViewer : MonoBehaviour
{
    public Text text;
    public Text countText;
    // Start is called before the first frame update
    void Start()
    {
        text.text = SampleScene.getRankString();
        countText.text = SampleScene.getCountString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
