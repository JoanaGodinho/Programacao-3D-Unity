using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Enemy spawnObject;
    public GameObject spawnTarget;
    public int maxObjects = 5;
    public float spawnTimeGap = 10;     // seconds
    public float spawnMaxArea = 20;
    public float spawnMinArea = 10;

    private int objectsCounter = 0;
    private float elapsedTime = 0;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update () {

        elapsedTime += Time.deltaTime;

        if (objectsCounter < maxObjects && elapsedTime > spawnTimeGap)
        {
            float dist = (transform.position - spawnTarget.transform.position).magnitude;
            if (dist > spawnMinArea && dist <= spawnMaxArea)
            {
                Spawn();
                elapsedTime = 0;
            }
        }

	}

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, spawnMinArea);
        Gizmos.DrawWireSphere(transform.position, spawnMaxArea);
    }

    public void OnObjectDestroyed()
    {
        objectsCounter--;
    }

    private void Spawn()
    {
        Enemy obj = Instantiate(spawnObject, transform.position, transform.rotation);
        obj.setSpawner(this);
        obj.setTarget(spawnTarget);
        objectsCounter++;
    }
}
