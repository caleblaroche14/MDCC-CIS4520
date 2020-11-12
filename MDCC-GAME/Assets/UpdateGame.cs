using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class UpdateGame : MonoBehaviour
{
    //public GameObject initial;
    public List<GameObject> enemyArray;// = new List<GameObject>;
    GameObject p;
    GameObject e;
    Health eh;
    pHealth ph;

    GameObject ourUI;
    TextMeshPro scoreText;






    Vector3 playerPos;
    Vector3 enemyPos;

    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameObject initial = GameObject.Find("init");
        InitScript intiscript = initial.GetComponent<InitScript>();
        enemyArray = intiscript.enemies;

        ourUI = GameObject.Find("playerUI");
        scoreText = ourUI.GetComponent<TextMeshPro>();




        p = GameObject.Find("player");
        ph = p.GetComponent<pHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ph.getHealth() <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }


        scoreText.SetText("Score:" + score);
        
    }
}
