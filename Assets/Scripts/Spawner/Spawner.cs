using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Enemy spawnObject;
    public GameObject spawnTarget;
    public int maxObjects = 5;
    public int spawnTimeGap = 10;     // seconds

    private int objectsCounter = 0;
    private float elapsedTime = 0;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update () {

        elapsedTime += Time.deltaTime;

        if (objectsCounter < maxObjects)
        {
            if (elapsedTime > spawnTimeGap)
            {
                Spawn();
                elapsedTime = 0;
            }
        }

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
