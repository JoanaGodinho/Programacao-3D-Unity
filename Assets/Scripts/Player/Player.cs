using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public static class PlayerStats {
    public static int score = 0;
}

public class Player : MonoBehaviour {

    private const string HEALTH_TAG = "Health";
    private const string SCORE_TAG = "Score";

    public int score = 0;
    public int health = 100;
    public int bullets = 15;

    public Text healthText;
    public Text scoreText;
    public Text bulletsText;

    private int defaultHealth;

	// Use this for initialization
	void Start () {
        defaultHealth = health;

        // Set Texts
        healthText.text = HEALTH_TAG + ": " + health;
        scoreText.text = SCORE_TAG + ": " + score;
        bulletsText.text = "" + bullets;

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

    public void decreaseBullets()
    {
        this.bullets--;
        bulletsText.text = "" + bullets;
    }

    public void dealDamamge(int damage)
    {
        health -= damage;

        if (health <= 0)
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
        PlayerStats.score = this.score;
        SceneManager.LoadScene("EndScene", LoadSceneMode.Single);
    }
}
