using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 10.0f;

    private CharacterController controller;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        move();
	}

    private void move()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        Vector3 moveDirSide = transform.right * moveH * speed;
        Vector3 moveDirForward = transform.forward * moveV * speed;

        controller.SimpleMove(moveDirSide);
        controller.SimpleMove(moveDirForward);

    }
}
