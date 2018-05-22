using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int kills = 0;
    public int health = 100;

    private int defaultHealth;

	// Use this for initialization
	void Start () {
        defaultHealth = health;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void dealDamamge(int damage)
    {
        health -= damage;

        if (health < 0)
        {
            OnPlayerDead();
        }
    }

    public void heal(int heal)
    {
        health += heal;
        if (health > defaultHealth)
        {
            health = defaultHealth;
        }
    }

    private void OnPlayerDead()
    {


    }
}
