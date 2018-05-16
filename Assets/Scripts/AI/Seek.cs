using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek {

    private Transform target;
    private Transform owner;
    private float speed;
	
    public Seek(Transform owner, Transform target, float speed)
    {
        this.owner = owner;
        this.target = target;
        this.speed = speed;
    }

	// Update is called once per frame
	public void Update () {
        Vector3 direction = this.target.transform.position - this.owner.transform.position;
        direction = direction.normalized;

        owner.transform.Translate(direction * speed * Time.deltaTime);
	}
}
