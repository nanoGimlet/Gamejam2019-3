using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{

    public Text scoreText;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        score = CameraController.maxh;
        this.scoreText = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        this.scoreText.text = score.ToString();
    }
}
