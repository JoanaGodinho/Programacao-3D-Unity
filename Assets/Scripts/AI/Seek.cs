using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek {

    private Transform target;
    private Transform owner;
    private float speed;
    private float rotationSpeed = 3;
    private float distance;

    private static Vector3 up = new Vector3(0, 1, 0);

    public Seek(Transform owner, Transform target, float speed, float distance)
    {
        this.owner = owner;
        this.target = target;
        this.speed = speed;
        this.distance = distance;
    }

	// Update is called once per frame
	public void Update () {
        Vector3 distanceVec = this.target.transform.position - this.owner.transform.position;

        if (distanceVec.magnitude < this.distance)
        {

            Vector3 direction = distanceVec.normalized;

            Quaternion lookRotation = Quaternion.LookRotation(direction);
            lookRotation.x = 0;
            lookRotation.z = 0;

            owner.transform.rotation = Quaternion.Slerp(owner.transform.rotation, lookRotation,
                Time.deltaTime * rotationSpeed);

            owner.transform.Translate(direction * speed * Time.deltaTime);
        }

    }
}
