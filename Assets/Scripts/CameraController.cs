using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    public static int maxh = 0;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        this.player = GameObject.Find("Player");
        maxh = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 playerpos = this.player.transform.position;
        if(maxh < (int)playerpos.y) maxh = (int)playerpos.y;
        Debug.Log(maxh);
        transform.position = new Vector3(
            transform.position.x, playerpos.y+3, transform.position.z
        );
    }
}
