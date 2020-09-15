using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speedCap = 10f;
    public float speedx = 0.0f;
    public float speedy = 0.0f;
    public float accel = 1f;

    Vector3 playerPos;

    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        var playerZ = GameObject.Find("player");
        if (playerZ)
        {
            playerPos = playerZ.transform.position;
        }

        Vector3 pos = transform.position;


        if (pos.x < playerPos.x)
        {
            speedx = speedx + accel;
        }

        pos.y += speedy * Time.deltaTime;
        pos.x += speedx * Time.deltaTime;
    }
}
