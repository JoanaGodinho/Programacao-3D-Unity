using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    private const string HEALTH_TAG = "Health";
    private const string SCORE_TAG = "Score";

    public int score = 0;
    public int health = 100;

    public Text healthText;
    public Text scoreText;

    private int defaultHealth;

	// Use this for initialization
	void Start () {
        defaultHealth = health;

        // Set Texts
        healthText.text = HEALTH_TAG + ": " + health;
        scoreText.text = SCORE_TAG + ": " + score;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if (enemy != null)
        {
            this.dealDamamge(enemy.damage);
        }
    }

    public void addScore(int addedScore)
    {
        this.score += addedScore;
        scoreText.text = SCORE_TAG + ": " + score;
    }

    public void dealDamamge(int damage)
    {
        health -= damage;

        if (health < 0)
        {
            health = 0;
            OnPlayerDead();
        }

        healthText.text = HEALTH_TAG + ": " + health;
    }

    public void heal(int heal)
    {
        health += heal;
        if (health > defaultHealth)
        {
            health = defaultHealth;
        }

        healthText.text = HEALTH_TAG + ": " + health;
    }

    private void OnPlayerDead()
    {


    }
}
