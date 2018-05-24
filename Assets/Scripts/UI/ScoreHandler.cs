using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour {

    public Text scoreText;

	// Use this for initialization
	void Start () {
        scoreText.text = "Score: " + PlayerStats.score;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
