using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class MoveScript : MonoBehaviour
{

    public float speed = 10.4f;
    public float jumpSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {


    }



    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("w"))
        {
            pos.y += speed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.y -= speed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            //transform.localRotation = Quaternion.Euler(0, 0, 0);
            pos.x -= speed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            //transform.localRotation = Quaternion.Euler(0, 180, 0);
            pos.x += speed * Time.deltaTime;
        }
        /*
        if (Input.GetKeyDown("space"))
        {
            {
                pos.y += jumpSpeed * Time.deltaTime;
            }
        }
        */

        transform.position = pos;


        //Vector3 cameraPos = GameObject.Find("Main Camera").transform.position;
        //Vector3 playerPos = new Vector3(GameObject.Find("Main Camera").transform.position.x, gameObject.transform.position.y);
        //gameObject.transform.position = playerPos;
    }
}
