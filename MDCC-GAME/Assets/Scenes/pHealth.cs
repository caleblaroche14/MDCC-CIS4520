using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pHealth : MonoBehaviour
{

    public int hp = 100;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void damagePlayer(int damage)
    {
        hp -= damage;
    }

    public void healPlayer(int heals)
    {
        hp += heals;
    }

    public int getHealth()
    {
        return hp;
    }

    private void setHealth(int health) // sets the sliders value to the current value stored in hp
    {
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Health: " + hp);
        setHealth(hp);
    }
}
